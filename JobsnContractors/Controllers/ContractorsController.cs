using System.Collections.Generic;
using System.Threading.Tasks;
using JobsnContractors.Models;
using JobsnContractors.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobsnContractors.Controllers

{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _ContractorsService;
    public ContractorsController(ContractorsService ContractorsService)
    {
      _ContractorsService = ContractorsService;
    }
    [HttpGet]
    public ActionResult<List<Contractor>> GetAll()
    {
      try
      {
        return Ok(_ContractorsService.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{ContractorsId}")]
    public ActionResult<Contractor> GetById(int ContractorsId)
    {
      try
      {
        return Ok(_ContractorsService.GetById(ContractorsId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Contractor>> Post([FromBody] Contractor contractorData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // for node reference - req.body.creatorId = req.userInfo.id
        // FIXME NEVER TRUST THE CLIENT
        contractorData.CreatorId = userInfo.Id;
        Contractor createdContractors = _ContractorsService.Create(contractorData);
        createdContractors.Creator = userInfo;
        return createdContractors;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{ContractorsId}")]
    public async Task<ActionResult<string>> RemoveContractors(int contractorId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _ContractorsService.DeleteContractors(contractorId, userInfo.Id);
        return Ok("Contractors was delorted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
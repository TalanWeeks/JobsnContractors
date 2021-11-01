using System.Collections.Generic;
using System.Threading.Tasks;
using JobsnContractors.Models;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobsnContractors.Services;

namespace JobsnContractors.Controllers

{
  [ApiController]
  [Route("api/[controller]")]
  public class CompanysController : ControllerBase
  {
    private readonly CompanysService _companysService;
    public CompanysController(CompanysService companysService)
    {
      _companysService = companysService;
    }
    [HttpGet]
    public ActionResult<List<Company>> GetAll()
    {
      try
      {
        return Ok(_companysService.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{CompanysId}")]
    public ActionResult<Company> GetById(int CompanysId)
    {
      try
      {
        return Ok(_companysService.GetById(CompanysId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Company>> Create([FromBody] Company CompanysData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // for node reference - req.body.creatorId = req.userInfo.id
        // FIXME NEVER TRUST THE CLIENT
        CompanysData.CreatorId = userInfo.Id;
        Company createdCompanys = _companysService.Create(CompanysData);
        createdCompanys.Creator = userInfo;
        return createdCompanys;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpDelete("{CompanysId}")]
    public async Task<ActionResult<string>> RemoveCompany(int CompanysId)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _companysService.RemoveCompany(CompanysId, userInfo.Id);
        return Ok("Companys was delorted");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
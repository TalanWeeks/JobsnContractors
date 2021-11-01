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
public class JobsController : ControllerBase
{
private readonly JobsService _JobsService;
public JobsController(JobsService JobsService)
{
_JobsService = JobsService;
}
[HttpGet]
public ActionResult<List<Job>> GetAll()
{
try
{
return Ok(_JobsService.GetAll());
}
catch (System.Exception e)
{
return BadRequest(e.Message);
}
}
[HttpGet("{JobsId}")]
public ActionResult<Job> GetById(int JobsId)
{
try
{
return Ok(_JobsService.GetById(JobsId));
}
catch (System.Exception e)
{
return BadRequest(e.Message);
}
}
[Authorize]
[HttpPost]
public async Task<ActionResult<Job>> Post([FromBody] Job JobsData)
{
try
{
Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
// for node reference - req.body.creatorId = req.userInfo.id
// FIXME NEVER TRUST THE CLIENT
JobsData.CreatorId = userInfo.Id;
Job createdJobs = _JobsService.Post(JobsData);
createdJobs.Creator = userInfo;
return createdJobs;
}
catch (System.Exception e)
{
return BadRequest(e.Message);
}
}
[Authorize]
[HttpDelete("{JobsId}")]
public async Task<ActionResult<string>> RemoveJobs(int JobsId)
{
try
{
Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
_JobsService.RemoveJobs(JobsId, userInfo.Id);
return Ok("Jobs was delorted");
}
catch (System.Exception e)
{
return BadRequest(e.Message);
}
}
}
}
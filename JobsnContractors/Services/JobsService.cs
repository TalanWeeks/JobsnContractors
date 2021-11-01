using System;
using System.Collections.Generic;
using JobsnContractors.Models;
using JobsnContractors.Repositories;

namespace JobsnContractors.Services
{
  public class JobsService
{
  private readonly JobsRepository _JobsRepository;

  public JobsService(JobsRepository JobsRepository)
  {
    _JobsRepository = JobsRepository;
  }

  public List<Job> GetAll()
  {
    return _JobsRepository.Get();
  }

  public Job GetById(int JobsId)
  {
    Job foundJobs = _JobsRepository.Get(JobsId);
    if(foundJobs == null)
  {
    throw new Exception("Unable to find Job");
  }
    return foundJobs;
  }

  public Job Post(Job JobsData)
  {
    return _JobsRepository.Create(JobsData);
  }

  public void RemoveJobs(int jobId, string userId)
  {
    Job foundJobs = GetById(jobId);
    if(foundJobs.CreatorId != userId)
  {
    throw new Exception("That aint your Job");
  }
    _JobsRepository.Delete(jobId);
  }
  }
}
using System.Collections.Generic;
using JobsnContractors.Interfaces;
using JobsnContractors.Models;

namespace JobsnContractors.Repositories
{
  public class JobsRepository : IRepository<Job>
  {
    public Job Create(Job data)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Job Edit(int id, Job data)
    {
      throw new System.NotImplementedException();
    }

    public List<Job> Get()
    {
      throw new System.NotImplementedException();
    }

    public Job Get(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}
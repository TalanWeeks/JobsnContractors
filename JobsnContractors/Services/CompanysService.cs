using System;
using System.Collections.Generic;
using JobsnContractors.Models;
using JobsnContractors.Repositories;

namespace JobsnContractors.Services
{
public class CompanysService
{
private readonly CompanysRepository _companysRepository;

public CompanysService(CompanysRepository companysRepository)
{
_companysRepository = companysRepository;
}

public List<Company> GetAll()
{
return _companysRepository.Get();
}

public Company GetById(int CompanysId)
{
Company foundCompanys = _companysRepository.Get(CompanysId);
if(foundCompanys == null)
{
throw new Exception("Unable to find Companys");
}
return foundCompanys;
}

public Company Create(Company CompanysData)
{
return _companysRepository.Create(CompanysData);
}

public void RemoveCompany(int CompanysId, string userId)
{
Company foundCompanys = GetById(CompanysId);
if(foundCompanys.CreatorId != userId)
{
throw new Exception("That aint your Companys");
}
_companysRepository.Delete(CompanysId);
}

}
}
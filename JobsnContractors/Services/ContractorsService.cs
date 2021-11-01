using System;
using System.Collections.Generic;
using JobsnContractors.Models;
using JobsnContractors.Repositories;

namespace JobsnContractors.Services
{
public class ContractorsService
{
private readonly ContractorsRepository _contractorsRepository;

public ContractorsService(ContractorsRepository contractorsRepository)
{
_contractorsRepository = contractorsRepository;
}

public List<Contractor> GetAll()
{
return _contractorsRepository.Get();
}

public Contractor GetById(int ContractorsId)
{
Contractor foundContractors = _contractorsRepository.Get(ContractorsId);
if(foundContractors == null)
{
throw new Exception("Unable to find Contractors");
}
return foundContractors;
}

public Contractor Create(Contractor contractorData)
{
return _contractorsRepository.Create(contractorData);
}

public void DeleteContractors(int ContractorsId, string userId)
{
Contractor foundContractors = GetById(ContractorsId);
if(foundContractors.CreatorId != userId)
{
throw new Exception("That aint your Contractors");
}
_contractorsRepository.Delete(ContractorsId);
}

}
}
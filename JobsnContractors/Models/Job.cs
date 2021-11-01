namespace JobsnContractors.Models  
  {
    public class Job {
    public int Id { get; set; }

    public string CreatorId { get; set; }

    public Profile Creator { get; set; }
    public int ContractorId { get; set; }
    public int CompanyId { get; set; }

  }
}
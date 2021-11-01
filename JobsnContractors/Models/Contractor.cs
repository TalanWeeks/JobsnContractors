  namespace JobsnContractors.Models
  {  
    public class Contractor {
    public int Id { get; set; }

    public string CreatorId { get; set; }

    public Profile Creator { get; set; }
    public int Name { get; set; }

  }
}
namespace JobsnContractors.Models
{
  public class Company
  {
    public int Id { get; set; }

    public string CreatorId { get; set; }

    public Profile Creator { get; set; }

    public string Name { get;set; }
  }
}
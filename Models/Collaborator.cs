using System.ComponentModel.DataAnnotations.Schema;

namespace iService.Models
{
    public class Collaborator
    {
        public Collaborator()
        {
            
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public Function? FunctionId { get; set; }
        public float Salary { get; set; }
        public Sector? SectorId { get; set; }
    }
}
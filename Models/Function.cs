namespace iService.Models
{
    public class Function
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IList<Collaborator>? Collaborators { get; set; }
    }
}
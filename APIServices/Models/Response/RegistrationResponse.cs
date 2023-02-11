namespace Todo.Models
{
    public class RegistrationResponse
    {
        public long ID { get; set; }
        public Guid Registration { get; set;}
        public string? Username { get; set; }
        public string? EmailId { get; set; }
    }
}

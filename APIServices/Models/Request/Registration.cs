namespace APIServices.Models
{
    public class Registration
    {
        public long Id { get; set; }
        public Guid RegistrationUniqueId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? DateofBirth { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? Username { get; set; }
        public string? Lastname { get; set;}
    }
}

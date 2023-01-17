namespace OTUSHigloadTestProject.Models.Database
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Age { get; set; }
        public string Biography { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Login { get; set; }
    }
}

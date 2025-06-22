namespace FinalProject.Models.Entities
{

    // Represents a single user record in the database
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

}

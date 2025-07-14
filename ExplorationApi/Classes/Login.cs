using System.ComponentModel.DataAnnotations;

namespace ExplorationApi.Classes
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
    
        public required string Email { get; set; }
      
        public required string Password { get; set; }

    }
}

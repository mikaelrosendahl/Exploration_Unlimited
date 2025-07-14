using System.ComponentModel.DataAnnotations.Schema;

namespace ExplorationApi.Classes
{
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("password")]
        public required string Password { get; set; }

        [Column("confirm_password")]
        public required string ConfirmPassword { get; set; }
    }
}


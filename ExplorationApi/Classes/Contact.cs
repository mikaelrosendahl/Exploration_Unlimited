using System.ComponentModel.DataAnnotations.Schema;

namespace ExplorationApi.Classes
{
    public class Contact
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public required string email { get; set; }

        [Column("name")]
        public string? name { get; set; }

        [Column("message")]
        public string? message { get; set; }
    }
}


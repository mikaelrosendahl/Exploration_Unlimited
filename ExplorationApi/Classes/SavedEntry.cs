using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExplorationApi.Classes
{
    [Table("savedentries", Schema = "public")]
    public class SavedEntry
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public required string Title { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("last_saved")]
        public DateTime LastSaved { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}

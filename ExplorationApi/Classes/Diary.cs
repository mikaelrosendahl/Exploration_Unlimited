using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExplorationApi.Models
{
    [Table("diaryentries", Schema = "public")]
    public class DiaryEntry
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public required string Title { get; set; }

        [Column("content")]
        public required string Content { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("is_published")]
        public int IsPublished { get; set; }
    }
}



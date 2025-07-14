using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Series
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("title")]
    public required string Title { get; set; }

    [MaxLength(500)]
    [Column("description")]
    public string? Description { get; set; }
}

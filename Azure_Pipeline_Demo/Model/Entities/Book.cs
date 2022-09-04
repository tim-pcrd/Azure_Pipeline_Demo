using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Azure_Pipeline_Demo.Model.Entities;

public class Book
{
[Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100)")]
[Required]
    public string Name { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    [Required]
    public string Genre { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    [Required]
    public string PublisherName { get; set; }
}

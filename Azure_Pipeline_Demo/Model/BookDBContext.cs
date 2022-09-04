using Azure_Pipeline_Demo.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Azure_Pipeline_Demo.Model;

public class BookDBContext : DbContext
{
    public BookDBContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}

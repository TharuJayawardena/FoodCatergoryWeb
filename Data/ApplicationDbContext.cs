using FoodCatergoryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodCatergoryWeb.Data;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Catergory> Catergories { get; set; }
}


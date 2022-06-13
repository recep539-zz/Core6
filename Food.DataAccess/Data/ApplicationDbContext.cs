using Food.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Food.DataAccess.Data;

public class ApplicationDbContext:IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {

    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FoodType> FoodTypes { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<OrderHeader> OrderHeader { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
}

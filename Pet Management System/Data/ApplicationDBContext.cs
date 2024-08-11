using Microsoft.EntityFrameworkCore;
using Pet_Management_System.Models.Entities;

namespace Pet_Management_System.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext( DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }
        public DbSet<Pet> Pets { get; set; }
    }
}

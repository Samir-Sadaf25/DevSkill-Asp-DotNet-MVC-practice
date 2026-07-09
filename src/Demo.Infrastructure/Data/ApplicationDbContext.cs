using Demo.Domain.Entities;
using Demo.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser,
       ApplicationRole,
       Guid,
       ApplicationUserClaim,
       ApplicationUserRole,
       ApplicationUserLogin,
       ApplicationRoleClaim,
       ApplicationUserToken>(options)
    {
        public DbSet<Product> products { get; set; }
    }
}
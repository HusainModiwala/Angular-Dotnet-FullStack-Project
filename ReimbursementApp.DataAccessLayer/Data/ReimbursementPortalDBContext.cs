using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReimbursementApp.DataAccessLayer.Entities;

namespace ReimbursementApp.DataAccessLayer.Data
{
    public class ReimbursementPortalDBContext: IdentityDbContext<User>
    {
        public ReimbursementPortalDBContext(DbContextOptions<ReimbursementPortalDBContext> options):base(options)
        {

        }
        public DbSet<Claim> Claims { get; set; }
    }
}

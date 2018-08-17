using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using FEDPAY.Models;

namespace FEDPAYmgr.Models
{
    /// <summary>
    /// Define FEDPAY Context and tables in the Context
    /// </summary>
    public class FEDPAYContext : DbContext
    {
        public FEDPAYContext(DbContextOptions<FEDPAYContext> options)
            : base(options) { }


        public DbSet<FEDPAY.Models.Region> Region { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///
            /// Assign default database schema.  
            /// The database service has limited system access right to create objects in the sift schema
            /// 
            modelBuilder.HasDefaultSchema("fedpay");
            //base.OnModelCreating(modelBuilder);
        }
    }
}

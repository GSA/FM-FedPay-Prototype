using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public DbSet<FEDPAY.Models.Non_Merchandise_Code> Non_Merchandise_Code { get; set; }
        public DbSet<FEDPAY.Models.Admin_Diff> Admin_Diff { get; set; }
        public DbSet<FEDPAY.Models.Fedpay_Err_Mes> Fedpay_Err_MES { get; set; }
        public DbSet<FEDPAY.Models.Invoice_Summary> Invoice_Summary { get; set; }
        public DbSet<FEDPAY.Models.Vendor> Vendor { get; set; }
        public DbQuery<FEDPAY.Models.AdmDiffStmtVw> AdmDiffStmtVw { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ///
            /// Assign default database schema.  
            /// The database service has limited system access right to create objects 
            /// 
            modelBuilder.HasDefaultSchema("fedpay");
            //base.OnModelCreating(modelBuilder);

            //Complex Primary Keys
            {
                modelBuilder.Entity<Admin_Diff>()
                    .HasKey(c => new { c.ADD_PO_NO, c.ADD_INVOICE_NO, c.ADD_SEQ_NO });
                modelBuilder.Entity<Invoice_Summary>()
                    .HasKey(c => new { c.INS_PO_NO, c.INS_INVOICE_NO });
            }

            //assign Relationships
            {
                modelBuilder.Entity<Admin_Diff>()
                    .HasOne(p => p.Invoice_Summary)
                    .WithMany(b => b.Admin_Diffs);

            }

            //Complex View
            {
                modelBuilder.Query<AdmDiffStmtVw>().ToView("AdmDiffStmtVw");
            }


        }
    }
}

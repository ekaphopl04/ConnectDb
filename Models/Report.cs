using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DotnedataBase.Models{

    public class Report {
        [Key]
        public int Id{ set; get ;}
        public string Name { set; get ;}
        public string Surname { set; get ;}
    }
    
    public class ReportContext : DbContext {
        public DbSet<Report> ReportTable { set; get ;}

        public ReportContext(DbContextOptions<ReportContext> options) : base(options) {}
    }
}
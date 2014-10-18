using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project2.Models.DAL.Mapper;
using Project2.Models.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Project2.Models.DAL
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AppContext : DbContext
    {

        public AppContext() :  base("Mysql")
        {
           
        }

        public DbSet<Student> Studenten { get; set; }
        public DbSet<BPCoordinator> bpcoordinators { get; set; }
        public DbSet<Promotor> Promotoren { get; set; }
        public DbSet<Voorstel> voorstellen { get; set; }
        public DbSet<OnderzoeksDomein> Onderzoeksdomeinen { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Advies> Adviezen { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new StudentMapper());
            modelBuilder.Configurations.Add(new PromotorMapper());
            modelBuilder.Configurations.Add(new BpcoordinatorMapper());
            modelBuilder.Configurations.Add(new VoorstelMapper());
            modelBuilder.Configurations.Add(new OnderzoeksDomeinMapper());
            modelBuilder.Configurations.Add(new FeedbackMapper());
            modelBuilder.Configurations.Add(new AdviesMapper());
        }

     
    }
}
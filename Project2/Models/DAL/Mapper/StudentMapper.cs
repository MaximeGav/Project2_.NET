using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Project2.Models.Domain;

namespace Project2.Models.DAL.Mapper
{
    public class StudentMapper : EntityTypeConfiguration<Student>
    {
        public StudentMapper()
        {
             //Id, voornaam, familienaam, email, wachtwoord, promotorID
            Property(t => t.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(t => t.id);
            Property(t => t.voornaam).IsRequired();
            Property(t => t.familienaam).IsRequired();
            Property(t => t.wachtwoord).IsRequired();
            Property(t => t.email).IsRequired();
            HasOptional(t => t.Voorstel);


        }
    }
}
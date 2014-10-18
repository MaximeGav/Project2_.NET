using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Project2.Models.Domain;

namespace Project2.Models.DAL.Mapper
{
    public class AdviesMapper : EntityTypeConfiguration<Advies>
    {
        public AdviesMapper()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(t => t.Id);
            Property(t => t.Vraag).IsRequired();
            Property(t => t.Antwoord).IsOptional();
        }
    }
}
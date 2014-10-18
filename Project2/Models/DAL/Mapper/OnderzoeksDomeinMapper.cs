using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Project2.Models.Domain;

namespace Project2.Models.DAL.Mapper
{
    public class OnderzoeksDomeinMapper : EntityTypeConfiguration<OnderzoeksDomein>
    {
        public OnderzoeksDomeinMapper()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(t => t.Id);
            Property(t => t.Naam).IsRequired();
        }
    }
}

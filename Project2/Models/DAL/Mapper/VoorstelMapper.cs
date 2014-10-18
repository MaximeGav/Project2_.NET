using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Project2.Models.Domain;
namespace Project2.Models.DAL.Mapper
{
    public class VoorstelMapper : EntityTypeConfiguration<Voorstel>
    {
        public VoorstelMapper()
        {
            
            this.HasKey(t => t.id);
            Property(t => t.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Titel).IsRequired();
            this.Property(t => t.Trefwoorden).IsOptional();
            this.Property(t => t.Context).IsRequired();
            this.Property(t => t.Onderzoeksvraag).IsRequired();
            this.Property(t => t.AanpaksPlan).IsRequired();
            this.HasRequired(t => t.OnderzoeksDomein1);
            this.HasOptional(t => t.OnderzoeksDomein2);
            this.Property(t => t.ReferentieLijst).IsRequired();
            this.Property(t => t.Status).IsRequired();
            this.Property(t => t.IsDefinitief).IsOptional();
            this.HasOptional(t => t.Feedback1);
            this.HasOptional(t => t.Advies);
        }

    }
}
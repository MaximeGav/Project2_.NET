using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Project2.Models.Domain;

namespace Project2.Models.DAL.Mapper
{
    public class FeedbackMapper : EntityTypeConfiguration<Feedback>
    {
        public FeedbackMapper()
        {
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(t => t.Id);
            Property(t => t.ScoreTitel).IsRequired();
            Property(t => t.ScoreContext).IsRequired();
            Property(t => t.ScoreSmart).IsRequired();
            Property(t => t.ScoreOnderzoeksvraag).IsRequired();
            Property(t => t.ScoreBijdrage).IsRequired();
            Property(t => t.ScoreOnderwerp).IsRequired();
            Property(t => t.ScoreReferentielijst).IsRequired();
            Property(t => t.Suggesties).IsOptional();
            Property(t => t.IsDefinitief).IsOptional();
        }
    }
}
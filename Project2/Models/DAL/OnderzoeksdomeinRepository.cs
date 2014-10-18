using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project2.Models.Domain;
using System.Data.Entity;

namespace Project2.Models.DAL
{
    public class OnderzoeksdomeinRepository : IOnderzoeksdomeinRepository
    {
        private AppContext context;
        private DbSet<OnderzoeksDomein> onderzoeksdomeinen;

        public OnderzoeksdomeinRepository(AppContext context)
        {
            this.context = context;
            onderzoeksdomeinen = context.Onderzoeksdomeinen;
        }

        public void Add(OnderzoeksDomein onderzoeksDomein)
        {
            onderzoeksdomeinen.Add(onderzoeksDomein);
        }
        public void Delete(OnderzoeksDomein onderzoeksDomein)
        {
            onderzoeksdomeinen.Remove(onderzoeksDomein);
        }
        public OnderzoeksDomein FindBy(int OnderzoeksDomeinId)
        {
            return onderzoeksdomeinen.Find(OnderzoeksDomeinId);
        }

 
        public IQueryable<OnderzoeksDomein> FindAll()
        {
            return onderzoeksdomeinen;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}

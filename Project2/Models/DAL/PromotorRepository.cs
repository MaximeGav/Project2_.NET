using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project2.Models.Domain;
using System.Data.Entity;

namespace Project2.Models.DAL
{
    public class PromotorRepository : IPromotorRepository
    {
        private AppContext context;
        private DbSet<Promotor> promotoren;

        public PromotorRepository(AppContext context)
        {
            this.context = context;
            promotoren = context.Promotoren;
        }

        public void Add(Promotor Promotor)
        {
            promotoren.Add(Promotor);
        }
        public void Delete(Promotor Promotor)
        {
            promotoren.Remove(Promotor);
        }
        public Promotor FindBy(string email)
        {
            foreach (var promotor in promotoren)
            {
                if (promotor.email == email)
                    return promotor;
            }
            return null;
        }
        public IQueryable<Promotor> FindAll()
        {
            return promotoren;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
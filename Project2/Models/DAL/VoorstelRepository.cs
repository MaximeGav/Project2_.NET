using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Project2.Models.Domain;
using System.Data.Entity;
namespace Project2.Models.DAL
{
    public class VoorstelRepository : IVoorstelRepository
    {
        private AppContext context;
        private DbSet<Voorstel> Voorstellen;

        public VoorstelRepository(AppContext context)
        {
            this.context = context;
            Voorstellen = context.voorstellen;
        }
            
        public void Add(Voorstel Voorstel)
        {
        
            Voorstellen.Add(Voorstel);
        }
        public void Delete(Voorstel voorstel)
        {
            try
            {
                var e = context.Entry(voorstel);
                if (e.State == EntityState.Detached)
                {
                    context.Set<Voorstel>().Attach(voorstel);
                    e = context.Entry(voorstel);
                }
                e.State = EntityState.Deleted;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(
                    "Error deleting voorstel.", ex);
            }
        }
        public Voorstel FindBy(int VoorstelId)  
        {
            return Voorstellen.Find(VoorstelId);
        }
        public IQueryable<Voorstel> FindAll()
        {
            return Voorstellen;
        }
        public void SaveChanges()
        {
            
                context.SaveChanges();
            
        }
    }
}
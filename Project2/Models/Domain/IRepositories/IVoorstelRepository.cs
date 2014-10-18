using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2.Models.Domain
{
    public interface IVoorstelRepository
    {
        void Add(Voorstel Voorstel);
        void Delete(Voorstel Voorstel);
        Voorstel FindBy(int VoorstelId);
        IQueryable<Voorstel> FindAll();
        void SaveChanges();
    }
}

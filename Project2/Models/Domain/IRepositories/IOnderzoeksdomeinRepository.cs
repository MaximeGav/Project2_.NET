using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2.Models.Domain
{
    public interface IOnderzoeksdomeinRepository
    {
        OnderzoeksDomein FindBy(int onderzoeksDomeinId);
        IQueryable<OnderzoeksDomein> FindAll();
        void Add(OnderzoeksDomein onderzoeksDomein);
        void Delete(OnderzoeksDomein onderzoeksDomein);
        void SaveChanges();
    }
}


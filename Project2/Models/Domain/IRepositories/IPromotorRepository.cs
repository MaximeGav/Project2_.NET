using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2.Models.Domain
{
    public interface IPromotorRepository
    {
        Promotor FindBy(string email);
        IQueryable<Promotor> FindAll();
        void Add(Promotor promotor);
        void Delete(Promotor promotor);
        void SaveChanges();
    }
}


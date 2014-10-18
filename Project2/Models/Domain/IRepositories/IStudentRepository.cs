using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2.Models.Domain
{
    public interface IStudentRepository
    {
        Student FindBy(string username);
        Student FindBy(Voorstel voorstel);
        IQueryable<Student> FindAll();
        Voorstel FindVoorstel(string email);
        void Add(Student student);
        void Delete(Student student);
        void SaveChanges();
    }
}


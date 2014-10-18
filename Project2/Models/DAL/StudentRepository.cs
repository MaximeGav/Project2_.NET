using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project2.Models.Domain;
using System.Data.Entity;

namespace Project2.Models.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private AppContext context;
        private DbSet<Student> studenten;

        public StudentRepository(AppContext context)
        {
            this.context = context;
            studenten = context.Studenten;
        }

        public void Add(Student student)
        {
            studenten.Add(student);
        }
        public void Delete(Student student)
        {
            studenten.Remove(student);
        }
        public Student FindBy(string email)
        {
            
            foreach (var student in studenten)
            {
                if (student.email == email)
                    return student;
            }
            return null;
        }

        public Student FindBy(Voorstel voorstel)
        {
            foreach (var student in studenten)
            {
                if (student.Voorstel == voorstel)
                    return student;
            }
            return null;
        }

        public Voorstel FindVoorstel(String username)
        {
            Student student = FindBy(username);
            
            return student.Voorstel;
        }
        public IQueryable<Student> FindAll()
        {
            return studenten;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
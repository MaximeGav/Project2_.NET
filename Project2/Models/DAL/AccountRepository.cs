using Project2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project2.Models.DAL
{
    public class AccountRepository
    {
        private AppContext context;
        private DbSet<Student> studenten;
        private DbSet<BPCoordinator> bpCoordinator;
        private DbSet<Promotor> promotoren;
        public AccountRepository(AppContext context)
        {
            this.context = context;
            studenten = context.Studenten;
            bpCoordinator = context.bpcoordinators;
            promotoren = context.Promotoren;
        }

        public void Add(Student Student)
        {
            studenten.Add(Student);
        }
        public void Delete(Student Student)
        {
            studenten.Remove(Student);
        }
        public Student FindBy(int StudentId)
        {
            return studenten.Find(StudentId);
        }
        public Gebruiker FindByEmail(String email)
        {
            
            BPCoordinator bp = bpCoordinator.Where(b => b.email == email).FirstOrDefault();
            if (bp != null)
            {
                return bp;
            }
            Promotor promotor = promotoren.Where(p => p.email == email).FirstOrDefault();
            if (promotor != null)
            {
                return promotor;
            }
            return studenten.Where(s => s.email == email).FirstOrDefault();
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
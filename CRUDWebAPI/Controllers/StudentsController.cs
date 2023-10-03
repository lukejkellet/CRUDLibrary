using CRUDLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace CRUDWebAPI.Controllers
{
    public class StudentsController : ApiController
{
        NorthwindEntities OE = new NorthwindEntities();
        // ..api/Students/
        public IQueryable<Person> Get()
        {
            return OE.People;
        }
        // ../api/Students/1
        public Person Get(int id)
        {
            Person person = OE.People.Find(id);
            return person;
        }
        // ../api/department
        public void Put(int id, Person student)
        {
            OE.Entry(student).State =
            System.Data.Entity.EntityState.Modified
            ;
            OE.SaveChanges();
        }
        // ../api/department
        public void Delete(int id)
        {
            Person person = OE.People.Find(id);
            OE.People.Remove(person);
            OE.SaveChanges();
        }
        // ..api/Students/
        public void Post(Person student)
        {
            OE.People.Add(student);
            OE.SaveChanges();
        }
    }
}
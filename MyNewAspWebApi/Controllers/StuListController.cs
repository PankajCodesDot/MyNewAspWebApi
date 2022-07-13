using MyNewAspWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyNewAspWebApi.Controllers
{
    public class StuListController : ApiController
    {
        studentEntities db = new studentEntities();
       [HttpGet]
        public IHttpActionResult Action()
        {
            var obj = db.stds.ToList(); // var obj can be replaced by List<Stu> obj=
            return Ok(obj);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var obj = db.stds.Where(x => x.id == id).FirstOrDefault(); // var obj can be replaced by List<Stu> obj= and FirstOrDefalt() replaced by ToList();
            return Ok(obj);
        }
        //[HttpGet] if you want get by id then we use
        //  public IHttpActionResult Action(int id)
        //  {
        //      var obj = db.stds.Where(x => x.id == id).FirstOrDefault(); //in place of first or defalt we can use .ToList();
        //      return Ok(obj);
        //  }
        [HttpPost]
        public IHttpActionResult Insert(std stdins)
        {
            db.stds.Add(stdins);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update(std stdins)
        {
            db.Entry(stdins).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //OR 

            //var data = db.stds.Where(x => x.id == stdins.id).FirstOrDefault();
            //if (data != null)
            //{
            //    data.id = stdins.id;
            //    data.name = stdins.name;
            //    data.department = stdins.department;
            //    data.gender = stdins.gender;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult StuDelete(int id)
        {
            var obj = db.stds.Where(x => x.id == id).FirstOrDefault();
            db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            //var obj = db.stds.Find(id);
            //db.stds.Remove(obj);
            db.SaveChanges();
            return Ok();
        }
    }
}

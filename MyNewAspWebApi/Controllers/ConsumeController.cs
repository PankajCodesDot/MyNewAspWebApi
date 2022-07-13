using MyNewAspWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MyNewAspWebApi.Controllers
{
    public class ConsumeController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<std> obj = new List<std>();
            client.BaseAddress = new Uri("https://localhost:44392/api/stulist");
           var response= client.GetAsync("stulist");
            response.Wait();
            var test = response.Result;

            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<std>>();
                display.Wait();
                obj = display.Result;
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            std s = null;
            client.BaseAddress = new Uri("https://localhost:44392/api/stulist");
            var response = client.GetAsync("stulist?id="+id.ToString());
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<std>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(std s)
        {
          
            client.BaseAddress = new Uri("https://localhost:44392/api/stulist");
            var response = client.PostAsJsonAsync<std>("stulist", s);
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            std s = null;
            client.BaseAddress = new Uri("https://localhost:44392/api/stulist");
            var response = client.GetAsync("stulist?id=" + id.ToString());
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<std>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(std stud)
        {
           
            client.BaseAddress = new Uri("https://localhost:44392/api/stulist");
            var response = client.PutAsJsonAsync<std>("stulist", stud);
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            return View("Edit");
        }

        public ActionResult Delete(int id)
        {
            std s = null;
            client.BaseAddress = new Uri("https://localhost:44392/api/stulist");
            var response = client.GetAsync("stulist?id=" + id.ToString());
            response.Wait();
            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<std>();
                display.Wait();
                s = display.Result;
            }
            return View(s);
        }

        [HttpPost,ActionName("Delete")]
        public  ActionResult DeleteConfirm(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44392/api/stulist");
            var response = client.DeleteAsync("stulist/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UserModels;

namespace UserFrontEnd.Controllers
{
    public class UserController : Controller
    {
        public ActionResult GetUsers()
        {
            try
            {
                HttpResponseMessage response = null;
                IEnumerable<UserDetails> usersList = null;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"]);
                    using (response = client.GetAsync("User/GetUsers").Result)
                    {
                        if (response != null)
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                usersList = response.Content.ReadAsAsync<IEnumerable<UserDetails>>().Result;
                            }
                        }
                    }
                }

                return View(usersList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserDetails userDetails)
        {
            try
            {
                HttpResponseMessage response = null;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"]);
                    response = client.PostAsJsonAsync("User/Add", userDetails).Result;

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("GetUsers");
                        }
                    }
                }
                return View();
                
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
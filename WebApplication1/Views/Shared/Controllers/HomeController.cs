using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using WebApplication1.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {   
        private readonly HospitalDbContext _context;
        /*
        public HomeController(HospitalDbContext context)
        {
            _context = context;
        }
        */
        // Ana sayfa görüntülenirken kullanıcı adı veya şifre hatalıysa gösterilen hata mesajını yöneten action metodu.
        public IActionResult FirstPage(string? errorMessage = null)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ViewData["LoginError"] = errorMessage;
            }
            return View();
        }

        // Giriş formu tarafından gönderilen kullanıcı adı ve şifreyi kontrol eden ve yönlendiren action metodu.
        [HttpPost]
        public IActionResult FirstPage(string username, string password)
        {
            if (username == "admin" && password == "12345")
            {
                // Kullanıcı adı ve şifre doğru ise "Anasayfa" action'ına yönlendirilir.
                return RedirectToAction("Anasayfa");
            }
            else
            {
                // Kullanıcı adı veya şifre yanlışsa hata mesajıyla tekrar giriş sayfasına yönlendirilir.
                return FirstPage("Kullanıcı bilgileri hatalı. Tekrar deneyin...");
            }
        }

        // Ana sayfanın gösterildiği action metodu.
        public IActionResult Anasayfa()
        {
            return View();
        }

        // Index sayfasını gösteren action metodu.
        public IActionResult Index()
        {
            return View();



        }

        

        // Hasta bilgilerinin görüntülendiği Privacy sayfasının action metodu.
        public IActionResult Privacy()
        {
            //var hastalar = _context.Patients.ToList();
            return View();
        }
        //return View(patients)

        // Hata durumlarında gösterilen Error sayfasının action metodu.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Hata mesajı ve kimlik bilgisini içeren ErrorViewModel ile Error.cshtml sayfasını gösterir.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


// <h5>  <b> <i>Hastane bilgi yönetim sistemine hoşgeldiniz </i></b>  </h5>   <br />
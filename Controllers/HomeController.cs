using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebGz.Models;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;


namespace WebGz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        [Authorize]
        public IActionResult Private()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Objetivos()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        //---------------------------autenticacion
        [HttpGet("Login")]
        public IActionResult Login(string returnUrl)
        { 
            ViewData["ReturnUrl"]= returnUrl;
            return View();  
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Validar(string username, string password, string returnUrl)
        {
            if(username == "Agudeloga" && password == "1234")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username",username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier,username));
                claims.Add(new Claim(ClaimTypes.Name, "Gabrielaa"));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }
            else
            {
                ViewData["ReturnUrl"]= returnUrl;
                TempData["Error"] = "El usuario o la contraseña no son validas";
                return View("Login");
            }
        }
        
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }


        //---------------------------autenticacion
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

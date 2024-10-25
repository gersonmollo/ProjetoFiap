using Microsoft.AspNetCore.Mvc;
using ProjetoFiap.Interfaces;
using ProjetoFiap.Models;
using ProjetoFiap.Services;
using System.Collections.Generic;

namespace ProjetoView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;

namespace EbookWEB.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

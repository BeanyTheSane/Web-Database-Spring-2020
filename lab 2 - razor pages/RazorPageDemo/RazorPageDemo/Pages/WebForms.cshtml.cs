﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemo.Pages
{
    public class WebFormsModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "What is ASP.NET Web Forms?";
        }
    }
}
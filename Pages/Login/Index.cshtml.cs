﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUDCore.Pages.Login
{
    public class IndexModel : PageModel
    {
       

        public void OnGet()
        {

        }


        public void OnPost(string txtUsuario, string txtPassword)
        {
            string pepe = "asd";
        }
    }
}
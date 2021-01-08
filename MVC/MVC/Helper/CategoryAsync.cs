using MVC.Helper;
using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Helper
{
    public class CategoryAsync
    {

        private readonly InitApi _initapi;

        public CategoryAsync(InitApi initapi)
        {
            _initapi = initapi;
        }

       
    }
}
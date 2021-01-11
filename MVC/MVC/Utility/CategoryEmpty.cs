using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Utility
{
    public class CategoryEmpty
    {

        public static CategoryModel Empty ()
        {
            try
            {
                CategoryModel cat = new CategoryModel();
                cat.CategoryID = 0;
                cat.CategoryName = string.Empty;
                cat.Description = string.Empty;
                return cat;
            }
            catch (Exception ex)
            { throw ex;
            }
        }
    }
}
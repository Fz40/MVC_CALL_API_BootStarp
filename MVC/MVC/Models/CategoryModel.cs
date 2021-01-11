using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CategoryModel
    {
        [DisplayName("Category ID")]
        public int CategoryID { get; set; }
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Required Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Category Description")]
        public string Description { get; set; }

    }
}
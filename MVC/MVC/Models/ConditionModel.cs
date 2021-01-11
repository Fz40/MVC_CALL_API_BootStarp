using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ConditionModel
    {
        public string encrypt { get; set; }
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void clear ()
        {
            this.encrypt = "";
            this.id = 0;
            this.Name = "";
            this.Description = "";
        }

    }
}
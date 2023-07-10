using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Category{ get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Qunatity { get; set; }
        public string URL { get; set; } 

    }
}

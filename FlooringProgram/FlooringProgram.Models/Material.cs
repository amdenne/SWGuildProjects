using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Models
{
    public class Material
    {
       public string ProductType { get; set; }
       public decimal CostPerSquareFoot { get; set; }
       public decimal LaborCostPerSquareFoot { get; set; }
    }
}

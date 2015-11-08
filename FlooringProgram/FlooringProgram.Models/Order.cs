using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    /*An	Order	consists	of	an	
    order number,	
    customer name,	
    state,	
    tax	rate,	
    product	type,	
    area, 
    cost per square foot,	
    labor cost per square foot,	
    material cost,	
    labor cost,	
    tax,	
    and	total.*/
    public class Order
    {
        public string OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }

        public string ProductType { get; set; }
        public decimal Area { get; set; }

        public decimal LaborCost { get; set; }
        public decimal MaterialCost { get; set; }

        public decimal TotalTax { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }

        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }

    }
}

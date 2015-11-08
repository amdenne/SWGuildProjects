﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class CostReceipt
    {
        public int OrderNumber { get; set; }
        public int Area { get; set; }
        public decimal TaxRate { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal Tax { get; set; }
        public decimal CostTotal { get; set; }
    }
}

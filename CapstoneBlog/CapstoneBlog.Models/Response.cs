﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneBlog.Models
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; } 
        public T Data { get; set; }
    }
}

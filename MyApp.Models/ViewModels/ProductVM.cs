﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace MyApp.Models.ViewModels
{
    public  class ProductVM
    {
        public Products Products { get; set; }=new Products();
        [ValidateNever]
        public IEnumerable<Products> products { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}

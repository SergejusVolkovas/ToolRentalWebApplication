using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRentalWebApplication.Models;
using ToolRentalWebApplication.Entities;

namespace ToolRentalWebApplication.Models
{ 
    public class CategoryDetailsModel
    {
        public IEnumerable<ToolDetailsModel> toolDetailsModels { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}
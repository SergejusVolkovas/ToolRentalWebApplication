using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolRentalWebApplication.Entities;
using ToolRentalWebApplication.Models;

namespace ToolRentalWebApplication.Models
{
    public class GroupedToolsByCategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IGrouping<int, ToolDetailsModel> Items { get; set; }
    }
}
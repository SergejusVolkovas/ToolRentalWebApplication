using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToolRentalWebApplication.Entities;

namespace ToolRentalWebApplication.Models
{
    public class ToolDetailsModel
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category Title")]
        public string CategoryTitle { get; set; }
        public int ToolId { get; set; }
        [Display(Name = "Tool Title")]
        public string ToolTitle { get; set; }
        [Display(Name = "Description")]
        public string ToolDescription { get; set; }
        [Display(Name = "Image")]
        public string ThumbnailImagePath { get; set; }
        [Display(Name = "Per Hour, Eur")]
        public decimal PricePerHour { get; set; }
        [Display(Name = "Per Day, Eur")]
        public decimal PricePerDay { get; set; }
        [Display(Name = "Branch")]
        public string BranchName { get; set; }
        public IEnumerable<Tool> Tools { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
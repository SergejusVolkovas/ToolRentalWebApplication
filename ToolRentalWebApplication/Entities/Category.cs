
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToolRentalWebApplication.Interfaces;

namespace ToolRentalWebApplication.Entities
{
    public class Category : IPrimaryProperties
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        public string ThumbnailImagePath { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ICollection<Tool> Tools { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

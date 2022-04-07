
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRentalWebApplication.Entities
{
    public class Tool
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        [Display(Name ="1 hour, Eur")]
        public decimal PricePerHour { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        [Display(Name = "1 day, Eur")]
        public decimal PricePerDay { get; set; }
        [Required]
        [Display(Name = "Image Path")]
        public string ThumbnailImagePath { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required (ErrorMessage ="Please select a valid item from '{0}' dropdown list")]
        [Display(Name = "Branch Name")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        [ForeignKey("ToolId")]
        public virtual ICollection<Rental> Rentals { get; set; }
        [ForeignKey("ToolId")]
        public virtual ICollection<Reservation> Reservations { get; set; }

        [NotMapped]
        public virtual ICollection<SelectListItem> Branches { get; set; }
    }
}


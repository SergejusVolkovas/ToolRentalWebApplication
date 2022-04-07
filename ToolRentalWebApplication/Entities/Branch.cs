using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToolRentalWebApplication.Interfaces;

namespace ToolRentalWebApplication.Entities
{
    public class Branch : IPrimaryProperties
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string BranchName { get; set; }
        [StringLength(200, MinimumLength = 2)]
        public string BranchAddress { get; set; }
        [StringLength(200, MinimumLength = 2)]
        public string WorkingHours { get; set; }
        [Required]
        [Display(Name = "Image Path")]
        public string ThumbnailImagePath { get; set; }

        [ForeignKey("BranchId")]
        public virtual ICollection<Tool> Tools { get; set; }

        [ForeignKey("BranchId")]
        public virtual ICollection<Rental> Rentals { get; set; }
        [ForeignKey("BranchId")]
        public virtual ICollection<Reservation> Reservations { get; set; }
        public string Title { get; set; }
    }
}

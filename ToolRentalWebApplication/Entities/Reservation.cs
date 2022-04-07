using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRentalWebApplication.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        [Required]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
        public DateTime ReservationDay { get; set; }
        public DateTime ReservationEndDay { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        [ForeignKey("ReservationId")]
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}



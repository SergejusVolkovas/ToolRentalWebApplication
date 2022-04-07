using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRentalWebApplication.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ICollection<Rental> Rentals { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}

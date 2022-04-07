using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolRentalWebApplication.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public DateTime RentDay { get; set; }
        public DateTime ReturnDay { get; set; }
        public int ToolId { get; set; }
        public Tool Tool { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

    }
}



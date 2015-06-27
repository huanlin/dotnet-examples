using System;
using System.Collections.Generic;

namespace LayeredApp.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public double TotalPrice { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public OrderStatusEnum StatusId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
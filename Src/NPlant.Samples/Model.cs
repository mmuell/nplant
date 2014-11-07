using System.Collections.Generic;

namespace NPlant.Samples
{
    public enum OrderStatuses
    {
        Open,
        Complete,
        Cancelled
    }

    public class BaseEntity
    {
        public int Id { get; set; }
    }

    public class Order : BaseEntity
    {
        public string Number { get; set; }
        public OrderStatuses Status { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }

    public class OrderItem : BaseEntity
    {
        public Order Order { get; set; }

        public Product Product { get; set; }

        public Price Price { get; set; }

        public string InternalField { get; set; }
    }

    public class Product : BaseEntity
    {
        public string Name { get; set; }
    }

    public class Price
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }

    public abstract class BaseRequestMessage
    {
        
    }

    public abstract class BaseResponseMessage
    {
        
    }

    public class RetrieveProductRequest : BaseRequestMessage
    {
        public int ProductId { get; set; }
    }

    public class RetrieveProductResponse : BaseResponseMessage
    {
        public Product Product { get; set; }
    }

    public class RetrieveOrderRequest : BaseRequestMessage
    {
        public int OrderId { get; set; } 
    }

    public class RetrieveOrderResponse : BaseResponseMessage
    {
        public Order Order { get; set; }
    }

    public class SubmitOrderRequest : BaseRequestMessage
    {
        public Order Order { get; set; }
    }

    public class SubmitOrderResponse : BaseResponseMessage
    {
        public Order Order { get; set; }
    }
}

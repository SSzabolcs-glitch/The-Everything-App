namespace Backend.Models.Customer
{
    public class Order
    {
        public int Id { get; init; }

        // Foreign key property
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int TotalPrice { get; init; }


        // Foreign key properties
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public Address? Address { get; set; }
    }
}

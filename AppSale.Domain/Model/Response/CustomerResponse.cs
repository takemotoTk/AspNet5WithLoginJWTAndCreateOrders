namespace AppSale.Domain.Model.Response
{
    public class CustomerResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual AddressResponse Address { get; set; }
    }
}

namespace FluentValidationDemo.Models
{
    public class Customer
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public Address Address { get; set; }
    }
}

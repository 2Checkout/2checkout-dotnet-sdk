namespace TwoCheckout.Entities
{
    public class BillingDetails
    {
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Zip { get; set; }

        public BillingDetails(string address1, string city, string state, string countryCode, string email, string firstName, string lastName, string zip)
        {
            this.Address1 = address1;
            this.City = city;
            this.State = state;
            this.CountryCode = countryCode;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Zip = zip;
        }
    }
}

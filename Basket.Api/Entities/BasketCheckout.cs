namespace Basket.Api.Entities
{
    public class BasketCheckout
    {
        public string UserName { get; private set; }
        public decimal TotalPrice { get; private set; }
        
        //Address
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string AddressLine { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        
        //Payments
        public string CardName { get; private set; }
        public string CardNumber { get; private set; }
        public string Expiration { get; private set; }
        public string Cvv { get; private set; }
        public int PaymentMethod { get; private set; }

        public BasketCheckout() { }

        public BasketCheckout(string userName, decimal totalPrice, string firstName, string lastName, 
            string emailAddress, string addressLine, string country, string state, string zipCode, 
            string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            UserName = userName;
            TotalPrice = totalPrice;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipCode;
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            Cvv = cvv;
            PaymentMethod = paymentMethod;
        }

        public void SetUserName(string username) => UserName = username;
        public void SetTotalPrice(decimal totalPrice) => TotalPrice = totalPrice;
        public void SetFirstName(string firstName) => FirstName = firstName;
        public void SetLastName(string lastName) => LastName = lastName;
        public void SetEmailAddress(string emailAddress) => EmailAddress = emailAddress;
        public void SetAddressLine(string addressLine) => AddressLine = addressLine;
        public void SetCountry(string country) => Country = country;
        public void SetState(string state) => State = state;
        public void SetZipCode(string zipcode) => ZipCode = zipcode;
        public void SetCardName(string cardname) => CardName = cardname;
        public void SetCardNumber(string cardnumber) => CardName = cardnumber;
        public void SetExpiration(string expiration) => Expiration = expiration;
        public void SetCvv(string cvv) => Cvv = cvv;
        public void SetPaymentMethod(int paymentMethod) => PaymentMethod = paymentMethod;
    }
}

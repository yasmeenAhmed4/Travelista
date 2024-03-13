namespace Travelista.PayPalModels
{
    public class PayPalClient
    {
        public string Mode { get; set; }
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string BaseUrl => Mode == "Live" ? "https://api-m.paypal.com" : "https://api-m.sandbox.paypal.com";

        public PayPalClient(string clientid, string clientsecret, string mode)
        {
            ClientId = clientid;
            ClientSecret = clientsecret;
            Mode = mode;
        }
    }
}

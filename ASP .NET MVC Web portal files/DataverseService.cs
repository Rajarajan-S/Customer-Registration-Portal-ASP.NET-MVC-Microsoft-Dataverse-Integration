using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;

namespace CustomerRegistrationPortal.Services
{
    public class DataverseService
    {
        private readonly string connectionString =
        "AuthType=ClientSecret;" +
        "Url=https://orgURL;" +
        "ClientId=CLIENT_ID;" +
        "ClientSecret=CLIENT_SECRET;";

        public void CreateRegistrationRecord(
        string firstName,
        string lastName,
        string email,
        string phone,
        string address)
        {
            using (var service = new ServiceClient(connectionString))
            {
                Entity registration = new Entity("rr_webregistration");

                registration["rr_firstname"] = firstName;
                registration["rr_lastname"] = lastName;
                registration["rr_email"] = email;
                registration["rr_phone"] = phone;
                registration["rr_address"] = address;

                service.Create(registration);
            }
        }
    }
}

using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;

namespace CustomerRegistrationPortal.Services
{
    public class DataverseService
    {
        private readonly string connectionString =
        "AuthType=ClientSecret;" +
        "Url=https://orgeb829a97.crm8.dynamics.com;" +
        "ClientId=d125abd9-88ef-41a7-a0f2-444efecc79f2;" +
        "ClientSecret=MTz8Q~IO3K_zEWMmhQcPv1mIElCRvHEs4DW7Lade;";

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

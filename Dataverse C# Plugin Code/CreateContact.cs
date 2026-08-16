using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace DevPlugins
{
    public class CreateContact : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                var serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                var service = serviceFactory.CreateOrganizationService(context.UserId);

                if (context != null && context.InputParameters.Contains("Target"))
                {
                    var entity = (Entity)context.InputParameters["Target"];
                    var emailToCheck = entity.GetAttributeValue<string>("rr_email");

                    var query = new FetchExpression($"<fetch><entity name='contact'><attribute name='emailaddress1' /><filter><condition attribute='emailaddress1' operator='eq' value='{emailToCheck}' /></filter></entity></fetch>");

                    EntityCollection registrations = service.RetrieveMultiple(query);
                    if (registrations.Entities.Count > 0)
                    {
                        throw new InvalidPluginExecutionException($"Contact with same email already exists.");
                    }

                    Entity contact = new Entity("contact");

                    contact["firstname"] = entity.GetAttributeValue<string>("rr_firstname");
                    contact["lastname"] = entity.GetAttributeValue<string>("rr_lastname");
                    contact["emailaddress1"] = entity.GetAttributeValue<string>("rr_email");
                    contact["mobilephone"] = entity.GetAttributeValue<string>("rr_phone");
                    contact["address1_composite"] = entity.GetAttributeValue<string>("rr_address");

                    service.Create(contact);
                }
            }
            catch(Exception e)
            {
                throw new InvalidPluginExecutionException($"An error occurred in CreateContact plugin: {e.Message}", e);
            }
        }
    }
}

using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamics365Connect
{
     public class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService oServiceProxy;
            try
            {
                Console.WriteLine("Setting up Dynamics 365 connection");

                //Create the Dynamics 365 Connection:
                CrmServiceClient oMSCRMConn = new Microsoft.Xrm.Tooling.Connector.CrmServiceClient(
                    "AuthType=Office365;" +
                    "Username=<USERNAME>;" +
                    "Password=<PASSWORD>;" +
                    "URL=<URL>;");

                //Create the IOrganizationService:
                oServiceProxy = (IOrganizationService)oMSCRMConn.OrganizationWebProxyClient != null ?
                        (IOrganizationService)oMSCRMConn.OrganizationWebProxyClient :
                        (IOrganizationService)oMSCRMConn.OrganizationServiceProxy;

                Console.WriteLine("Validating Connection");

                if (oServiceProxy != null)
                {
                    //Get the current user ID:
                    Guid userid = ((WhoAmIResponse)oServiceProxy.Execute(new WhoAmIRequest())).UserId;

                    if (userid != Guid.Empty)
                    {
                        Console.WriteLine("Connection Successful!");
                    }
                }
                else
                {
                    Console.WriteLine("Connection failed...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.ToString());
            }

            Console.ReadKey();
        }
    }
    
}

using RollbarDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRollbarOfficialLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Rollbar.Init(new RollbarConfig
            {
                AccessToken = "<put token here>",
                Environment = "production"
            });



            try
            {
                JustDoIt5();
            }
            catch (System.Exception ex)
            {
                //Rollbar.Report(ex);
                LogException(ex);
            }
            Console.WriteLine("Press Enter");
            Console.ReadLine();

        }

        static private void JustDoIt5()
        {
            throw new System.NotImplementedException("oops 5");
        }

        static public void LogException(System.Exception ex)
        {
            string accessToken = "<put token here>";
            if (string.IsNullOrEmpty(accessToken))
                return;
            string environment = "test";
            var body = new Body(ex);
            var data = new Data(environment, body)
            {
                Level = ErrorLevel.Error,
                Server = new Server()
                {
                    Root = "C:\\MyProjects\\Test\\TestRollbarOfficialLibrary\\"
                }
            };
            var payload = new Payload(accessToken, data);
            var client = new RollbarClient(new RollbarConfig
            {
                AccessToken = accessToken,
                Environment = environment
            });
            client.PostItem(payload);
        }

    }
}

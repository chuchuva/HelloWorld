using Rollbar;
using System;

namespace TestRollbar
{
    class Program
    {
        static void Main(string[] args)
        {
            RollbarLocator.RollbarInstance.Configure(
                new RollbarConfig("<put token here>")
                {
                    Server = new Rollbar.DTOs.Server
                    {
                        Root = "D:\\Projects\\Test\\TestRollbar\\"
                    }
                });

            try
            {
                JustDoIt5();
            }
            catch (System.Exception ex)
            {
                RollbarLocator.RollbarInstance.Error(ex);
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
        }
    }
}

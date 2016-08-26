using MagniPiHelper.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MagniPiEmailWorker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[] 
            //{ 
            //    new MagniPiEmailService() 
            //};
            //ServiceBase.Run(ServicesToRun);

            try
            {
                MagniPiEmailService sv = new MagniPiEmailService();

                //sv.Send_Mail();

                sv.Send_Customer_Registration_Mail();

                sv.Send_Reminder_Email();

                sv.Send_Thank_You_Email();

            }
            catch (Exception ex)
            {
                Logger.Error("--Exception: " + ex.InnerException.ToString());
            }
        }
    }
}

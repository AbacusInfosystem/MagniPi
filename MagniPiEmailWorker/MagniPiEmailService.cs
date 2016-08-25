using MagniPiHelper.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Transactions;

namespace MagniPiEmailWorker
{
    partial class MagniPiEmailService : ServiceBase
    {
        private Timer schedulertimer;

        public MagniPiEmailService()
        {
            //Logger.Debug("Inside MDMToolWorker Constructor");
            InitializeComponent();

            schedulertimer = new Timer();
            schedulertimer.Enabled = true;

            int ServiceTimerInMinutes = Convert.ToInt32(ConfigurationManager.AppSettings["ServiceTimerInMinutes"]);
            long ServiceTimerInMiliSeconds = ServiceTimerInMinutes * 1000 * 60;
            schedulertimer.Interval = Convert.ToDouble(ServiceTimerInMiliSeconds);
            schedulertimer.Elapsed += this.Ready;
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        public void Ready(object sender, ElapsedEventArgs e)
        {
            Logger.Debug("Inside Ready");

            schedulertimer.Enabled = false;

            Send_Mail();

            //Send_Reminder_Emails();

            //Send_Escalation_Emails();

            schedulertimer.Enabled = true;

            Logger.Debug("Ready Ends");
        }


        public void Send_Mail()
        {
            try
            {
                Logger.Debug("Inside send mail");

                //YOU WOULD NEED TO WRITE A METHOD TO GET EMAILS FROM DB TO SEND.
                //List<SendEmailInfo> ListOfSendEmailInfo = _requestRepo.Get_Mails_To_Send();

                //I HAVE ALREADY ADDED SENDMAILINFO IN MAGNIPIEBUSINESSENTITIES PROJECT.

                //foreach (var SendEmailInfo in ListOfSendEmailInfo)
                //{
                    /* Create the TransactionScope to execute the commands, guaranteeing
                       that both commands can commit or roll back as a single unit of work. */
                    try
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            CommonMethods.SendMail(SendEmailInfo.To_Email_Id, "", SendEmailInfo.Subject, SendEmailInfo.Body.ToString());

                            Logger.Debug("Email Sent To : " + SendEmailInfo.To_Email_Id);

                            //YOU WOULD NEED TO WRITE A METHOD TO UPDATE EMAIL HAS BEEN SENT SUCCESSFULLY FLAG IN DB.
                            //_requestRepo.Update_Send_Mail_Flag(SendEmailInfo.ID);

                            Logger.Debug("Mail sent flag is set :  " + SendEmailInfo.ID);

                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("System Error : " + ex.InnerException);
                        Logger.Error("For input parameters : ");
                        Logger.Error("\t The send_email table Id : " + SendEmailInfo.ID);
                        Logger.Error("\t Action : " + SendEmailInfo.Action);
                        Logger.Error("\t To e-mail Id : " + SendEmailInfo.To_Email_Id);
                        Logger.Error("\t Subject : " + SendEmailInfo.Subject);
                        Logger.Error("\t Mail Created On : " + SendEmailInfo.Created_On);
                        Logger.Error("\t Mail Created By : " + SendEmailInfo.Created_By);
                    }
                //}
            }
            catch (Exception ex)
            {
                Logger.Error("Error at MagniPiEmailService service in Send_Mail method - " + ex.InnerException);
            }
        }
    }
}

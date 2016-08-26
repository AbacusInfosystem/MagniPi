using MagniPiBusinessEntities.Customer;
using MagniPiBusinessEntities.Worker;
using MagniPiDataAccess.Common;
using MagniPiDataAccess.SendEmail;
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
        SendEmailRepo _sendemailRepo;

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

            _sendemailRepo = new SendEmailRepo();
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

            //Send_Mail();
            Send_Customer_Registration_Mail();

            Send_Thank_You_Email();

            Send_Reminder_Email();

            schedulertimer.Enabled = true;

            Logger.Debug("Ready Ends");
        }


        //public void Send_Mail()
        public void Send_Customer_Registration_Mail()
        {
            
            try
            {
                Logger.Debug("Inside send mail");

                //YOU WOULD NEED TO WRITE A METHOD TO GET EMAILS FROM DB TO SEND.
                List<CustomerInfo> customers = _sendemailRepo.Get_Customers_To_Send_Registration_Mail();

                List<SendEmailInfo> ListOfSendEmailInfo = Get_Customer_Registration_Email(customers);

                foreach (var SendEmailInfo in ListOfSendEmailInfo)
                {
                    /* Create the TransactionScope to execute the commands, guaranteeing
                       that both commands can commit or roll back as a single unit of work. */
                    try
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (!string.IsNullOrEmpty(SendEmailInfo.To_Email_Id))
                            {
                                CommonMethods.SendMail(SendEmailInfo);

                                Logger.Debug("Email Sent To : " + SendEmailInfo.To_Email_Id);

                                //YOU WOULD NEED TO WRITE A METHOD TO UPDATE EMAIL HAS BEEN SENT SUCCESSFULLY FLAG IN DB.

                                _sendemailRepo.Update_Registration_Mail_Send_Flag(SendEmailInfo.ID);

                                Logger.Debug("Mail sent flag is set :  " + SendEmailInfo.ID);
                            }
                            
                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("System Error : " + ex.InnerException);
                        Logger.Error("For input parameters : ");
                        Logger.Error("\t The send_email table Id : " + SendEmailInfo.ID);
                        Logger.Error("\t To e-mail Id : " + SendEmailInfo.To_Email_Id);
                        Logger.Error("\t Subject : " + SendEmailInfo.Subject);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error at Send_Customer_Registration_Mail service in Send_Mail method - " + ex.InnerException);
            }
        }

        public void Send_Thank_You_Email()
        {
            
            try
            {
                Logger.Debug("Inside send mail");

                //YOU WOULD NEED TO WRITE A METHOD TO GET EMAILS FROM DB TO SEND.
                List<MemberEventInfo> eventmembers = _sendemailRepo.Get_Members_To_Send_Thank_You_Mail();

                List<SendEmailInfo> ListOfSendEmailInfo = Get_Thank_You_Email(eventmembers);

                //I HAVE ALREADY ADDED SENDMAILINFO IN MAGNIPIEBUSINESSENTITIES PROJECT.

                foreach (var SendEmailInfo in ListOfSendEmailInfo)
                {
                    /* Create the TransactionScope to execute the commands, guaranteeing
                       that both commands can commit or roll back as a single unit of work. */
                    try
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (!string.IsNullOrEmpty(SendEmailInfo.To_Email_Id))
                            {
                                CommonMethods.SendMail(SendEmailInfo);

                                Logger.Debug("Email Sent To : " + SendEmailInfo.To_Email_Id);

                                //YOU WOULD NEED TO WRITE A METHOD TO UPDATE EMAIL HAS BEEN SENT SUCCESSFULLY FLAG IN DB.

                                _sendemailRepo.Update_Thank_You_Mail_Send_Flag(SendEmailInfo.ID);

                                Logger.Debug("Mail sent flag is set :  " + SendEmailInfo.ID);
                            }
                            
                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("System Error : " + ex.InnerException);
                        Logger.Error("For input parameters : ");
                        Logger.Error("\t The send_email table Id : " + SendEmailInfo.ID);
                        Logger.Error("\t To e-mail Id : " + SendEmailInfo.To_Email_Id);
                        Logger.Error("\t Subject : " + SendEmailInfo.Subject);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error at Send_Thank_You_Email service in Send_Mail method - " + ex.InnerException);
            }
        }

        public void Send_Reminder_Email()
        {
           
            try
            {
                Logger.Debug("Inside send mail");

                //YOU WOULD NEED TO WRITE A METHOD TO GET EMAILS FROM DB TO SEND.
                List<MemberEventInfo> eventmembers = _sendemailRepo.Get_Members_To_Send_Reminder_Mail();

                List<SendEmailInfo> ListOfSendEmailInfo = Get_Reminder_Email(eventmembers);

                //I HAVE ALREADY ADDED SENDMAILINFO IN MAGNIPIEBUSINESSENTITIES PROJECT.

                foreach (var SendEmailInfo in ListOfSendEmailInfo)
                {
                    /* Create the TransactionScope to execute the commands, guaranteeing
                       that both commands can commit or roll back as a single unit of work. */
                    try
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            if (!string.IsNullOrEmpty(SendEmailInfo.To_Email_Id))
                            {
                                CommonMethods.SendMail(SendEmailInfo);

                                Logger.Debug("Email Sent To : " + SendEmailInfo.To_Email_Id);

                                //YOU WOULD NEED TO WRITE A METHOD TO UPDATE EMAIL HAS BEEN SENT SUCCESSFULLY FLAG IN DB.

                                _sendemailRepo.Update_Reminder_Mail_Send_Flag(SendEmailInfo.ID);

                                Logger.Debug("Mail sent flag is set :  " + SendEmailInfo.ID);
                            }
                            
                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("System Error : " + ex.InnerException);
                        Logger.Error("For input parameters : ");
                        Logger.Error("\t The send_email table Id : " + SendEmailInfo.ID);
                        Logger.Error("\t To e-mail Id : " + SendEmailInfo.To_Email_Id);
                        Logger.Error("\t Subject : " + SendEmailInfo.Subject);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error at Send_Reminder_Email service in Send_Mail method - " + ex.InnerException);
            }
        }


        private List<SendEmailInfo> Get_Customer_Registration_Email(List<CustomerInfo> customers)
        {
            List<SendEmailInfo> sendEmails = new List<SendEmailInfo>();

            foreach (var item in customers)
            {
                SendEmailInfo emailData = new SendEmailInfo();

                emailData.ID = item.Customer_Id;
                emailData.To_Email_Id = item.Email;
                emailData.Subject = "Welcome Email";
                
                StringBuilder htmlString = new StringBuilder();

                htmlString.Append("<p>");
                htmlString.Append("Hi " + item.Customer_Name);
                htmlString.Append("</p>");

                htmlString.Append("<p>");
                htmlString.Append("You are succefully registered.");
                htmlString.Append("</p>");

                htmlString.Append("<br />");
                htmlString.Append("<p>");
                htmlString.Append("<b>Regards :</b> ");
                htmlString.Append("</p>");

                emailData.Body = htmlString.ToString();

                sendEmails.Add(emailData);
            }

            return sendEmails;
        }

        private List<SendEmailInfo> Get_Thank_You_Email(List<MemberEventInfo> eventmembers)
        {
            List<SendEmailInfo> sendEmails = new List<SendEmailInfo>();

            foreach (var item in eventmembers)
            {
                SendEmailInfo emailData = new SendEmailInfo();

                emailData.ID = item.Member_Event_Mapping_Id;
                emailData.To_Email_Id = item.Email;
                emailData.Subject = "Thank you Email";
               
                StringBuilder htmlString = new StringBuilder();

                htmlString.Append("<p>");
                htmlString.Append("Hi " + item.Member_Name);
                htmlString.Append("</p>");

                htmlString.Append("<p>");
                htmlString.Append("Thank you for attending event " + item.Event_Name + ".");
                htmlString.Append("</p>");

                htmlString.Append("<br />");
                htmlString.Append("<p>");
                htmlString.Append("<b>Regards :</b> ");
                htmlString.Append("</p>");

                emailData.Body = htmlString.ToString();

                sendEmails.Add(emailData);
            }

            return sendEmails;
        }

        private List<SendEmailInfo> Get_Reminder_Email(List<MemberEventInfo> eventmembers)
        {
            List<SendEmailInfo> sendEmails = new List<SendEmailInfo>();

            foreach (var item in eventmembers)
            {
                SendEmailInfo emailData = new SendEmailInfo();

                emailData.ID = item.Member_Event_Mapping_Id;
                emailData.To_Email_Id = item.Email;
                emailData.Subject = "Reminder Email";

                StringBuilder htmlString = new StringBuilder();

                htmlString.Append("<p>");
                htmlString.Append("Hi " + item.Member_Name);
                htmlString.Append("</p>");

                htmlString.Append("<p>");
                htmlString.Append("Thank you for registering the <b>" + item.Event_Name + "</b> .");
                htmlString.Append("We are going to conducting this " + item.Event_Type_Str + " on tomorrow<b> at "+item.Location+" .");
                htmlString.Append("</p>");

                htmlString.Append("<p>");
                htmlString.Append("<b>About Event :</b> " + item.Description);
                htmlString.Append("</p>");

                htmlString.Append("<br />");
                htmlString.Append("<p>");
                htmlString.Append("<b>Regards :</b> ");
                htmlString.Append("</p>");

                emailData.Body = htmlString.ToString();

                sendEmails.Add(emailData);
            }

            return sendEmails;
        }



    }
}

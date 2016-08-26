using MagniPiBusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MagniPiRepo.Common
{
    public static class CommonMethods
    {
        public static List<DataRow> GetRows(DataTable dt, ref PaginationInfo pager)
        {
            List<DataRow> drList = new List<DataRow>();

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                if (pager.IsPagingRequired)
                {
                    drList = drList.Skip(pager.CurrentPage * pager.PageSize).Take(pager.PageSize).ToList();
                }

                pager.TotalRecords = count;

                int pages = (pager.TotalRecords + pager.PageSize - 1) / pager.PageSize;

                pager.TotalPages = pages;
            }

            return drList;
        }


        public static void SendMail(string to_Email_Id, string cc_Email_Id, string subject, string body)
        {
            MailMessage mail = new MailMessage();

            SmtpClient SmtpServer = new SmtpClient();

            if (!string.IsNullOrEmpty(to_Email_Id))
            {
                if (to_Email_Id.Contains(','))
                {
                    foreach (var item in to_Email_Id.Split(','))
                    {
                        mail.To.Add(item);
                    }
                }
                else
                {
                    mail.To.Add(to_Email_Id);
                }
            }

            if (!string.IsNullOrEmpty(cc_Email_Id))
            {
                if (cc_Email_Id.Contains(','))
                {
                    foreach (var item in cc_Email_Id.Split(','))
                    {
                        mail.CC.Add(item);
                    }
                }
                else
                {
                    mail.CC.Add(cc_Email_Id);
                }
            }

            mail.Subject = subject;

            mail.Body = body;

            mail.IsBodyHtml = true;

            SmtpServer.Send(mail);
        }



    }
}

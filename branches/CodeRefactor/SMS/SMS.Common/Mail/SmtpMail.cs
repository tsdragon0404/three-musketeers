﻿using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace SMS.Common.Mail
{
    public class SmtpMail
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public string Error { get; private set; }

        public bool Send()
        {
            try
            {
                var mail = new MailMessage();
                To.ForEach(x => mail.To.Add(x));
                mail.From = new MailAddress(From);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient
                               {
                                   Host = Storage.SystemInformation.SystemInfos.Data[Constant.ConstKey.SystemInfo_SmtpHost],
                                   Port = Int32.Parse(Storage.SystemInformation.SystemInfos.Data[Constant.ConstKey.SystemInfo_SmtpPort]),
                                   UseDefaultCredentials = false,
                                   Credentials = new System.Net.NetworkCredential(
                                       Storage.SystemInformation.SystemInfos.Data[Constant.ConstKey.SystemInfo_SmtpUser],
                                       Storage.SystemInformation.SystemInfos.Data[Constant.ConstKey.SystemInfo_SmtpPass]),
                                   EnableSsl = true
                               };
                smtp.Send(mail);
            }
            catch(Exception e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        } 
    }
}
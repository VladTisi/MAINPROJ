using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace MAINPROJ
{
    public static class Class1
    {
        public static void sendMail(string subject,string body,string to)
        {
            var from = "vlad.tisianu@totalsoft.ro";
            var username = "vlad.tisianu@totalsoft.ro"; 
            var password = "Thew0lf2234*"; 
            var host = "mailer14.totalsoft.local";
            var port = 587;

            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            client.Send(from, to, subject, body);

            Console.WriteLine("Email sent");
        }
    }
}

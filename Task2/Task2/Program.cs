using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using Task2.obj.model;

namespace Task2
{
    class Task
    {
        static void Main()
        {
            StreamReader s = new StreamReader("file.json");
            string json = s.ReadToEnd();
            Item item = JsonSerializer.Deserialize<Item>(json);
            sendToMail(getMessage(item));


        }

        static void sendToMail(String bodyMessage)
        {
            MailAddress fromMailAddress = new MailAddress("eelse@internet.ru", "else");
            MailAddress toMailAddress = new MailAddress("sidorenkoartem1@gmail.com");
            MailMessage message = new MailMessage(fromMailAddress, toMailAddress);

            message.Subject = "Subject";
            message.Body = bodyMessage;
            message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("eelse@internet.ru", "iGt2nf5wuywDReHs9RBP");
            smtp.EnableSsl = true;
            smtp.Send(message);
        }

        static String getMessage(Item item)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<h2>outage_start = " + item.outageStart + " </h2>");
            builder.Append("<h2>affected_areas: </h2>");
            item.affectedAreas.ForEach(el =>
            {
                builder.Append("<h3>area_name = " + el.areaName + ", affected_customers = " + el.affectedCustomers + ", estimated_recovery_time = " + el.estimatedRecoveryTime + "</h3>");
            });
            return builder.ToString();
        }
    }
}

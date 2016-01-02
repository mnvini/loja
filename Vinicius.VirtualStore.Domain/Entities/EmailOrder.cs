using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Vinicius.VirtualStore.Domain.Entities
{
    public class EmailOrder
    {
        private readonly ConfigEmails _configEmails;

        public EmailOrder(ConfigEmails configEmails)
        {
            this._configEmails = configEmails;
        }

        public void ProcessOrder(Cart cart, Order order)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _configEmails.UseSsl;
                smtpClient.Host = _configEmails.ServerSmtp;
                smtpClient.Port = _configEmails.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_configEmails.User, _configEmails.ServerSmtp);
                if (_configEmails.WriteFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _configEmails.FolderFiles;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("New Order:")
                    .AppendLine("----------")
                    .AppendLine("Items");
                foreach (var item in cart.CartItems)
                {
                    var subtotal = item.Products.Price*item.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", item.Quantity, item.Products.Name, subtotal);
                }
                body.AppendFormat("Value Total of Order: {0:c}", cart.TotalValue())
                    .AppendLine("---------------------------")
                    .AppendLine("Send To:")
                    .AppendLine(order.ClientName)
                    .AppendLine(order.Email)
                    .AppendLine(order.Address ?? "")
                    .AppendLine(order.City ?? "")
                    .AppendLine(order.Complement ?? "")
                    .AppendLine("--------------------")
                    .AppendFormat("Gift? {0}", order.GiftWrap ? "Yes" : "No");

                MailMessage mailMessage = new MailMessage(
                    _configEmails.From,
                    _configEmails.To, 
                    "New Order" , 
                     body.ToString());

                if (_configEmails.WriteFile )
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpClient.Send(mailMessage);

            }
        }
    }
}

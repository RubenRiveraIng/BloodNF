using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;
using model=Model.Email;
namespace Util
{
    public class SendMail
    {
        private MimeMessage _message;
        private MailboxAddress _from;
        private MailboxAddress _to;
        private BodyBuilder _bodyBuilder;
        private SmtpClient _client;
        public SendMail(model.SendMail dataMail)
        {
            this._message = new MimeMessage();
            this._from = new MailboxAddress(dataMail.nameFrom, dataMail.emailFrom);
            this._message.From.Add(this._from);
            this._to = new MailboxAddress(dataMail.nameTo,dataMail.emailTo);
            this._message.To.Add(this._to);
            this._message.Subject = dataMail.subject;
            this._bodyBuilder = new BodyBuilder();
            this._client = new SmtpClient();
            this._client.Connect(dataMail.smtpAddress, dataMail.smtpPort, true);
            this._client.Authenticate(dataMail.emailUserAuth, dataMail.passUserAuth);
        }

        public string sendMailResetPassword()
        {
            string newPass = System.Web.Security.Membership.GeneratePassword(10,5);
            this._bodyBuilder.HtmlBody = @"<p>Usted a solicitado un cambio de contraseña
                                               a traves de la aplicación, su nueva contraseña es : </p><br/>
                                              <b>"+ newPass + "</b>";
            //this._bodyBuilder.TextBody = @"<p>Usted a solicitado un cambio de contraseña
            //                                   a traves de la aplicación, para poder realizar este proceso,
            //                                   por favor ingrese </p><a href='" + token + "'>aqui</a>";
            this._message.Body = this._bodyBuilder.ToMessageBody();
            this._client.Send(this._message);
            this._client.Disconnect(true);
            this._client.Dispose();
            return newPass;
        }
    }
}

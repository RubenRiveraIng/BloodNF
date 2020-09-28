using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Email
{
    public class SendMail
    {
        public string nameFrom { get; set; }
        public string emailFrom { get; set; }
        public string nameTo { get; set; }
        public string emailTo { get; set; }
        public string subject { get; set; }
        public string smtpAddress { get; set; }
        public int smtpPort { get; set; }
        public string emailUserAuth { get; set; }
        public string passUserAuth { get; set; }
    }
}

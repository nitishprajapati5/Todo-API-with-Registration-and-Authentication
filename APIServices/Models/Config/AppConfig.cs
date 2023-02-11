using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Models.Config
{
    public class AppConfig
    {
        public MailServiceConfig MailServiceConfig { get; set; }
    }

    public class MailServiceConfig
    {
        public string? Mail { get; set; }
        public string? DisplayName { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }

    }
}

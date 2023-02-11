using APIServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Interfaces
{
    public interface IMailService
    {
        Task SendMailAsync(MailRequest request);
    }
}

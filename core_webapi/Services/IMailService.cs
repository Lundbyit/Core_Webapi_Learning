using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_webapi.Services
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}

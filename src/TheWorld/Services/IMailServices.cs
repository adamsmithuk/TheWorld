using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.Services
{
    public interface IMailServices
    {
        void Sendmail(string to, string from, string subject, string body);
    }
}

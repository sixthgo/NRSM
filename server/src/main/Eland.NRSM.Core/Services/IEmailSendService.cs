using Eland.NRSM.Core.Domain;
using Formular.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eland.NRSM.Core.Services
{
    public interface IEmailSendService : IGenericService<Message>
    {
        string SEND_MAIL(string sLoginId, string sPassword, string sSubject, string sBody, string sRecipients, string sCcRecipients, string sHiddenCc);
    }
}

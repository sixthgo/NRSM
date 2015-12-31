using Eland.NRSM.Core.Services;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;

namespace Eland.NRSM.Template.Services
{
    public class EmailSendService : GenericService<Domain.Message>, IEmailSendService
    {
        MailWebService.WS_MailSoapClient _WSMail;

        public MailWebService.WS_MailSoapClient WSMail
        {
            get
            {
                if (_WSMail == null) _WSMail = new MailWebService.WS_MailSoapClient("WS_MailSoap");
                return _WSMail;
            }
        }

        public string SEND_MAIL(string sLoginId, string sPassword, string sSubject, string sBody, string sRecipients, string sCcRecipients, string sHiddenCc)
        {
            string sResultString = string.Empty;

            try
            {
                sResultString = WSMail.SendMail(sLoginId, sPassword, sSubject, sBody, sRecipients, sCcRecipients, sHiddenCc);
            }
            catch (Exception ex)
            {
                sResultString = "메일발송 중 오류가 발생하였습니다.(" + ex.Message + ")";
            }

            return sResultString;
        }
    }
}

using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Eland.NRSM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SendBarCodeEmailApiController : ApiController
    {

        IEmailSendService EmailSendService { get; set; }

        public Message Get(string barcode, string strSubject, string mLinkUserId)
        {
            string result = string.Empty;
            Message dto = new Message();
            try
            {
                barcode = strSubject + "<br/>" + barcode;

                //用户名和密码可能会更换,导致无法发送邮件.
                string logindID = "m_service";
                string password = "m_service";
                //string strRecipients = Session["loginID"].ToString() + "@eland.co.kr";
                string strRecipients = mLinkUserId + "@eland.co.kr";
                string sResultString = EmailSendService.SEND_MAIL(logindID, password, strSubject, barcode.Replace(",", "<br/>"), strRecipients, "", "");

                if (sResultString == "SUCCESS")
                {
                    dto.Flag = "SUCCESS";
                    dto.ReturnMessage = "주소로 메일이 전송되었습니다.";
                }
                else
                {
                    dto.Flag = "failure";
                    dto.ReturnMessage = "메일 전송에 실패했습니다.";
                }
            }
            catch (Exception ex)
            {

                dto.Flag = "failure";
                dto.ReturnMessage = "메일 전송에 실패했습니다.(" + ex.Message + ")";
            }

            return dto;
        }  
    }
}

using Eland.NRSM.Core.Services;
using Eland.NRSM.Template.Dao;
using Formular.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain = Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Domain;
using System.Web.Script.Serialization;

namespace Eland.NRSM.Template.Services
{
    public class FloorPlanService : IFloorPlanService
    {
        public List<FloorPlanData> SearchChangeHistoryDate(string werks, string floor, string fromDate, string toDate)
        {
            List<FloorPlanData> changeHistoryData = new List<FloorPlanData>();

            Encoding enc = Encoding.GetEncoding("UTF-8");
            WebRequest myWebRequest = WebRequest.Create("http://gyro.eland.co.kr/service/index3");
            myWebRequest.ContentType = "application/json; charset=utf-8";
            myWebRequest.Headers.Set("Werks", werks);
            myWebRequest.Headers.Set("Floor", floor);
            myWebRequest.Headers.Set("FROM", fromDate);
            myWebRequest.Headers.Set("TO", toDate);

            ////WebResponse myWebResponse = myWebRequest.GetResponse();

            ////Stream st = myWebResponse.GetResponseStream();
            ////StreamReader sr = new StreamReader(st, enc);
            ////string html = sr.ReadToEnd();
            ////sr.Close();
            ////st.Close();

            WebResponse response = myWebRequest.GetResponse();

            //string json = @"[{""changeDate"":""20140611""},{""changeDate"":""20140608""},{""changeDate"":""20140607""},{""changeDate"":""20140606""},{""changeDate"":""20140605""}]";

            string json;

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            var serializer = new JavaScriptSerializer();

            var changeDates = serializer.Deserialize<List<FloorPlanData>>(json);

            foreach (var a in changeDates)
            {
                string year = a.changeDate.Substring(0, 4);
                string strDate = a.changeDate.Substring(4);

                string date = strDate.Substring(0, 2) + "월" + strDate.Substring(2) + "일";


                changeHistoryData.Add(new FloorPlanData()
                {
                    id = a.changeDate,
                    changeDate = a.changeDate,
                    year = year,
                    name = date,
                    check = false,
                    diable = false
                });
            }


            return changeHistoryData;
        }

        public List<ChangeHistoryData> SearchChangeHistoryData(string werks, string floor, string dates)
        {

            string[] date = dates.Split('|');

            List<ChangeHistoryData> data = new List<ChangeHistoryData>();

            for (int i = 0; i < date.Length; i++)
            {
                Encoding enc = Encoding.GetEncoding("UTF-8");
                WebRequest myWebRequest = WebRequest.Create("http://gyro.eland.co.kr/service/index3");
                myWebRequest.Headers.Set("Werks", werks);
                myWebRequest.Headers.Set("Floor", floor);
                myWebRequest.Headers.Set("REQDT", date[i]);

                WebResponse myWebResponse = myWebRequest.GetResponse();

                Stream st = myWebResponse.GetResponseStream();
                StreamReader sr = new StreamReader(st, enc);
                string html = sr.ReadToEnd();
                sr.Close();
                st.Close();

                data.Add(new ChangeHistoryData()
                {
                    ChangeData = html
                });

            }
            return data;
        }

        public List<FloorPlanFile> GetFloorPlanFile(string werks, string floor)
        {
            string today = DateTime.Now.ToString("yyyyMMdd");            
            //string today = "20140708";
            List<FloorPlanFile> result = new List<FloorPlanFile>();

            Encoding enc = Encoding.GetEncoding("UTF-8");
            WebRequest myWebRequest = WebRequest.Create("http://gyro.eland.co.kr/service/index3");
            myWebRequest.Headers.Set("Werks", werks);
            myWebRequest.Headers.Set("Floor", floor);
            myWebRequest.Headers.Set("REQDT", today);

            WebResponse myWebResponse = myWebRequest.GetResponse();

            Stream st = myWebResponse.GetResponseStream();
            StreamReader sr = new StreamReader(st, enc);
            string html = sr.ReadToEnd();
            sr.Close();
            st.Close();

            result.Add(new FloorPlanFile()
            {
                floorplanFileData = html
            });

            return result;
        }
    }
}

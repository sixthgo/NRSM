using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Eland.NRSM.Core.Domain;
using Eland.NRSM.Core.Services;
using Formular.BaaS.Service;
using Formular.BaaS.Domain;
using System.Web.Http.Cors;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using System.Text;

namespace Eland.NRSM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FloorPlanController : ApiController
    {
        IFloorPlanService FloorPlanService { get; set; }
        IFloorPlanCompareService FloorPlanCompareService { get; set; }

        private string separate = "_";

        // GET api/floorplan
        public IEnumerable<FloorPlanData> Get()
        {
            return FloorPlanService.SearchChangeHistoryDate("8202", "02", "20140601", "20140630");
        }

        public IEnumerable<FloorPlanData> Get(string werks, string floor, string fromDate, string toDate)
        {
            toDate = DateTime.Now.ToString("yyyyMMdd");
            fromDate = DateTime.Now.AddYears(-1).ToString("yyyy0101");
            return FloorPlanService.SearchChangeHistoryDate(werks, floor, fromDate, toDate);
        }

        public IEnumerable<ChangeHistoryData> Get(string werks, string floor, string selectDates, string menu, string personNumber)
        {
            //return FloorPlanService.SearchChangeHistoryData(werks, floor, selectDates);
            string physicalPath = HttpContext.Current.Request.PhysicalApplicationPath;

            int count = 0;
            List<ChangeHistoryData> result = FloorPlanService.SearchChangeHistoryData(werks, floor, selectDates);

            string[] date = selectDates.Split('|');

            string[] downloadFile = new string[result.Count];

            string checkFile = physicalPath + @"Content/changeData/" + werks + "/" + floor + "/" + werks + separate + floor + separate + date[0] + separate + date[1] + "_first.html";

            if (!File.Exists(checkFile))
            {
                List<FloorPlanHistoryCompare> compareResult = new List<FloorPlanHistoryCompare>();

                compareResult = FloorPlanCompareService.QueryHistoryIn(werks, floor, date[0], date[1]);

                foreach (ChangeHistoryData data in result)
                {
                    string filePath = physicalPath + @"Content/changeData/" + werks + "/" + floor + "/";

                    DirectoryInfo di = new DirectoryInfo(filePath);
                    if (!di.Exists)
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string fileName;
                    string returnPath;
                    if (count == 0)
                    {
                        fileName = filePath + werks + separate + floor + separate + date[0] + separate + date[1] + "_first.html";
                        returnPath = @"Content/changeData/" + werks + "/" + floor + "/" + werks + separate + floor + separate + date[0] + separate + date[1] + "_first.html";
                    }
                    else
                    {
                        fileName = filePath + werks + separate + floor + separate + date[0] + separate + date[1] + "_second.html";
                        returnPath = @"Content/changeData/" + werks + "/" + floor + "/" + werks + separate + floor + separate + date[0] + separate + date[1] + "_second.html";
                    }

                    downloadFile[count] = returnPath;

                    if (!File.Exists(fileName))
                    {
                        string aLine, aParagraph = null;

                        string svgFile = data.ChangeData;
                        string regText = "<text";

                        StringReader strReader = new StringReader(svgFile);
                        while (true)
                        {
                            aLine = strReader.ReadLine();
                            if (aLine != null)
                            {
                                if (aLine.Contains(regText))
                                {
                                    aParagraph += aLine.Replace(">", " fill-opacity=\"0\">\n");
                                }
                                else
                                {
                                    aParagraph += aLine + "\n";
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        string changeSvgFile = aParagraph;

                        Regex rTsapn = new Regex("<tspan id=\"(.*?)>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

                        Match mTsapn;
                        List<string> listLayoutCode = new List<string>();
                        string selectedStore = "";
                        string xCoordinate = "";
                        string yCoordinate = "";
                        string showText = "";

                        for (mTsapn = rTsapn.Match(changeSvgFile); mTsapn.Success; mTsapn = mTsapn.NextMatch())
                        {
                            string[] val = mTsapn.Groups[1].Value.Split('_');

                            string coordinate = val[1];

                            if (!selectedStore.Equals(val[0]))
                            {
                                Regex rXCoordinate = new Regex("x=\"(.*?)\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                                Match mXCoordinate;
                                for (mXCoordinate = rXCoordinate.Match(coordinate); mXCoordinate.Success; mXCoordinate = mXCoordinate.NextMatch())
                                {
                                    xCoordinate = mXCoordinate.Groups[1].Value;
                                }
                                Regex rYCoordinate = new Regex("y=\"(.*?)\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                                Match mYCoordinate;
                                for (mYCoordinate = rYCoordinate.Match(coordinate); mYCoordinate.Success; mYCoordinate = mYCoordinate.NextMatch())
                                {
                                    yCoordinate = mYCoordinate.Groups[1].Value;
                                }
                                for (int j = 0; j < compareResult.Count; j++)
                                {
                                    if (count == 0)
                                    {
                                        if (compareResult[j].FirstFloorPlan != null)
                                        {
                                            if (compareResult[j].FirstFloorPlan.LayoutCode.Equals(val[0]))
                                            {
                                                float y = float.Parse(yCoordinate);
                                                y = y + 13;
                                                listLayoutCode.Add(compareResult[j].FirstFloorPlan.LayoutName);

                                                showText += "<text id=\"" + val[0] + "\" fill=\"Black\" stroke-width=\"0.2\" font-family=\"Gulim\" font-size=\"12\">\n";
                                                showText += "<tspan x=\"" + float.Parse(xCoordinate) + "\" y=\"" + float.Parse(yCoordinate) + "\">" + compareResult[j].FirstFloorPlan.LayoutName + "</tspan>\n";
                                                showText += "<tspan x=\"" + float.Parse(xCoordinate) + "\" y=\"" + y + "\">" + compareResult[j].FirstFloorPlan.NSpaceSize + "평</tspan>\n";
                                                selectedStore = val[0];
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (compareResult[j].SeondFloorPlan != null)
                                        {
                                            if (compareResult[j].SeondFloorPlan.LayoutCode.Equals(val[0]))
                                            {
                                                float y = float.Parse(yCoordinate);
                                                y = y + 13;
                                                listLayoutCode.Add(compareResult[j].SeondFloorPlan.LayoutName);

                                                showText += "<text id=\"" + val[0] + "\" fill=\"Black\" stroke-width=\"0.2\" font-family=\"Gulim\" font-size=\"12\">\n";
                                                showText += "<tspan x=\"" + float.Parse(xCoordinate) + "\" y=\"" + float.Parse(yCoordinate) + "\">" + compareResult[j].SeondFloorPlan.LayoutName + "</tspan>\n";
                                                showText += "<tspan x=\"" + float.Parse(xCoordinate) + "\" y=\"" + y + "\">" + compareResult[j].SeondFloorPlan.NSpaceSize + "평</tspan>\n";
                                                selectedStore = val[0];
                                            }
                                        }
                                    }

                                    if (compareResult[j].CompareFloorPlan != null)
                                    {
                                        if (count == 0)
                                        {
                                            if (compareResult[j].CompareFloorPlan.Gubun.Equals("A") &&
                                        compareResult[j].CompareFloorPlan.LayoutCode.Equals(val[0]))
                                            {
                                                float y = float.Parse(yCoordinate);
                                                y = y + 26;

                                                decimal value = compareResult[j].CompareFloorPlan.Value;

                                                NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
                                                nfi = (NumberFormatInfo)nfi.Clone();
                                                nfi.CurrencySymbol = "";
                                                string totalValue = string.Format(nfi, "{0:C}", compareResult[j].CompareFloorPlan.Value);

                                                showText += "<tspan x=\"" + float.Parse(xCoordinate) + "\" y=\"" + y + "\">" + totalValue + "원</tspan>\n";

                                                string line, paragraph = "";
                                                string reg = "<polygon id=\"" + val[0] + "\" style=\"";
                                                StringReader reader = new StringReader(changeSvgFile);
                                                while (true)
                                                {
                                                    line = reader.ReadLine();
                                                    if (line != null)
                                                    {
                                                        if (line.Contains(reg))
                                                        {
                                                            paragraph += line.Replace("#FFF7E0", "rgb(255,0,0);fill-opacity:0.5;");
                                                        }
                                                        else
                                                        {
                                                            paragraph += line + "\n";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                changeSvgFile = paragraph;

                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (compareResult[j].CompareFloorPlan.Gubun.Equals("B") &&
                                        compareResult[j].CompareFloorPlan.LayoutCode.Equals(val[0]))
                                            {
                                                float y = float.Parse(yCoordinate);
                                                y = y + 26;

                                                decimal value = compareResult[j].CompareFloorPlan.Value;

                                                NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
                                                nfi = (NumberFormatInfo)nfi.Clone();
                                                nfi.CurrencySymbol = "";
                                                string totalValue = string.Format(nfi, "{0:C}", compareResult[j].CompareFloorPlan.Value);

                                                showText += "<tspan x=\"" + float.Parse(xCoordinate) + "\" y=\"" + y + "\">" + totalValue + "원</tspan>\n";

                                                string line, paragraph = "";
                                                string reg = "<polygon id=\"" + val[0] + "\" style=\"";
                                                StringReader reader = new StringReader(changeSvgFile);
                                                while (true)
                                                {
                                                    line = reader.ReadLine();
                                                    if (line != null)
                                                    {
                                                        if (line.Contains(reg))
                                                        {
                                                            paragraph += line.Replace("#FFF7E0", "rgb(255,0,0);fill-opacity:0.5;");
                                                        }
                                                        else
                                                        {
                                                            paragraph += line + "\n";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                changeSvgFile = paragraph;

                                                break;
                                            }
                                        }

                                    }
                                }
                                showText += "</text>\n";
                            }
                        }

                        int splitHtml = changeSvgFile.LastIndexOf("</g>");

                        string subStringHtml = changeSvgFile.Substring(0, splitHtml);


                        string template01 = File.ReadAllText(physicalPath + @"Content/template/template01.txt");
                        string svg = subStringHtml + showText + "</g>\n</svg>";
                        string template02 = File.ReadAllText(physicalPath + @"Content/template/template02.txt");
                        File.WriteAllText(fileName, template01 + svg + template02, Encoding.UTF8);

                    }

                    count++;
                }
            }
            else
            {
                downloadFile[0] = @"Content/changeData/" + werks + "/" + floor + "/" + werks + separate + floor + separate + date[0] + separate + date[1] + "_first.html";
                downloadFile[1] = @"Content/changeData/" + werks + "/" + floor + "/" + werks + separate + floor + separate + date[0] + separate + date[1] + "_second.html";
            }
            result.Clear();

            for (int i = 0; i < downloadFile.Length; i++)
            {
                result.Add(new ChangeHistoryData()
                {
                    ChangeData = downloadFile[i]
                });
            }

            return result;
        }

        public List<FloorPlanFile> Get(string werks, string floor, string height)
        {
            List<FloorPlanFile> result = FloorPlanService.GetFloorPlanFile(werks, floor);
            List<FloorPlanFirst> first = new List<FloorPlanFirst>();

            string aLine, aParagraph = null;
            for (int i = 0; i < result.Count; i++)
            {
                string svgFile = result[i].floorplanFileData;
                string regText = "<text";
                string svgRegText = "<svg";

                StringReader strReader = new StringReader(svgFile);
                while (true)
                {
                    aLine = strReader.ReadLine();
                    if (aLine != null)
                    {
                        if (aLine.Contains(svgRegText))
                        {
                            aParagraph += aLine.Replace(">", " style=\"height : " + height + ";\">\n");
                        }
                        else if (aLine.Contains(regText))
                        {
                            aParagraph += aLine.Replace(">", " fill-opacity=\"0\">\n");
                        }
                        else
                        {
                            aParagraph += aLine + "\n";
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            List<FloorPlanFile> replaceResult = new List<FloorPlanFile>();

            replaceResult.Add(new FloorPlanFile()
            {
                floorplanFileData = aParagraph
            });


            return replaceResult;
        }

        // GET api/floorplan/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/floorplan
        public void Post([FromBody]string value)
        {
        }

        // PUT api/floorplan/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/floorplan/5
        public void Delete(int id)
        {
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Eland.NRSM.Web.Logging
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        private string macAddress = string.Empty;
        public LogActionFilterAttribute()
            : base()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces() != null
                && System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault() != null
                && System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault().GetPhysicalAddress() != null)
            {
                macAddress = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault().GetPhysicalAddress().ToString();
            }
            else
            {
                macAddress = "000000000000";
            }
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            try
            {
                MsmqGateway msmqGateway = Spring.Context.Support.ContextRegistry.GetContext().GetObject("MsmqGateway") as MsmqGateway;
                if (msmqGateway.Logged)
                {
                    LoggingContext.LogKeyStack.Push(GetGuid());

                    IDictionary<string, object> values = new Dictionary<string, object>();
                    values.Add(LogEventArgument.LOG_KEY, LoggingContext.LogKeyStack.Pop());
                    values.Add(LogEventArgument.APP_NAME, "NRSM");
                    values.Add(LogEventArgument.SERVER_NAME, Environment.MachineName);
                    values.Add(LogEventArgument.START_TIME, DateTime.Now);
                    values.Add(LogEventArgument.TARGET_TYPE, actionContext.ControllerContext.ControllerDescriptor.ControllerName);
                    values.Add(LogEventArgument.METHOD_NAME, actionContext.ActionDescriptor.ActionName);
                    values.Add(LogEventArgument.ARGUMENTS, JsonConvert.SerializeObject(actionContext.ActionArguments.Values.ToArray(), jsonFormatSettings));
                    values.Add(LogEventArgument.USER_ID, actionContext.ActionArguments.ContainsKey("loginId") ? actionContext.ActionArguments["loginId"] : null);
                    values.Add(LogEventArgument.PROGRAM_ID, actionContext.ActionArguments.ContainsKey("menuId") ? actionContext.ActionArguments["menuId"] : (actionContext.ActionArguments.ContainsKey("programId") ? actionContext.ActionArguments["programId"] : null));
                    if (actionContext.ActionArguments.ContainsKey("deviceModelName"))
                    {
                        values.Add(LogEventArgument.CLIENT_IP, actionContext.ActionArguments["deviceModelName"]);
                    }
                    msmqGateway.Send(values);
                }
            }
            catch { }
        }

        private string GetGuid()
        {
            var guid = Guid.NewGuid();
            return guid.ToString("N") + macAddress;
        }

        JsonSerializerSettings jsonFormatSettings = new JsonSerializerSettings
        {
            MaxDepth = 1,
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        protected class LogEventArgument
        {
            public const string UNKNOWN = ".Unknown";
            public const string LOG_KEY = "LogKey";
            public const string PARENT_LOG_Key = "ParentLogKey";
            public const string APP_NAME = "AppName";
            public const string USER_ID = "UserId";
            public const string TARGET_TYPE = "TargetType";
            public const string PROGRAM_ID = "ProgramId";
            public const string SERVER_NAME = "ServerName";
            public const string METHOD_NAME = "MethodName";
            public const string ARGUMENTS = "Arguments";
            public const string EXCEPTION_INFO = "ExceptionInfo";
            public const string START_TIME = "StartTime";
            public const string END_TIME = "EndTime";
            public const string DURATION = "Duration";
            public const string CLIENT_APPTYPE = "ClientAppType";
            public const string CLIENT_IP = "ClientIP";
            public const string INFORMATIONS = "Informations";

            public const string RETURN_VALUE = "ReturnValue";
            public const string REQUEST_URL = "RequestUrl";
            public const string REQUEST_URL_PATH = "RequestUrlPath";
        }

        protected class LoggingContext
        {
            private const string LOGGING_DATA_SLOT_NAME = "FormularLoggingContext";
            internal static Stack<string> LogKeyStack
            {
                get
                {
                    Spring.Threading.IThreadStorage storage = new Spring.Threading.HybridContextStorage();
                    Stack<string> _logKeyStack = storage.GetData(LOGGING_DATA_SLOT_NAME) as Stack<string>;

                    if (_logKeyStack == null)
                    {
                        _logKeyStack = new Stack<string>();
                        storage.SetData(LOGGING_DATA_SLOT_NAME, _logKeyStack);
                    }
                    return _logKeyStack;
                }
            }
        }
    }
}
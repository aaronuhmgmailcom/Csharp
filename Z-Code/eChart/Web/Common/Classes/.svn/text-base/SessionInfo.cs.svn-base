using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Web;
using System.Collections.Specialized;

namespace eChartProject.Web.Common
{
    public class SessionInfo
    {
        public const string USER_INFO = "_user_info";
        public const string CUR_RESOURCE_ID = "_cur_resource_id";
        public const string CUR_RESOURCE_URL = "_cur_resource_url";
        public const string CUR_LANGUAGE = "_cur_language";
        public const string HISTORY_POINT_SESSION_KEY = "_history_point_session_key";

        public static UserInfo UserInfo
        {
            get
            {
                return (UserInfo)HttpContext.Current.Session[USER_INFO];
            }
            set
            {
                HttpContext.Current.Session[USER_INFO] = value;
            }
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

        public static string CurrResourceId
        {
            get
            {
                return HttpContext.Current.Session[CUR_RESOURCE_ID] as string;
            }
            set
            {
                HttpContext.Current.Session[CUR_RESOURCE_ID] = value;
            }
        }

        public static string CurrentResourceUrl
        {
            get
            {
                return HttpContext.Current.Session[CUR_RESOURCE_URL] as string;
            }
            set
            {
                HttpContext.Current.Session[CUR_RESOURCE_URL] = value;
            }
        }

        public static string CurrentLang
        {
            get
            {
                return HttpContext.Current.Session[CUR_LANGUAGE] as string;
            }
            set
            {
                HttpContext.Current.Session[CUR_LANGUAGE] = value;
            }
        }

        public static NameValueCollection HistoryState
        {
            get
            {
                return HttpContext.Current.Session[HISTORY_POINT_SESSION_KEY] as NameValueCollection;
            }
            set
            {
                HttpContext.Current.Session[HISTORY_POINT_SESSION_KEY] = value;
            }
        }
    }
}
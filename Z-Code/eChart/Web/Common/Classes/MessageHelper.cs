using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Threading;
using System.Globalization;
using Wistron.SWPC.Framework.Common;

namespace Wistron.WiSync.Server.WiSyncPortal
{
    public class MessageHelper
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public MessageHelper()
        {

        }

        #region Get Message
        /// <summary>
        /// Get messages by MsgIDs
        /// </summary>
        /// <param name="strMsgIDs">multiple MsgID</param>
        /// <returns>Message</returns>
        public static string GetMessages(params string[] strMsgIDs)
        {
            StringBuilder strMsg = new StringBuilder();
            for (int i = 0; i < strMsgIDs.Length; i++)
            {
                string msg = GetMessageResource(strMsgIDs[i]);
                if (!string.IsNullOrEmpty(msg))
                {
                    strMsg.Append(msg + @"\n");
                }
            }
            char[] chr = new char[] { '\\', 'n' };
            return strMsg.ToString().TrimEnd(chr);
        }

        /// <summary>
        /// Get messages by MsgID from Message.resx
        /// </summary>
        /// <param name="strMsgID">single msgID</param>
        /// <returns>Message</returns>
        public static string GetMessage(string strMsgID)
        {
            return MessageHelper.GetMessages(new string[] { strMsgID });
        }

        /// <summary>
        /// Get messages by MsgID from Message.resx
        /// </summary>
        /// <param name="strMsgId">message id</param>
        /// <param name="strParms">string format's parameters</param>
        /// <returns>Message</returns>
        public static string GetMessage(string strMsgId, params string[] strParms)
        {
            return string.Format(GetMessage(strMsgId), strParms);
        }

        #endregion

        #region GetMessageResource

        /// <summary>
        /// get value from Message.resx by resourceKey
        /// </summary>
        /// <param name="resourcekey">resource key in Message.resx</param>
        /// <returns>message</returns>
        public static string GetMessageResource(string resourceKey)
        {
            return GetMessageResource("Message", resourceKey);
        }

        /// <summary>
        ///  get value from Message.resx by resourceKey according to the page's cultureInfo
        /// </summary>
        /// <param name="resourceKey">resource key in Message.resx</param>
        /// <param name="cultureInfo">page's culture</param>
        /// <returns>message</returns>
        public static string GetMessageResource(string resourceKey, CultureInfo cultureInfo)
        {
            return GetMessageResource("Message", resourceKey, cultureInfo);
        }

        /// <summary>
        /// get value from global resource by resourceKey according to page's current cultureInfo
        /// </summary>
        /// <param name="classKey">global resource'name</param>
        /// <param name="resourceKey">resource key in classKey</param>
        /// <returns>message</returns>
        private static string GetMessageResource(string classKey, string resourceKey)
        {
            return GetMessageResource(classKey, resourceKey, Thread.CurrentThread.CurrentUICulture);
        }

        /// <summary>
        /// get value from global resource by resourceKey according to the page's cultureInfo
        /// </summary>
        /// <param name="classKey">global resource'name </param>
        /// <param name="resourceKey">resource key in Global.resx</param>
        /// <param name="cultureInfo">page's culture</param>
        /// <returns>message</returns>
        private static string GetMessageResource(string classKey, string resourceKey, CultureInfo cultureInfo)
        {
            return ResourceManager.GetGlobalResource(classKey, resourceKey, cultureInfo);
        }

        #endregion

        #region ShowMessage

        #region ShowMessage

        /// <summary>
        /// Show a message for server mode
        /// </summary>
        /// <param name="ctr">control</param>
        /// <param name="strMsgIDs">resource key in Message.resx</param>
        public static void ShowMessage(Control ctr, params string[] strMsgIDs)
        {
            ShowMessage(ctr, EnumCustomMsgBoxIcon.Warning, strMsgIDs);
        }

        /// <summary>
        /// Show a message for server mode
        /// </summary>
        /// <param name="ctr">control</param>
        /// <param name="icon">icon</param>
        /// <param name="strMsgIDs">resource key in Message.resx</param>
        public static void ShowMessage(Control ctr, EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon));
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg));
        }

        /// <summary>
        /// Get script to show message
        /// </summary>
        /// <param name="icon">icon</param>
        /// <param name="strMsgIDs">resource key in Message.resx</param>
        /// <returns></returns>
        public static string GetScript_ShowMessage(EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";";
        }

        #endregion

        #region ShowMessageWithParms
        /// <summary>
        /// Show message with parms
        /// </summary>
        /// <param name="page"></param>
        /// <param name="strMsgIDs"></param>
        public static void ShowMessageWithParms(Control ctr, EnumCustomMsgBoxIcon icon, string strMsgID, params string[] strParms)
        {
            string strMsg = string.Format(MessageHelper.GetMessages(strMsgID), strParms);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon));
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg));
        }

        /// <summary>
        /// Get script to show message with parms
        /// </summary>
        /// <param name="strMsgID">resource key in Message.resx</param>
        /// <param name="strParms">Parms</param>
        /// <returns>A script string used to show message</returns>
        public static string GetScript_ShowMessageWithParms(EnumCustomMsgBoxIcon icon, string strMsgID, params string[] strParms)
        {
            string strMsg = string.Format(MessageHelper.GetMessages(strMsgID), strParms);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";";
        }

        #endregion

        #region ShowMessageAndCloseWin
        /// <summary>
        /// Show a message and close client window for server mode
        /// </summary>
        /// <param name="ctr">Control to be registed</param>
        /// <param name="strMsgIDs">Message ID list</param>
        public static void ShowMessageAndCloseWin(Control ctr, EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetClose());
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg), jsBuilder.GetClose());
        }

        /// <summary>
        /// Get script to show message and colse page
        /// </summary>
        /// <param name="strMsgIDs">resource key in Message.resx</param>
        /// <returns>A script string used to show message and close page</returns>
        public static string GetScript_ShowMessageAndCloseWin(EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + jsBuilder.GetClose() + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";" + jsBuilder.GetClose() + ";";
        }

        #endregion

        #region ShowMessageAndGoto
        /// <summary>
        /// Show a message and goto url for server mode
        /// </summary>
        /// <param name="crl">Control to be registed</param>
        /// <param name="strGotoURL">Url</param>
        /// <param name="strMsgIDs">Message ID list</param>
        public static void ShowMessageAndGoto(Control ctr, EnumCustomMsgBoxIcon icon, string strGotoURL, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetGoToWin(strGotoURL));
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg), jsBuilder.GetGoToWin(strGotoURL));
        }

        /// <summary>
        /// Get script to show message and goto url for server mode
        /// </summary>
        /// <param name="strGotoURL">Url</param>
        /// <param name="strMsgIDs">resource keys in Message.resx</param>
        /// <returns>A stript string used to show message and goto url for server mode</returns>
        public static string GetScript_ShowMessageAndGoto(EnumCustomMsgBoxIcon icon, string strGotoURL, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + jsBuilder.GetGoToWin(strGotoURL) + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";" + jsBuilder.GetGoToWin(strGotoURL) + ";";
        }

        #endregion

        #region ShowClientMessageAndRefresh
        /// <summary>
        /// Show a message and refresh this page for ajax mode
        /// </summary>
        /// <param name="AtlasUpdatePanelObject">Control to be registed</param>
        /// <param name="strMsgIDs">Message ID list</param>
        public static void ShowClientMessageAndRefresh(Control ctr, EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetReLoad());
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg), jsBuilder.GetReLoad());
        }

        /// <summary>
        /// Get script to show message and refresh current page for ajax mode
        /// </summary>
        /// <param name="strMsgIDs">resource keys in Message.resx</param>
        /// <returns>A script used to show message and refresh current page for ajax mode</returns>
        public static string GetScript_ShowClientMessageAndRefresh(EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + jsBuilder.GetReLoad() + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";" + jsBuilder.GetReLoad() + ";";
        }
        #endregion

        #region ShowMessageAndOpen
        /// <summary>
        /// show a message and open a new window for server mode
        /// </summary>
        /// <param name="ctr">Control to be registed</param>
        /// <param name="url">Url</param>
        /// <param name="strMsgIDs">Message ID list</param>
        public static void ShowMessageAndOpen(Control ctr, EnumCustomMsgBoxIcon icon, string url, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetOpenWin(url));
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg), jsBuilder.GetOpenWin(url));
        }

        /// <summary>
        /// Get script to show a message and open a new window for server mode
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="strMsgIDs">resource keys in Message.resx</param>
        /// <returns>Script string used to show a message and open a new window for server mode</returns>
        public static string GetScript_ShowMessageAndOpen(EnumCustomMsgBoxIcon icon, string url, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + jsBuilder.GetOpenWin(url) + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";" + jsBuilder.GetOpenWin(url) + ";";
        }
        #endregion

        #region ShowMessageAndParentClick
        /// <summary>
        /// show a message and click Parent button
        /// </summary>
        /// <param name="ctr">Control to be registed</param>
        /// <param name="url">Parent page url</param>
        /// <param name="strMsgIDs">Message ID list</param>
        public static void ShowMessageAndParentClick(Control ctr, EnumCustomMsgBoxIcon icon, string btnID, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetParentClick(btnID));
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg), jsBuilder.GetParentClick(btnID));
        }

        /// <summary>
        /// Get script to show a message and click Parent button
        /// </summary>
        /// <param name="ctr">Control to be registed</param>
        /// <param name="btnID">Parent page url</param>
        /// <param name="strMsgIDs">resource keys in Message.resx</param>
        public static string GetScript_ShowMessageAndParentClick(EnumCustomMsgBoxIcon icon, string btnID, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + jsBuilder.GetParentClick(btnID) + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";" + jsBuilder.GetParentClick(btnID) + ";";
        }
        #endregion

        #region ShowMessageAndParentGoToWin
        /// <summary>
        /// show a message and Parent GoToWin
        /// </summary>
        /// <param name="ctr">Control to be registed</param>
        /// <param name="url">Url</param>
        /// <param name="strMsgIDs">Message ID list</param>
        public static void ShowMessageAndParentGoToWin(Control ctr, EnumCustomMsgBoxIcon icon, string url, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetParentGoToWin(url));
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg), jsBuilder.GetParentGoToWin(url));
        }

        /// <summary>
        /// Get script to show a message and redirect to a new page from parent page
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="strMsgIDs">resource keys in Message.resx</param>
        /// <returns>A script string used to show a message and Parent GoToWin</returns>
        public static string GetScript_ShowMessageAndParentGoToWin(EnumCustomMsgBoxIcon icon, string url, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + jsBuilder.GetParentGoToWin(url) + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";" + jsBuilder.GetParentGoToWin(url) + ";";
        }
        #endregion

        #region ShowMessageAndParentReload
        /// <summary>
        /// show a message and Parent Reload
        /// </summary>
        /// <param name="ctr">Control to be registed</param>
        /// <param name="url">Parent url</param>
        /// <param name="strMsgIDs">Message id list</param>
        public static void ShowMessageAndParentReload(Control ctr, EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetParentReload());
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg), jsBuilder.GetParentReload());
        }

        /// <summary>
        /// Get script to show a message and Parent Reload
        /// </summary>
        /// <param name="strMsgIDs">resource keys in Message.resx</param>
        /// <returns>A script used to show a message and Parent Reload</returns>
        public static string GetScript_ShowMessageAndParentReload(EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + jsBuilder.GetParentReload() + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";" + jsBuilder.GetParentReload() + ";";
        }

        #endregion

        #region ShowMessageAndParentSubmit
        /// <summary>
        /// Show message and submit father page
        /// </summary>
        /// <param name="ctr">control</param>
        /// <param name="strMsgIDs">message ids</param>
        public static void ShowMessageAndParentSubmit(Control ctr, EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetParentSubmit("", ""));
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg), jsBuilder.GetParentSubmit("", ""));
        }


        /// <summary>
        /// Get script to show message and submit father page
        /// </summary>
        /// <param name="strMsgIDs">message ids</param>
        /// <returns>A script string used to show message and submit father page</returns>
        public static string GetScript_ShowMessageAndParentSubmit(EnumCustomMsgBoxIcon icon, params string[] strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                return ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + jsBuilder.GetParentSubmit("", "") + ";";
            else
                return ";" + jsBuilder.GetAlert(strMsg) + ";" + jsBuilder.GetParentSubmit("", "") + ";";
        }

        /// <summary>
        /// Show message and submit father page
        /// </summary>
        /// <param name="ctr">control</param>
        /// <param name="strMsgIDs">message id</param>
        public static void ShowMessageAndParentSubmit(Control ctr, EnumCustomMsgBoxIcon icon, string strMsgIDs)
        {
            ShowMessageAndParentSubmit(ctr, icon, "", "", strMsgIDs);
        }

        /// <summary>
        /// Show message and submit father page
        /// </summary>
        /// <param name="ctr">control</param>
        /// <param name="eventArgument">dopostback's eventArgument</param>
        /// <param name="strMsgIDs">message id</param>
        public static void ShowMessageAndParentSubmit(Control ctr, EnumCustomMsgBoxIcon icon, string eventArgument, string strMsgIDs)
        {
            ShowMessageAndParentSubmit(ctr, icon, "", eventArgument, strMsgIDs);
        }

        /// <summary>
        /// Show message and submit father page
        /// </summary>
        /// <param name="ctr">control</param>
        /// <param name="eventTarget">dopostback's eventTarget</param>
        /// <param name="eventArgument">dopostback's eventArgument</param>
        /// <param name="strMsgIDs">message id</param>
        public static void ShowMessageAndParentSubmit(Control ctr, EnumCustomMsgBoxIcon icon, string eventTarget, string eventArgument, string strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetParentSubmit(eventTarget, eventArgument));
            else
                jsBuilder.RegScript(ctr, jsBuilder.GetAlert(strMsg), jsBuilder.GetParentSubmit(eventTarget, eventArgument));
        }

        /// <summary>
        /// Get script to regist control and submit parent page
        /// </summary>
        /// <param name="ctr">Control</param>
        /// <param name="eventTarget">dopostback's eventTarget</param>
        /// <param name="eventArgument">dopostback's eventArgument</param>
        /// <param name="strMsgIDs">message id list</param>
        /// <returns></returns>
        public static string GetScript_ShowMessageAndParentSubmit(Control ctr, EnumCustomMsgBoxIcon icon, string eventTarget, string eventArgument, string strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            string script = jsBuilder.GetParentSubmit(eventTarget, eventArgument) + ";";
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                script = ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + script;
            else
                script = ";" + jsBuilder.GetAlert(strMsg) + ";" + script;
            return script;
        }

        /// <summary>
        /// Show message and submit father page
        /// </summary>
        /// <param name="ctr">control</param>
        /// <param name="eventTarget">dopostback's eventTarget</param>
        /// <param name="eventArgument">dopostback's eventArgument</param>
        /// <param name="jScript">javascript</param>
        /// <param name="strMsgIDs">message id</param>
        public static void ShowMessageAndParentSubmit(Control ctr, EnumCustomMsgBoxIcon icon, string eventTarget, string eventArgument, string jScript, string strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                jsBuilder.RegScript(ctr, jScript, jsBuilder.GetCustomAlert(strMsg, icon), jsBuilder.GetParentSubmit(eventTarget, eventArgument));
            else
                jsBuilder.RegScript(ctr, jScript, jsBuilder.GetAlert(strMsg), jsBuilder.GetParentSubmit(eventTarget, eventArgument));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventTarget">dopostback's eventTarget</param>
        /// <param name="eventArgument">dopostback's eventArgument</param>
        /// <param name="jScript">javascript</param>
        /// <param name="strMsgIDs">message id</param>
        /// <returns></returns>
        public static string GetScript_ShowMessageAndParentSubmit(EnumCustomMsgBoxIcon icon, string eventTarget, string eventArgument, string jScript, string strMsgIDs)
        {
            string strMsg = MessageHelper.GetMessages(strMsgIDs);
            string script = jsBuilder.GetParentSubmit(eventTarget, eventArgument);
            if (SystemConfiguration.Context.MsgBoxType.Equals(EnumMsgBoxType.Custom))
                script = ";" + jScript + ";" + jsBuilder.GetCustomAlert(strMsg, icon) + ";" + script;
            else
                script = ";" + jScript + ";" + jsBuilder.GetAlert(strMsg) + ";" + script;
            return script;
        }

        #endregion

        #endregion

        #region LetParentSubmit
        /// <summary>
        /// submit parent's control event
        /// </summary>
        /// <param name="ctr">control</param>
        /// </summary>
        public static void LetParentSubmit(Control ctr)
        {
            LetParentSubmit(ctr, "", "");
        }

        /// <summary>
        /// submit parent's control event
        /// </summary>
        /// <param name="ctr">control</param>
        /// <param name="eventArgument">dopostback's eventTarget</param>
        /// </summary>
        public static void LetParentSubmit(Control ctr, string eventArgument)
        {
            LetParentSubmit(ctr, "", eventArgument);
        }


        /// <summary>
        /// submit parent's control event
        /// </summary>
        /// <param name="ctr">control</param>
        /// <param name="eventTarget">dopostback's eventTarget</param>
        /// <param name="eventArgument">dopostback's eventArgument</param>
        /// </summary>
        public static void LetParentSubmit(Control ctr, string eventTarget, string eventArgument)
        {
            jsBuilder.RegScript(ctr, jsBuilder.GetParentSubmit(eventTarget, eventArgument));
        }
        /// <summary>
        /// Get script to submit parent's control
        /// </summary>
        /// <param name="eventTarget">dopostback's eventTarget</param>
        /// <param name="eventArgument">dopostback's eventArgument</param>
        /// <returns>A script string to submin parent's control</returns>
        public static string GetScript_LetParentSubmit(string eventTarget, string eventArgument)
        {
            return ";" + jsBuilder.GetParentSubmit(eventTarget, eventArgument) + ";";
        }

        #endregion

        #region LetSubmitGoto
        /// <summary>
        /// goto url for server mode
        /// </summary>
        /// <param name="ctr">Control to registed</param>
        public static void LetSubmitGoto(Control ctr, string strGotoURL)
        {
            string noAlert = "";
            jsBuilder.RegScript(ctr, noAlert, jsBuilder.GetGoToWin(strGotoURL));
        }

        /// <summary>
        /// Get script to goto url for server mode
        /// </summary>
        /// <param name="strGotoURL">url</param>
        /// <returns>Script string used to submit an goto url</returns>
        public static string GetScript_LetSubmitGoto(string strGotoURL)
        {
            string noAlert = "";
            return ";" + noAlert + ";" + jsBuilder.GetGoToWin(strGotoURL) + ";";
        }
        #endregion
    }
}
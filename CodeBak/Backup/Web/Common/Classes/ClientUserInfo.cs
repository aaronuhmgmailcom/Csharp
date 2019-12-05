using System;
using System.Data;

namespace eChartProject.Web.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientUserInfo
    {


        #region Field

        private int userId;
        private string email;
        private int fundID;
        private string pswd;
        private DataTable chattingHistory;
        private string currentURI;
        private int? currentFolderID;
        #endregion

        #region Property

        #region UserId
        /// <summary>
        /// user's identity
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        #endregion

        #region Email
        /// <summary>
        /// user's email
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion

        #region FundID
        /// <summary>
        /// 
        /// </summary>
        public int FundID
        {
            get { return fundID; }
            set { fundID = value; }
        }
        #endregion

        #region Pswd
        /// <summary>
        /// user's Pswd
        /// </summary>
        public string Pswd
        {
            get { return pswd; }
            set { pswd = value; }
        }
        #endregion

        #region ChattingHistory
        /// <summary>
        /// user's ChattingHistory
        /// </summary>
        public DataTable ChattingHistory
        {
            get { return chattingHistory; }
            set { chattingHistory = value; }
        }
        #endregion

        #region CurrentURI
        /// <summary>
        /// user's CurrentURI
        /// </summary>
        public string CurrentURI
        {
            get { return currentURI; }
            set { currentURI = value; }
        }
        #endregion

        #region CurrentFolderID
        /// <summary>
        /// user's CurrentFolderID
        /// </summary>
        public int? CurrentFolderID
        {
            get { return currentFolderID; }
            set { currentFolderID = value; }
        }
        #endregion
        #endregion
    }
}
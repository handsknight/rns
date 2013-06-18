using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace rns
{
    static class Program
    {


            public static string pbUserID;
            public static string pbUserName;
            public static Boolean pbDownloadAcess;
            public static Boolean pbDatabase1Access;
            public static Boolean pbDatabase2Access;
            public static Boolean pbUserSetupAccess;
            public static Boolean pbClientSetupAccess;
            public static Boolean pbClientRequestAccess;
            public static Boolean pbReportAccess;
            public static Boolean pbSetupAccess;
            public static string pbFormName = string.Empty;
            public static string _searchedValue = string.Empty;
            public static string _searchedValue2 = string.Empty;
            public static string _searchedValue3 = string.Empty;
            public static string _searchedValue4 = string.Empty;

            public static string[] _returnArray;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
      
            [STAThread]
            static void Main()
            {
                string pbUserId = String.Empty;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new frmlogin());
                Application.Run(new splashscreen());

           
             }
     }
 }


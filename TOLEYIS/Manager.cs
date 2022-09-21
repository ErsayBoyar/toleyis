using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TOLEYIS
{
    public class Manager
    {
        public string GetAdminIPAndPort()
        {
            var ip = ConfigurationManager.AppSettings["ADMIN_IP"];
            var adminport = ConfigurationManager.AppSettings["ADMIN_PORT"];
            if (String.IsNullOrEmpty(adminport))
                adminport = "8081";
            return ip + ":" + adminport;
        }
    }
}
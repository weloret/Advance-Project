using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentralClassLibrary;

namespace TaskCentralFormsApp
{
    internal class Global
    {
        public static User loggedUser = null;
        public static Project selectedProject = null;

        public static Log ExceptionHandler(Exception ex, String pName)
        {
            Log lg = new Log();
            lg.DateTime = DateTime.Now;
            lg.Source = "Form/"+pName;
            lg.Message = ex.Message;
            lg.User = loggedUser;
            lg.Type = "Exception";
            return lg;
        }
    }
}

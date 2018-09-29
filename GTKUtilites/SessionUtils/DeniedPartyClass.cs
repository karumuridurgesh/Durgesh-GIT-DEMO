using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTKUtilites.SessionUtils
{
   public  class DeniedPartyClass
    {
        private string _sAddress;
        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        private string _sName;
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }
        private string _sCnty;
        public string Cnty
        {
            get { return _sCnty; }
            set { _sCnty = value; }
        }
        private string _sCntyCd;
        public string CntyCd
        {
            get { return _sCntyCd; }
            set { _sCntyCd = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BT.Model
{
    public partial class ACCOUNTS_LOG
    {
        public string SimpleTRADETIME
        {
            get
            {
                return TRADETIME.ToString("yyyy-MM-dd");
            }
        }
    }
}

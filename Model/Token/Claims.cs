using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Token
{
    public class Claims
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userRole{ get; set; }
    }
}

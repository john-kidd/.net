using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gam.AppCentral.Desktop.Framework
{
    public class WorklistItem
    {
        public string Action { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string AssignedUser { get; set; }

        public DateTime StartDate { get; set; }
    }
}

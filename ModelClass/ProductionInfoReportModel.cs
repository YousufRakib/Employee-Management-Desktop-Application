using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTree.ModelClass
{
    public class ProductionInfoReportModel
    {
        public string IdCardNo { get; set; }
        public string EmployeeName { get; set; }
        public string Section { get; set; }
        public string ProductionDay { get; set; }
        public string ReportMonth { get; set; }
        public string Style { get; set; }
        public string Size { get; set; }
        public double Total { get; set; }
    }
}

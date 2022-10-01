using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyTree.ModelClass
{
    public class ProductionWiseReportModel
    {
        public string IdCardNo { get; set; }
        public string EmployeeName { get; set; }
        public string Section { get; set; }
        public string ProductionDay { get; set; }
        public string ReportMonth { get; set; }
        public string Style { get; set; }
        public string Size { get; set; }
        public string Present { get; set; }
        public double TotalQuantity { get; set; }
        public double Rate { get; set; }
        public double StyleWiseTotalPrice { get; set; }
        public string TotalPriceWithoutBonus { get; set; }
        public string BonusPercent { get; set; }
        public string GrossAmount { get; set; }
        public string AttendanceBonus { get; set; }
    }
}

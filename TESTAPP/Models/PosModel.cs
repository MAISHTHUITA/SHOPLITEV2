using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOPLITE.Models
{
    public class PosMaster
    {
        public int ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal VatAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string MachineName { get; set; }
        public string Username { get; set; }
        public string PaymentMethod { get; set; }
        public string CmpnyCd { get; set; }
        public string BrnchCd { get; set; }
    }
    public class PosDetail
    {
        public int ReceiptNumber { get; set; }
        public string ProdCd { get; set; }
        public string ProdNm { get; set; }
        public string UnitCd { get; set; }
        public decimal Quantity { get; set; }
        public decimal Sp { get; set; }
        public decimal LineVat { get; set; }
        public decimal LineAmount { get; set; }
    }
}

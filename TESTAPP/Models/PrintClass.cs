using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using ZXing;

namespace SHOPLITE.Models
{
    public class PrintClass
    {
        private Font printfont;
        private Image barcode;
        private string _comment;
        private int _receiptno;
        private bool _response = false;
        //to be inserted when method pass testing "int receipt, string comment, out bool response"
        public void PrintReceipt(int receipt, string comment, out bool response)
        {
            try
            {
                _comment = comment;
                _receiptno = receipt;
                PrintDocument doc = new PrintDocument();
                printfont = new Font("Verdana", 8);
                doc.PrintPage += new PrintPageEventHandler(this.Doc_PrintPage);
                doc.Print();
                response = _response;
            }
            catch (Exception exe)
            {
                response = false;
            }
            
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float yPos = 0;
            float leftMargin =10;
            float topMargin = 10;
            yPos = topMargin;
            List<PosDetail> posDetails = new List<PosDetail>();
            PosRepository repository = new PosRepository();
            PosMaster pos = repository.GetReceipt(_receiptno, out posDetails);
            if (pos==null)
            {
                _response = false;
                ev.Cancel=true;
                return;
            }
            BarcodeWriter writer = new BarcodeWriter() { Format=BarcodeFormat.CODE_128, Options=new ZXing.Common.EncodingOptions { Height =50,Width=120 ,Margin=0} };
            barcode = writer.Write(pos.PosNumber.ToString());
            Rectangle rectangle = new Rectangle(10, 10, barcode.Width, barcode.Height);
            ev.Graphics.DrawImage(barcode, rectangle);
            yPos = 5+barcode.Height;
            yPos = yPos + printfont.GetHeight(ev.Graphics);
            ev.Graphics.DrawString("CODE" + "   " + "DESCRIPTION" + "   ", printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            foreach (PosDetail detail in posDetails)
            {
                yPos = yPos + printfont.GetHeight(ev.Graphics);
                ev.Graphics.DrawString(detail.ProdCd+ "   "+detail.ProdNm+ "   ", printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            }
            printfont=new Font("Verdana", 7,FontStyle.Italic);
            yPos=yPos+ printfont.GetHeight(ev.Graphics);
            ev.Graphics.DrawString("**** Thank you For Shopping with us!!!! *****", printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        }
    }
}

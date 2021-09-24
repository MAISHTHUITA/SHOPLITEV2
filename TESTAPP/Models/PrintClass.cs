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
        private Pen pen;
        //to be inserted when method pass testing "int receipt, string comment, out bool response"
        public void PrintReceipt(int receipt, string comment, out bool response)
        {
            try
            {
                _comment = comment;
                _receiptno = receipt;
                PrintDocument doc = new PrintDocument();
                printfont = new Font("Arial Narrow", 7);
                doc.DocumentName = "Receipt_" + receipt.ToString();
                doc.PrintPage += new PrintPageEventHandler(this.Doc_PrintPage);
                doc.Print();
                response = _response;
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                response = false;
            }

        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float leftMargin = 5;
            float topMargin = 5;
            float qtymargin = 200;
            float descmargin = 50;
            float yPos = topMargin;

            pen = new Pen(Brushes.Black, 1)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };
            Font headerfont = new Font("Arial Narrow", 7, FontStyle.Bold);
            _ = new List<PosDetail>();
            PosRepository repository = new PosRepository();
            PosMaster pos = repository.GetReceipt(_receiptno, out List<PosDetail> posDetails);
            if (pos == null)
            {
                _response = false;
                ev.Cancel = true;
                return;
            }
            //header region
            ev.Graphics.DrawString(pos.CmpnyCd.ToUpper(), headerfont, Brushes.Black, 60, yPos, new StringFormat());
            yPos = yPos + headerfont.GetHeight(ev.Graphics);
            ev.Graphics.DrawString(pos.BrnchCd.ToUpper(), headerfont, Brushes.Black, 75, yPos, new StringFormat());
            yPos = yPos + headerfont.GetHeight(ev.Graphics);
            //header barcode
            BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128, Options = new ZXing.Common.EncodingOptions { Height = 50, Width = 120, Margin = 0 } };
            barcode = writer.Write(pos.PosNumber.ToString());
            Rectangle rectangle = new Rectangle(45, 35, barcode.Width, barcode.Height);
            ev.Graphics.DrawImage(barcode, rectangle);
            yPos = 2 + barcode.Height;
            yPos = yPos + printfont.GetHeight(ev.Graphics);
            yPos = yPos + printfont.GetHeight(ev.Graphics);
            yPos = yPos + printfont.GetHeight(ev.Graphics);

            ev.Graphics.DrawString("DATE: " + pos.ReceiptDate, printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            yPos = yPos + printfont.GetHeight(ev.Graphics);
            //receipt details headers
            ev.Graphics.DrawLine(pen, 0, yPos, 240, yPos);
            ev.Graphics.DrawString(Trancute("CODE", 9), headerfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            ev.Graphics.DrawString(Trancute("DESCRIPTION", 35), headerfont, Brushes.Black, descmargin, yPos, new StringFormat());
            ev.Graphics.DrawString(Trancute("Qty", 5), headerfont, Brushes.Black, qtymargin, yPos, new StringFormat());
            float line2 = yPos + printfont.GetHeight(ev.Graphics);
            ev.Graphics.DrawLine(pen, 0, line2, 240, line2);
            yPos = yPos + 2;
            //ev.Graphics.DrawString(" " + "Price", headerfont, Brushes.Black, spmargin, yPos, new StringFormat());

            //receipt details
            foreach (PosDetail detail in posDetails)
            {
                yPos = yPos + printfont.GetHeight(ev.Graphics);
                ev.Graphics.DrawString(Trancute(detail.ProdCd, 9), printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
                ev.Graphics.DrawString(Trancute(detail.ProdNm + " (" + detail.UnitCd + ")", 35), printfont, Brushes.Black, descmargin, yPos, new StringFormat());
                ev.Graphics.DrawString(Trancute(detail.Quantity.ToString("0.00"), 5), printfont, Brushes.Black, qtymargin, yPos, new StringFormat());
                //ev.Graphics.DrawString("*" + detail.Sp.ToString("0.00"), printfont, Brushes.Black, spmargin, yPos, new StringFormat());
                yPos = yPos + printfont.GetHeight(ev.Graphics);
                ev.Graphics.DrawString(detail.Quantity.ToString("0.00") + " * " + detail.Sp.ToString("0.00") + "   " + detail.LineAmount + " " + detail.VatCd, printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            }

            //receipt summaries
            yPos = yPos + printfont.GetHeight(ev.Graphics);
            ev.Graphics.DrawLine(pen, 0, yPos, 240, yPos + 1);
            ev.Graphics.DrawString("RENDERED        Kshs." + pos.CashGiven.ToString("0.00"), printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            yPos = yPos + printfont.GetHeight(ev.Graphics) + 1;
            ev.Graphics.DrawString("TOTAL              Kshs." + pos.TotalAmount.ToString("0.00"), printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            yPos = yPos + printfont.GetHeight(ev.Graphics) + 1;

            //check wheather the the transaction was cash or other payments. if other payment change will be zero.
            //declare change
            decimal change;
            if ((pos.CashGiven - pos.TotalAmount) < 0)
            {
                change = 0;
            }
            else
                change = pos.CashGiven - pos.TotalAmount;
            ev.Graphics.DrawString("CHANGE          Kshs." + change.ToString("0.00"), printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            yPos = yPos + printfont.GetHeight(ev.Graphics) + 1;
            ev.Graphics.DrawLine(pen, 0, yPos, 240, yPos);
            ev.Graphics.DrawString("Narration       " + pos.PaymentNarration, printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            yPos = yPos + printfont.GetHeight(ev.Graphics);
            ev.Graphics.DrawString("Served By       " + pos.Username, printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
            yPos = yPos + printfont.GetHeight(ev.Graphics);
            ev.Graphics.DrawLine(pen, 0, yPos, 240, yPos);
            printfont = new Font("Arial Narrow", 7);
            yPos = yPos + printfont.GetHeight(ev.Graphics);
            ev.Graphics.DrawString("**Thank you For Shopping with us!!!!**", printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        }
        private string Trancute(string stringtotrancuate, int length)
        {
            if (stringtotrancuate.Length <= length)
            {
                return stringtotrancuate.PadRight(length);
            }
            else
            {
                string trancuated = stringtotrancuate.Substring(0, length);
                return trancuated;
            }
        }

    }
}

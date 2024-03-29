﻿using SHOPLITE.Reports;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace SHOPLITE.Models
{
    public class PrintClass
    {

        private int _receiptno;


        //to be inserted when method pass testing "int receipt, string comment, out bool response"
        public void PrintReceipt(int receiptNo, string comment, out bool response)
        {
            try
            {

                _receiptno = receiptNo;

                PosRepository pos = new PosRepository();
                List<PosDetail> posdetails = new List<PosDetail>();
                PosMaster posmaster = new PosMaster();
                posmaster = pos.GetReceipt(_receiptno, out posdetails);
                if (posmaster == null)
                {
                    response = false;
                    return;
                }
                // initialize settings
                SettingsModel settings1 = new SettingsModel();
                settings1.loaddata();
                Receipt receipt = new Receipt();
                Company company = new Company();
                company = company.GetCompany(posmaster.CmpnyCd);
                SettingsModel model = new SettingsModel();
                string receipttext = model.Receipttext();
                receipt.SetDataSource(posdetails);
                receipt.SetParameterValue("@Company", posmaster.CmpnyCd);
                receipt.SetParameterValue("@Branch", posmaster.BrnchCd);
                receipt.SetParameterValue("@Phone", "TEL: " + posmaster.Phone);
                receipt.SetParameterValue("@ReceiptNumber", receipttext + " " + posmaster.PosNumber.ToString());
                receipt.SetParameterValue("@Change", posmaster.Change.ToString("0.00"));
                receipt.SetParameterValue("@Cashgiven", posmaster.CashGiven.ToString("0.00"));
                receipt.SetParameterValue("@Narration", posmaster.PaymentNarration);
                receipt.SetParameterValue("@Username", posmaster.Username);
                receipt.SetParameterValue("Cname", posmaster.Comment);
                receipt.SetParameterValue("Comment", "ORIGINAL RECEIPT");
                receipt.SetParameterValue("Pin", "PIN: " + company.CompanyTaxpin);
                receipt.SetParameterValue("Email", "Email: " + company.CompanyEmail);
                receipt.SetParameterValue("Address", company.CompanyAddress);
                //FOMART DATE
                var date = posmaster.ReceiptDate.ToString("dd-MMM-yyyy");
                var time = posmaster.ReceiptDate.ToString("hh:mm:ss tt");
                receipt.SetParameterValue("@ReceiptDate", date + "      " + time);
                // determines weather to suppress values and fields that displays vat calculations
                if (settings1.showvatonreceipts)
                {
                    receipt.SetParameterValue("@Policy", false);
                }
                else
                {
                    receipt.SetParameterValue("@Policy", true);
                }


                PrinterSettings settings = new PrinterSettings();
                if (settings1.Printername == string.Empty)
                {
                    PageSettings printerSettings = new PageSettings();
                    settings.PrinterName = settings.PrinterName;
                    printerSettings.PaperSize = new PaperSize("Custom", 300, 3000);
                    receipt.PrintToPrinter(settings, printerSettings, false);
                }
                else
                {
                    settings.PrinterName = settings1.Printername;
                    PageSettings printerSettings = new PageSettings();
                    printerSettings.PaperSize = new PaperSize("Custom", 300, 3000);
                    receipt.PrintToPrinter(settings, printerSettings, false);
                }


                response = true;
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                response = false;
            }

        }
        public void PrintReceiptReprint(int receiptNo, string comment, out bool response, DateTime fromdate, DateTime todate)
        {
            try
            {

                _receiptno = receiptNo;

                PosRepository pos = new PosRepository();
                List<PosDetail> posdetails = new List<PosDetail>();
                PosMaster posmaster = new PosMaster();
                posmaster = pos.GetReceipt(_receiptno, out posdetails, fromdate, todate);
                if (posmaster == null)
                {
                    response = false;
                    return;
                }
                // initialize settings
                SettingsModel settings1 = new SettingsModel();
                settings1.loaddata();
                Receipt receipt = new Receipt();
                Company company = new Company();
                company = company.GetCompany(posmaster.CmpnyCd);
                receipt.SetDataSource(posdetails);
                receipt.SetParameterValue("@Company", posmaster.CmpnyCd);
                receipt.SetParameterValue("@Branch", posmaster.BrnchCd);
                receipt.SetParameterValue("@Phone", posmaster.Phone);
                receipt.SetParameterValue("@ReceiptNumber", posmaster.PosNumber);
                receipt.SetParameterValue("@Change", posmaster.Change);
                receipt.SetParameterValue("@Cashgiven", posmaster.CashGiven);
                receipt.SetParameterValue("@Narration", posmaster.PaymentNarration);
                receipt.SetParameterValue("@Username", posmaster.Username);
                receipt.SetParameterValue("Pin", company.CompanyTaxpin);
                receipt.SetParameterValue("Email", company.CompanyEmail);
                receipt.SetParameterValue("Address", company.CompanyAddress);
                //FOMART DATE
                var date = posmaster.ReceiptDate.ToString("dd-MMM-yyyy");
                var time = posmaster.ReceiptDate.ToString("hh:mm:ss tt");
                receipt.SetParameterValue("@ReceiptDate", date + "      " + time);
                receipt.SetParameterValue("Cname", posmaster.Comment);
                receipt.SetParameterValue("Comment", "REPRINT");

                // determines weather to suppress values and fields that displays vat calculations
                if (settings1.showvatonreceipts)
                {
                    receipt.SetParameterValue("@Policy", false);
                }
                else
                {
                    receipt.SetParameterValue("@Policy", true);
                }


                PrinterSettings settings = new PrinterSettings();
                if (settings1.Printername == string.Empty)
                {
                    PageSettings printerSettings = new PageSettings();
                    settings.PrinterName = settings.PrinterName;
                    printerSettings.PaperSize = new PaperSize("Custom", 300, 3000);
                    receipt.PrintToPrinter(settings, printerSettings, false);
                }
                else
                {
                    settings.PrinterName = settings1.Printername;
                    PageSettings printerSettings = new PageSettings();
                    printerSettings.PaperSize = new PaperSize("Custom", 300, 3000);
                    receipt.PrintToPrinter(settings, printerSettings, false);
                }
                response = true;
            }
            catch (Exception exe)
            {
                Logger.Loggermethod(exe);
                response = false;
            }

        }
        //#region fonts
        ///// <summary>
        ///// font to be used to display header text.
        ///// </summary>
        ///// <returns></returns>
        //private Font headerfontmethod()
        //{
        //    return new Font("Verdana", 14, FontStyle.Bold);
        //}
        //private Font subheadingfont()
        //{
        //    return new Font("Verdana", 12, FontStyle.Regular);
        //}
        //private Font tableheaderfont() { return new Font("Verdana", 9, FontStyle.Regular); }
        //#endregion
        //private void Doc_PrintPage(object sender, PrintPageEventArgs ev)
        //{
        //    float leftMargin = 5;
        //    float topMargin = 1;
        //    //float qtymargin = 200;
        //    float descmargin = 60;
        //    float yPos = topMargin;

        //    pen = new Pen(Brushes.Black, 1)
        //    {
        //        DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        //    };
        //    _ = new List<PosDetail>();
        //    PosRepository repository = new PosRepository();
        //    PosMaster pos = repository.GetReceipt(_receiptno, out List<PosDetail> posDetails);
        //    if (pos == null)
        //    {
        //        _response = false;
        //        ev.Cancel = true;
        //        return;
        //    }
        //    //header region
        //    ev.Graphics.DrawString(pos.CmpnyCd.ToUpper(), headerfontmethod(), Brushes.Black, 5, yPos, new StringFormat());
        //    yPos = yPos + headerfontmethod().GetHeight(ev.Graphics);
        //    ev.Graphics.DrawString(pos.BrnchCd.ToUpper(), subheadingfont(), Brushes.Black, 45, yPos, new StringFormat());
        //    yPos = yPos + subheadingfont().GetHeight(ev.Graphics);
        //    ev.Graphics.DrawString("Tel:0720369235/0786788277", printfont, Brushes.Black, 46, yPos, new StringFormat());
        //    yPos = yPos + subheadingfont().GetHeight(ev.Graphics);
        //    //header barcode
        //    BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128, Options = new ZXing.Common.EncodingOptions { Height = 50, Width = 120, Margin = 0 } };
        //    //get date in format yyyymmdd
        //    int year = pos.ReceiptDate.Year;
        //    int month = pos.ReceiptDate.Month;
        //    int day = pos.ReceiptDate.Day;
        //    barcode = writer.Write(year.ToString()+month.ToString()+day.ToString()+"00"+pos.PosNumber.ToString());
        //    Rectangle rectangle = new Rectangle(55,Convert.ToInt32( yPos), barcode.Width, barcode.Height);
        //    ev.Graphics.DrawImage(barcode, rectangle);
        //    yPos = 2 + barcode.Height;
        //    yPos = yPos + 65;
        //    ev.Graphics.DrawString("DATE: " + pos.ReceiptDate.ToString("dd-MMM-yyyy") + "                Time: "+pos.ReceiptDate.ToString("HH:mm:ss"), printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        //    yPos = yPos+3 + printfont.GetHeight(ev.Graphics);
        //    //receipt details headers
        //    ev.Graphics.DrawLine(pen, 0, yPos, 300, yPos);
        //    ev.Graphics.DrawString(Trancute("CODE", 9), tableheaderfont(), Brushes.Black, leftMargin, yPos, new StringFormat());
        //    ev.Graphics.DrawString(Trancute("DESCRIPTION", 35), tableheaderfont(), Brushes.Black, descmargin, yPos, new StringFormat());
        //    //ev.Graphics.DrawString(Trancute("Qty", 5), tableheaderfont(), Brushes.Black, qtymargin, yPos, new StringFormat());
        //    float line2 = yPos + printfont.GetHeight(ev.Graphics);
        //    ev.Graphics.DrawLine(pen, 0, line2, 300, line2);
        //    yPos = yPos + 2;
        //    //ev.Graphics.DrawString(" " + "Price", headerfont, Brushes.Black, spmargin, yPos, new StringFormat());

        //    //receipt details
        //    foreach (PosDetail detail in posDetails)
        //    {
        //        yPos = yPos+3 + printfont.GetHeight(ev.Graphics);
        //        ev.Graphics.DrawString(Trancute(detail.ProdCd, 10), printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        //        ev.Graphics.DrawString(Trancute(detail.ProdNm, 70), printfont, Brushes.Black, descmargin, yPos, new StringFormat());
        //        //ev.Graphics.DrawString(Trancute(detail.Quantity.ToString("0.00"), 5), printfont, Brushes.Black, qtymargin, yPos, new StringFormat());
        //        //ev.Graphics.DrawString("*" + detail.Sp.ToString("0.00"), printfont, Brushes.Black, spmargin, yPos, new StringFormat());
        //        yPos = yPos + printfont.GetHeight(ev.Graphics);
        //        ev.Graphics.DrawString(detail.Quantity.ToString("0.00")+detail.UnitCd + " * " + detail.Sp.ToString("0.00") + "           " + detail.LineAmount + " " + detail.VatCd, printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        //    }

        //    //receipt summaries
        //    yPos = yPos+2 + printfont.GetHeight(ev.Graphics);
        //    ev.Graphics.DrawLine(pen, 0, yPos, 300, yPos + 1);
        //    ev.Graphics.DrawString("TOTAL        Kshs." + pos.TotalAmount.ToString("0.00"), printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        //    yPos = yPos + printfont.GetHeight(ev.Graphics) + 1;

        //    ev.Graphics.DrawString("RENDERED     Kshs." + pos.CashGiven.ToString("0.00"), printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        //    yPos = yPos + printfont.GetHeight(ev.Graphics) + 1;

        //    //check wheather the the transaction was cash or other payments. if other payment change will be zero.
        //    //declare change
        //    decimal change;
        //    if ((pos.CashGiven - pos.TotalAmount) < 0)
        //    {
        //        change = 0;
        //    }
        //    else
        //        change = pos.CashGiven - pos.TotalAmount;
        //    ev.Graphics.DrawString("CHANGE       Kshs." + change.ToString("0.00"), printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        //    yPos = yPos + printfont.GetHeight(ev.Graphics) + 1;
        //    ev.Graphics.DrawLine(pen, 0, yPos, 300, yPos);
        //    ev.Graphics.DrawString("Narration    " + pos.PaymentNarration, printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        //    yPos = yPos + printfont.GetHeight(ev.Graphics);
        //    ev.Graphics.DrawString("You Were Served By    " + pos.Username, printfont, Brushes.Black, leftMargin, yPos, new StringFormat());
        //    yPos = yPos + printfont.GetHeight(ev.Graphics);
        //    ev.Graphics.DrawLine(pen, 0, yPos, 300, yPos);
        //    printfont = new Font("Arial Narrow", 8);
        //    yPos = yPos + printfont.GetHeight(ev.Graphics);
        //    ev.Graphics.DrawString("**Thank you For Shopping with us!!!!**", printfont, Brushes.Black, leftMargin+35, yPos, new StringFormat());
        //}
        //private string Trancute(string stringtotrancuate, int length)
        //{
        //    if (stringtotrancuate.Length <= length)
        //    {
        //        return stringtotrancuate.PadRight(length);
        //    }
        //    else
        //    {
        //        string trancuated = stringtotrancuate.Substring(0, length);
        //        return trancuated;
        //    }
        //}

    }
}

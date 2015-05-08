using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asal
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw = new BackgroundWorker();
        List<decimal> asallar = new List<decimal>();
        decimal bulunan = 0;
        DateTime starttime;

        public Form1()
        {
            InitializeComponent();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState.ToString().StartsWith("Üzerinde çalışılan: "))
           {
               label3.Text = e.UserState.ToString();
           }
           else if (e.UserState.ToString() == "Finish")
           {
               button1.Enabled = true;
               timer1.Stop();
               MessageBox.Show("Bitti ve " + (DateTime.Now - starttime).ToString("G") + " sürdü, ayrıca " + bulunan + " asal sayı bulundu.");
           }
           else
           {
               asallar.Add(Convert.ToDecimal(e.UserState));
               //numericUpDown1.Value = Convert.ToDecimal(e.UserState);
               listBox1.Items.Add(Convert.ToDecimal(e.UserState));
               label4.Text = "Bulunan En Büyük: " + e.UserState.ToString();
               bulunan++;
               label6.Text = "Bulunan Asal Sayı Miktarı: " + bulunan;
           }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            decimal from = Convert.ToDecimal(e.Argument.ToString().Substring(0, e.Argument.ToString().IndexOf("-*-*-*-")));
            decimal to = Convert.ToDecimal(e.Argument.ToString().Replace(from + "-*-*-*-", ""));

            if (from < 2)
            {
                bw.ReportProgress(0, 2);
            }
            if (from < 3)
            {
                bw.ReportProgress(0, 3);
            }
            if (from < 5)
            {
                bw.ReportProgress(0, 5);
            }
            if (from < 7)
            {
                bw.ReportProgress(0, 7);
            }
            if (from < 11)
            {
                bw.ReportProgress(0, 11);
            }

            for (decimal i = from; i <= to; i++)
            {
                bw.ReportProgress(0, "Üzerinde çalışılan: " + i);
                if ((i % 3 != 0) && (i % 2 != 0) && (i % 5 != 0) && (i % 7 != 0) && (i % 11 != 0))
                {
                    bool hicciktimi = false;
                    for (decimal j = 2; j < i - 2; j++)
                    {
                        if (i % (j + 1) == 0)
                        {
                            hicciktimi = true;
                            break;
                        }
                    }
                    if (hicciktimi == false)
                    {
                        if (i != 0 && i != 1)
                        {
                            bw.ReportProgress(0, i);
                        }
                    }
                }
            }
            bw.ReportProgress(0, "Finish");
        }

        //void bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    decimal from = Convert.ToDecimal(e.Argument.ToString().Substring(0, e.Argument.ToString().IndexOf("-*-*-*-")));
        //    decimal to = Convert.ToDecimal(e.Argument.ToString().Replace(from + "-*-*-*-", ""));

        //    if (from < 2)
        //    {
        //        bw.ReportProgress(0, 2);
        //    }
        //    if (from < 3)
        //    {
        //        bw.ReportProgress(0, 3);
        //    }
        //    if (from < 5)
        //    {
        //        bw.ReportProgress(0, 5);
        //    }
        //    if (from < 7)
        //    {
        //        bw.ReportProgress(0, 7);
        //    }
        //    if (from < 11)
        //    {
        //        bw.ReportProgress(0, 11);
        //    }

        //    for (decimal i = from; i <= to; i++)
        //    {
        //        bw.ReportProgress(0, "Working on: " + i);
        //        if ((i % 3 != 0) && (i % 2 != 0) && (i % 5 != 0) && (i % 7 != 0) && (i % 11 != 0))
        //        {
        //            bool hicciktimi = false;
        //            for (decimal j = 2; j < i - 2; j++)
        //            {
        //                if (i % (j + 1) == 0)
        //                {
        //                    hicciktimi = true;
        //                    break;
        //                }
        //            }
        //            if (hicciktimi == false)
        //            {
        //                if (i != 0 && i != 1)
        //                {
        //                    bw.ReportProgress(0, i);
        //                }
        //            }
        //        }
        //    }
        //    bw.ReportProgress(0, "Finish");
        //}

        //void bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    decimal from = Convert.ToDecimal(e.Argument.ToString().Substring(0, e.Argument.ToString().IndexOf("-*-*-*-")));
        //    decimal to = Convert.ToDecimal(e.Argument.ToString().Replace(from + "-*-*-*-", ""));

        //    for (decimal i = from; i <= to; i++)
        //    {
        //        bw.ReportProgress(0, "Working on: " + i);
        //        decimal sonuc = 0;
        //        for (int z = 0; z <= i.ToString().Length - 1; z++)
        //        {
        //            sonuc += decimal.Parse(i.ToString().Substring(z, 1));
        //        }
        //        if ((sonuc % 3) != 0)
        //        {
        //            if (!(i.ToString().EndsWith("0") || i.ToString().EndsWith("2") || i.ToString().EndsWith("4") || i.ToString().EndsWith("6") || i.ToString().EndsWith("8")))
        //            {
        //                bool hicciktimi = false;
        //                for (decimal j = 2; j < i - 2; j++)
        //                {
        //                    if (i % (j + 1) == 0)
        //                    {
        //                        hicciktimi = true;
        //                        break;
        //                    }
        //                }
        //                if (hicciktimi == false)
        //                {
        //                    if (i != 0 && i != 1)
        //                    {
        //                        bw.ReportProgress(0, i);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    bw.ReportProgress(0, "Finish");
        //}

        //void bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    decimal from = Convert.ToDecimal(e.Argument.ToString().Substring(0, e.Argument.ToString().IndexOf("-*-*-*-")));
        //    decimal to = Convert.ToDecimal(e.Argument.ToString().Replace(from + "-*-*-*-", ""));

        //    for (decimal i = from; i <= to; i++)
        //    {
        //        bw.ReportProgress(0, "Working on: " + i);
        //        decimal sonuc = 0;
        //        for (int z = 0; z <= i.ToString().Length - 1; z++)
        //        {
        //            sonuc += decimal.Parse(i.ToString().Substring(z, 1));
        //        }
        //        if ((sonuc % 3) != 0)
        //        {
        //            if (!(i.ToString().EndsWith("0") || i.ToString().EndsWith("2") || i.ToString().EndsWith("4") || i.ToString().EndsWith("6") || i.ToString().EndsWith("8")))
        //            {
        //                bool hicciktimi = false;
        //                for (decimal j = 0; j < i - 2; j++)
        //                {
        //                    decimal x = i / (j + 1);
        //                    if (!(x.ToString().Contains(".") || x.ToString().Contains(",") || x == i))
        //                    {
        //                        hicciktimi = true;
        //                        break;
        //                    }
        //                }
        //                if (hicciktimi == false)
        //                {
        //                    if (i != 0 && i != 1)
        //                    {
        //                        bw.ReportProgress(0, i);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    bw.ReportProgress(0, "Finish");
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bulunan = 0;
                starttime = DateTime.Now;
                timer1.Start();
                string str = (numericUpDown1.Value + "-*-*-*-" + numericUpDown2.Value);
                bw.RunWorkerAsync(str);

                button1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string texttogo = "Çalışma Süresi: " + (DateTime.Now - starttime).ToString("G");
            label7.Text = texttogo;
        }

        string icerik = "";

        private void button2_Click(object sender, EventArgs e)
        {
            icerik = "";
            foreach (decimal str in listBox1.Items)
            {
                icerik += str.ToString() + Environment.NewLine;
            }
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            System.IO.File.WriteAllText(saveFileDialog1.FileName, icerik);
        }
    }
}

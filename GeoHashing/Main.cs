using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GeoHashing
{
    public partial class Main : Form
    {
        private void BuildCode()
        {
            Code.Text = "";
            try
            {
                for (int i = 2; i >= 0; i--)
                    Code.Text += Date.Text.Split("/".ToCharArray())[i] + "-";
                Code.Text += DOW.Text;

                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(Code.Text));

                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                    sBuilder.Append(data[i].ToString("x2"));

                MD5.Text = sBuilder.ToString();

                CoordinatesN.Text = LocationN.Text.Split(".".ToCharArray())[0] + ".";
                CoordinatesN.Text += ConvertToDecimal(MD5.Text.Substring(0, 16)).ToString().Substring(2);

                CoordinatesW.Text = LocationW.Text.Split(".".ToCharArray())[0] + ".";
                CoordinatesW.Text += ConvertToDecimal(MD5.Text.Substring(16, 16)).ToString().Substring(2);
            }
            catch
            { }
        }

        private double ConvertToDecimal(string hex)
        {
            double total = 0;
            int multiplier = 0;

            for (int i = 0; i < 16; i++)
            {
                string c = hex.ToLower().Substring(i, 1);
                switch (c)
                {
                    case "a": multiplier = 10; break;
                    case "b": multiplier = 11; break;
                    case "c": multiplier = 12; break;
                    case "d": multiplier = 13; break;
                    case "e": multiplier = 14; break;
                    case "f": multiplier = 15; break;
                    default: multiplier = Convert.ToInt32(c); break;
                }

                total += multiplier * Math.Pow(16.0, -(i + 1));
            }

            return total;
        }

        public double GetBBCDJIOpening()
        {
            string code = (new UTF8Encoding()).GetString
                (
                    (new WebClient()).DownloadData("http://newsvote.bbc.co.uk/1/shared/fds/hi/business/market_data/ticker/markets/2/default.stm")
                );

            string dowjones = code.Substring(code.IndexOf("Dow Jones"));
            int pos1 = dowjones.IndexOf("<div class=\"stats\">") + 19;
            int pos2 = pos1 + dowjones.Substring(pos1 + 1).IndexOf("<");
            double current = Convert.ToDouble(dowjones.Substring(pos1, pos2 - pos1 + 1));

            int end = dowjones.Substring(pos1).IndexOf("<div class=\"stats\">");
            string snippet = dowjones.Substring(pos1, end);

            double opening;
            if (snippet.IndexOf("<DIV CLASS=\"statslo\">") > -1)
            {
                pos1 = dowjones.IndexOf("<DIV CLASS=\"statslo\">") + 21;
                pos2 = pos1 + dowjones.Substring(pos1 + 1).IndexOf("<");
                double loss = Convert.ToDouble(dowjones.Substring(pos1, pos2 - pos1 + 1));
                opening = current + loss;
            }
            else
            {
                pos1 = dowjones.IndexOf("<DIV CLASS=\"statshi\">") + 21;
                pos2 = pos1 + dowjones.Substring(pos1 + 1).IndexOf("<");
                double gain = Convert.ToDouble(dowjones.Substring(pos1, pos2 - pos1 + 1));
                opening = current - gain;
            }
            return opening;
        }

        /*
         * Works, but I want to show a least some patriotism.
        public double GetCNNDJIOpening()
        {
            string code = (new UTF8Encoding()).GetString
            (
                (new WebClient()).DownloadData("http://money.cnn.com/data/markets/dow/")
            );

            string dowjones = code.Substring(code.IndexOf("Open:"));
            int pos1 = dowjones.IndexOf("<TD class=quotedata>") + 20;
            int pos2 = pos1 + dowjones.Substring(pos1 + 1).IndexOf("<");
            string temp = dowjones.Substring(pos1, pos2 - pos1 + 1);
            double opening = Convert.ToDouble(dowjones.Substring(pos1, pos2 - pos1 + 1));

            return opening;
        }
         * */

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Date.Text = DateTime.Today.ToShortDateString();
            //DOW.Text = GetBBCDJIOpening().ToString();
            BuildCode();
        }

        private void LocationN_TextChanged(object sender, EventArgs e)
        {
            BuildCode();
        }

        private void LocationW_TextChanged(object sender, EventArgs e)
        {
            BuildCode();
        }

        private void Date_TextChanged(object sender, EventArgs e)
        {
            BuildCode();
        }

        private void DOW_TextChanged(object sender, EventArgs e)
        {
            BuildCode();
        }

        private void ViewMap_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome", "http://maps.google.co.uk/maps?q=" +
                CoordinatesN.Text + "," + CoordinatesW.Text);
        }
    }
}
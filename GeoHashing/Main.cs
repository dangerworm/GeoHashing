using System;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GeoHashing
{
    public partial class Main : Form
    {
        private const string DowUrl =
            "http://newsvote.bbc.co.uk/1/shared/fds/hi/business/market_data/ticker/markets/2/default.stm";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Date.Text = DateTime.Today.ToShortDateString();
            DOW.Text = GetBbcDjiOpening().ToString(CultureInfo.InvariantCulture);

            LocationN.TextChanged += (oSender, eArgs) => BuildCode();
            LocationW.TextChanged += (oSender, eArgs) => BuildCode();
            Date.TextChanged += (oSender, eArgs) => BuildCode();
            DOW.TextChanged += (oSender, eArgs) => BuildCode();

            BuildCode();
        }

        private void ViewMap_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome", 
                "http://maps.google.co.uk/maps?q=" + CoordinatesN.Text + "," + CoordinatesW.Text);
        }

        private void BuildCode()
        {
            Code.Text = "";
            try
            {
                var date = DateTime.MinValue;
                var canParse = DateTime.TryParse(Date.Text, out date);
                if (canParse)
                {
                    Code.Text += date.ToString("yyyy-MM-dd-");
                }

                Code.Text += DOW.Text;

                MD5 md5 = new MD5CryptoServiceProvider();
                var data = md5.ComputeHash(Encoding.Default.GetBytes(Code.Text));

                var sBuilder = new StringBuilder();
                foreach (var b in data)
                {
                    sBuilder.Append(b.ToString("x2"));
                }

                MD5.Text = sBuilder.ToString();

                CoordinatesN.Text = LocationN.Text.Split(".".ToCharArray())[0] + ".";
                CoordinatesN.Text += ConvertToDecimal(MD5.Text.Substring(0, 16)).ToString().Substring(2);

                CoordinatesW.Text = LocationW.Text.Split(".".ToCharArray())[0] + ".";
                CoordinatesW.Text += ConvertToDecimal(MD5.Text.Substring(16, 16)).ToString().Substring(2);
            }
            catch
            {
                // ignored
            }
        }

        public double GetBbcDjiOpening()
        {
            var code = string.Empty;
            using (var client = new WebClient())
            {
                code = client.DownloadString(DowUrl);
            }

            var titleJs = code.Substring(code.IndexOf("document.title='Dow ", StringComparison.Ordinal));
            var dowNumbers = titleJs.Substring(titleJs.IndexOf("Dow ", StringComparison.Ordinal) + 4);
            var lastApostrophe = titleJs.IndexOf("'", StringComparison.Ordinal);
            var dowValues = dowNumbers.Substring(0, lastApostrophe + 1)
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            double dow = 0;
            double gainLoss = 0;
            var canParseDow = double.TryParse(dowValues[0], out dow);
            var canParseGainLoss = double.TryParse(dowValues[1], out gainLoss);

            if (canParseDow && canParseGainLoss)
            {
                return dow + gainLoss;
            }

            if (canParseDow)
            {
                return dow;
            }

            return 0;
        }

        /*
         * Works, but I want to show at least some patriotism.
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

        private static double ConvertToDecimal(string hex)
        {
            double total = 0;

            for (var i = 0; i < 16; i++)
            {
                var c = hex.ToLower().Substring(i, 1);
                var multiplier = 0;
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

    }
}
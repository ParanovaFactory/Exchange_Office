using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.LinkLabel;

namespace ExchangeOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"https://www.tcmb.gov.tr/kurlar/today.xml";
            //DOLLAR
            var values = new XmlDocument();
            values.Load(path);
            string dollarBuying = values.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDollarB.Text = dollarBuying;

            string dollarSelling = values.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDollarS.Text = dollarSelling;

            //EURO
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            string euroBuying = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroB.Text = euroBuying;

            string euroSelling = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroS.Text = euroSelling;
        }

        private void btnDollarB_Click(object sender, EventArgs e)
        {
            txtRate.Text = lblDollarB.Text;
            lblType.Text = "Dollar buying";
        }

        private void btnDollarS_Click(object sender, EventArgs e)
        {
            txtRate.Text = lblDollarS.Text;
            lblType.Text = "Dollar selling";
        }

        private void btnEuroB_Click(object sender, EventArgs e)
        {
            txtRate.Text = lblEuroB.Text;
            lblType.Text = "Euro buying";
        }

        private void btnEuroS_Click(object sender, EventArgs e)
        {
            txtRate.Text = lblEuroS.Text;
            lblType.Text = "Euro selling";
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (lblType.Text.EndsWith("selling"))
            {
                float rate = float.Parse(txtRate.Text);
                float amount = float.Parse(txtAmount.Text);
                float price = amount / rate;
                txtPrice.Text = price.ToString();
            }
            else
            {
                float rate = float.Parse(txtRate.Text);
                float amount = float.Parse(txtAmount.Text);
                float price = amount * rate;
                txtPrice.Text = price.ToString();
            }
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Type: " + lblType.Text +  " Rate: " + txtRate.Text + " Amunt: " + txtAmount.Text + " Price: " + txtPrice.Text);
        }
    }
}

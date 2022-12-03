using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcutorMachine
{
    public partial class Form1 : Form
    {
        //Field
        double result = 0;
        string operation=string.Empty;
        string fstNum, ScdNum;
        bool enterValue = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnMathOperation_Click(object sender, EventArgs e)
        {
            if (result != 0) BtnEquals.PerformClick();
            else result = double.Parse(TxtDisplay1.Text);

            Button bttn = (Button)sender;
            operation = bttn.Text;
            enterValue = true;
            if (TxtDisplay1.Text != "0")
            {
                TxtDisplay2.Text = fstNum = $"{result} {operation}";
                TxtDisplay1.Text = string.Empty;
            }
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            ScdNum = TxtDisplay1.Text;
            TxtDisplay2.Text = $"{TxtDisplay2.Text} {TxtDisplay1.Text}=";
            if (TxtDisplay1.Text!=string.Empty)
            {
                if(TxtDisplay1.Text == "0") TxtDisplay2.Text = string.Empty;
                switch (operation)
                {
                    case "+":
                        TxtDisplay1.Text = (result + double.Parse(TxtDisplay1.Text)).ToString();
                        RchBoxDisplayHistory.AppendText($"{fstNum} {ScdNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "-":
                        TxtDisplay1.Text = (result - double.Parse(TxtDisplay1.Text)).ToString();
                        RchBoxDisplayHistory.AppendText($"{fstNum} {ScdNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "*":
                        TxtDisplay1.Text = (result * double.Parse(TxtDisplay1.Text)).ToString();
                        RchBoxDisplayHistory.AppendText($"{fstNum} {ScdNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "/":
                        TxtDisplay1.Text = (result / double.Parse(TxtDisplay1.Text)).ToString();
                        RchBoxDisplayHistory.AppendText($"{fstNum} {ScdNum} = {TxtDisplay1.Text}\n");
                        break;
                    default: TxtDisplay2.Text = $"{TxtDisplay1.Text}";
                        break;
                }

                result = Double.Parse(TxtDisplay1.Text);
                operation = string.Empty;
            }
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            PnlHistory.Height = (PnlHistory.Height == 5) ? PnlHistory.Height = 345:5;
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            RchBoxDisplayHistory.Clear();
            if (RchBoxDisplayHistory.Text == string.Empty)
            {
                RchBoxDisplayHistory.Text = "there's no history yet";
            }
        }

        private void BtnBackSpace_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text.Length > 0) TxtDisplay1.Text = TxtDisplay1.Text.Remove(TxtDisplay1.Text.Length - 1, 1);
            if (TxtDisplay1.Text == string.Empty) TxtDisplay1.Text = "0";
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
            TxtDisplay2.Text = string.Empty;
            result = 0;
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
        }

        private void BtnOperation_Click(object sender, EventArgs e)
        {
            Button bttn = (Button)sender;
            operation = bttn.Text;
            switch (operation)
            {
                case "√x":
                    TxtDisplay2.Text = $"√{TxtDisplay1.Text}";
                    TxtDisplay2.Text = Convert.ToString(Math.Sqrt(Double.Parse(TxtDisplay1.Text)));
                    break;
                case "x² ":
                    TxtDisplay2.Text = $"{TxtDisplay1.Text}²";
                    TxtDisplay2.Text = Convert.ToString((Convert.ToDouble(TxtDisplay1.Text)) * (Convert.ToDouble(TxtDisplay1.Text)));
                    break;
                case "1/x":
                    TxtDisplay2.Text = $"1/{TxtDisplay1.Text}";
                    TxtDisplay2.Text = Convert.ToString(1.0*(Double.Parse(TxtDisplay1.Text)));
                    break;
                case "%":
                    TxtDisplay2.Text = $"%{TxtDisplay1.Text}";
                    TxtDisplay2.Text = Convert.ToString((Double.Parse(TxtDisplay1.Text)) / (Double.Parse(TxtDisplay1.Text)));
                    break;
                case "±":
                    TxtDisplay2.Text = Convert.ToString(-1*(Double.Parse(TxtDisplay1.Text)));
                    break;
            }
            RchBoxDisplayHistory.AppendText($"{TxtDisplay2.Text} = {TxtDisplay1.Text}\n");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text == "0" || enterValue) TxtDisplay1.Text = string.Empty;

            enterValue = false;
            Button bttn = (Button)sender;
            if (bttn.Text == ".")
            {
                if (!TxtDisplay1.Text.Contains("."))
                {
                    TxtDisplay1.Text = TxtDisplay1.Text + bttn.Text;
                }
            }
            else TxtDisplay1.Text = TxtDisplay1.Text + bttn.Text;

        }
    }

}

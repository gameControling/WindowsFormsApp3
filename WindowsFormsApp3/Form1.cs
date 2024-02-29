using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        int i = 0;
        double otv = 0, chis = 0, chisSZap = 1;
        double[] masChis = new double[1];
        char[] simv = new char[1];
        bool vvodChis = false, newPrim = false, otrOrPoloj = true;

        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            radioButton1.Checked = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += '1';
            dobavChislo(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += '2';
            dobavChislo(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += '3';
            dobavChislo(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += '4';
            dobavChislo(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += '5';
            dobavChislo(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += '6';
            dobavChislo(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += '7';
            dobavChislo(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += '8';
            dobavChislo(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += '9';
            dobavChislo(9);
        }

        private void button10_Click(object sender, EventArgs e)
        { 
            textBox1.Text += '0';
            dobavChislo(0);
        } 

        private void dobavChislo(double newChis)
        {
            if (chisSZap == 1)
            {
                chis *= 10;
                if(newChis != 0)
                {
                    if (otrOrPoloj == true)
                    {
                        chis += newChis;
                    }
                    else
                    {
                        chis -= newChis;
                    }
                }
            }
            else
            {
                if(newChis != 0)
                {
                    if(otrOrPoloj == true)
                    {
                        chis += chisSZap * newChis;
                    }
                    else
                    {
                        chis -= chisSZap * newChis;
                    }
                }
                chisSZap /= 10;
            }
            vvodChis = true;
        }
        
        private void button12_Click(object sender, EventArgs e)
        {
            if(vvodChis == true)
            {
                textBox1.Text += ',';
                vvodChis = false;
                chisSZap = 0.1;
            }
        }


        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
            vvodChis = false;
            masChis = new double[1];
            simv = new char[1];
            otv = 0;
            otrOrPoloj = true;
            chisSZap = 1;
            masChis[0] = 0;
            simv[0] = ' ';
            i = 0;
        }  
        
        private void button18_Click(object sender, EventArgs e)
        {
            Array.Resize(ref masChis, masChis.Length + 1);
            masChis[i] = chis;
            if(radioButton1.Checked == true)
            { 
                label1.Text += textBox1.Text + '=';
                textBox1.Text = "";

                for(int j = 0; j < simv.Length; j++)
                {
                    if (simv[j] == '*')
                    {
                        masChis[j] *= masChis[j + 1];
                        masChis[j + 1] = 0;
                    }
                    else if (simv[j] == '/')
                    {
                        masChis[j] /= masChis[j + 1];
                        masChis[j + 1] = 0;
                    }
                }
                for(int j = 0; j < masChis.Length; j++)
                {
                    otv += masChis[j];
                }

                otv = Math.Round(otv, 3);
                label1.Text += Convert.ToString(otv);
            }
            else if(radioButton2.Checked == true)
            {
                double x1 = 0, x2 = 0, D = masChis[1] * masChis[1] - 4 * masChis[0] * masChis[2];
                x1 = (-masChis[1] + Math.Sqrt(D)) / (masChis[0] * 2);
                x2 = (-masChis[1] - Math.Sqrt(D)) / (masChis[0] * 2);
                label1.Text = "X1=" + Convert.ToString(x1) + "    X2=" + Convert.ToString(x2);
            }
            else if(radioButton3.Checked == true)
            {
                label1.Text = Convert.ToString(2 * (masChis[0] + masChis[1])) + " = 2 * (" + Convert.ToString(masChis[0]) + " + " + Convert.ToString(masChis[1]) + ')';
            }
            else if(radioButton4.Checked == true)
            {
                label1.Text = Convert.ToString(masChis[0] * masChis[1]) + " = " + Convert.ToString(masChis[0]) + " * " + Convert.ToString(masChis[1]);
            }
            else if(radioButton5.Checked == true)
            {
                label1.Text = Convert.ToString(masChis[0] * 8) + "*10^16 = " + Convert.ToString(masChis[0]) + " * 299 792 458^2";
            }
            chis = 0;
            vvodChis = false;
            newPrim = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                label2.Text = "";
                button15.Enabled = false;
                button14.Enabled = false;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                label2.Text = "";
                button15.Enabled = true;
                button14.Enabled = true;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dobavZnak('+', true);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dobavZnak('-', false);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(radioButton3.Checked || radioButton4.Checked || radioButton5.Checked)
            {
                if((radioButton3.Checked || radioButton4.Checked) && masChis.Length < 3)
                {
                    dobavZnak(' ', true);
                }
                else if(radioButton5.Checked && masChis.Length < 2)
                { 
                    dobavZnak(' ', true);
                }
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if(label1.Text == "")
            {
                label2.Text = "S = a * b";
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                label2.Text = "P = 2 * (a + b)";
            }
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                label2.Text = "E = m * c^2";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dobavZnak('*', true);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dobavZnak('/', true);
        }

        bool dopProvIfKvad()
        {
            if(radioButton2.Checked == true && masChis.Length <= 2)
            {
                return true;
            }
            else if(radioButton1.Checked == true || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked)
            {
                return true;
            }
            return false;
        }

        private void dobavZnak(char znak, bool otOrPol)
        {
            if (vvodChis == true && dopProvIfKvad())
            {   
                if(radioButton1.Checked || radioButton2.Checked)
                {
                    if (radioButton1.Checked == true)
                    {
                        label1.Text += textBox1.Text + znak;
                    }
                    else if( radioButton2.Checked == true)
                    {
                        if(masChis.Length == 1)
                        {
                            label1.Text += textBox1.Text + "X^2" + znak;
                        }
                        else
                        {
                            label1.Text += textBox1.Text + "X" + znak;
                        }
                    }

                    simv[i] = znak;
                }
                else if(radioButton3.Checked || radioButton4.Checked || radioButton5.Checked)
                {
                    if(radioButton3.Checked)
                    {
                        label1.Text += "P = 2 * (" + textBox1.Text + " + b)"; 
                    }
                    else if(radioButton4.Checked)
                    {
                        label1.Text += "S = " + textBox1.Text + " * b";
                    }
                    else if(radioButton5.Checked)
                    {
                        label1.Text += "E = " + textBox1.Text + " * c^2";
                    }
                }
                masChis[i] = chis;
                textBox1.Text = "";
                i++;
                if (i == simv.Length)
                {
                    Array.Resize(ref masChis, masChis.Length + 1);
                    Array.Resize(ref simv, simv.Length + 1);
                }
                chis = 0;
                vvodChis = false;
                chisSZap = 1;
                otrOrPoloj = otOrPol;
            }
        }
    }
}

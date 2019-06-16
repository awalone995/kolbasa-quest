using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShKKQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {  InitializeComponent();
          
        }

      
        static int kolbasa = 0;
        static int money = 0;
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void kolbasabutton_Click_1(object sender, EventArgs e)
        {
            kolbasa++;
          
           
            initkolb();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
        
        public void initkolb()
        {
            if(kolbasa < 0)
            {
                kolbasa = 0;
            }
            if (money < 0)
            {
                money = 0;
            }
            string kolbasacounter = kolbasa.ToString();
            string moneycounter = money.ToString();
            klabel.Text = (kolbasacounter);


            moneylab.Text = (moneycounter);

            progressBar1.Value = kolbasa;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            int sellcount = 0;
            int.TryParse(textBox1.Text, out sellcount);
            if (sellcount <= kolbasa)
            {
                kolbasa -= sellcount;
                money += sellcount;
            }  
            initkolb();
         


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            shop a = new shop();
            a.Show();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void buymeat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

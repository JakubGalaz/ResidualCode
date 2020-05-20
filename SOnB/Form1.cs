using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace SOnB
{


    public partial class Form1 : Form
    {

        
        public string info;
        Program program;


        //   Comparator comparator;
        public Form1()
        {
          InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;


        }



        public void setInformation(string data)
        {

            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
                backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
                backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
                backgroundWorker1.RunWorkerAsync();
            }

            label5.Text = "halo";
            Console.WriteLine(data);
            Application.DoEvents();
            label5.ResetText();

 



        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label3.Text = "Complete";
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label6.Text = "zmina!";
    
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void button1_Click(object sender, EventArgs e)
        {


            var system = listBox1.SelectedItem;
            string mode = system.ToString();
            program = new Program();
            program.setMode(mode);

 



            program.setFirstNumber(textBox2.Text);
            program.setSecondNumber(textBox3.Text);
            program.setModuloNumber(textBox4.Text);

            program.start();

        }

        private void changeLabel(string data)
        {
            label5.Text = "texciorr";
            label7.Text = data;
          Console.WriteLine("informacja z change label: " + data);


        }


    

  

        public void changeInfo(string data)
        {

            Application.DoEvents();
            Console.WriteLine("changeInfo");
            Console.WriteLine(data);
            label6.Text = "jakiesi info z change info";
            label7.Text = data;
            label6.Refresh();
            changeLabel("xd");
            changeLabelFive();
  

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            label2.Text = "12";
        }



        private void bin_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-1^]"))
            {
                e.Handled = true;
            }
        }

        private void dec_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^]"))
            {
  
                e.Handled = true;
            }
        }

        private void hex_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            

            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^+^a-z^+^A-Z^]"))
            {

                e.Handled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            button1.Enabled = false;


            var system = listBox1.SelectedItem;
            string mode = system.ToString();

            Console.WriteLine(mode);
            validation(mode);



        }


        private void validation(string mode)
        {
            if (mode == "BIN")
            {
                textBox2.KeyPress += new KeyPressEventHandler(bin_KeyPress);
                textBox3.KeyPress += new KeyPressEventHandler(bin_KeyPress);
                textBox4.KeyPress += new KeyPressEventHandler(bin_KeyPress);
            }
            if (mode == "DEC")
            {
                textBox2.KeyPress += new KeyPressEventHandler(dec_KeyPress);
                textBox3.KeyPress += new KeyPressEventHandler(dec_KeyPress);
                textBox4.KeyPress += new KeyPressEventHandler(dec_KeyPress);

            }
            if (mode == "HEX")
            {
                textBox2.KeyPress += new KeyPressEventHandler(hex_KeyPress);
                textBox3.KeyPress += new KeyPressEventHandler(hex_KeyPress);
                textBox4.KeyPress += new KeyPressEventHandler(hex_KeyPress);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            ifEmpty();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ifEmpty();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            ifEmpty();
        }

        private void ifEmpty()
        {

            button1.Enabled = false;
            if (textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "")
            {
                button1.Enabled = true;
            }
        }
    }
}

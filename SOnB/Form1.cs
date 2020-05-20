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

            label5.Text = "halo";
            Console.WriteLine(data);
            label5.Update();

            backgroundWorker1.ReportProgress(0);



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


            program = new Program();

            program.setMode(textBox1.Text);
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
            changeLabelFive();
  

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Text = info;
        }
    }
}

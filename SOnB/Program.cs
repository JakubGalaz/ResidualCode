using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOnB
{
    class Program
    {
        public static string modeG;
        public static string firstNumberG;
        public static string secondNumberG;
        public static string moduloNumberG;


        public void setMode(string mode)
        {
            modeG = mode;

        }

        public void setFirstNumber(string data)
        {
            firstNumberG = data;

        }
        public void setSecondNumber(string data)
        {
            secondNumberG = data;

        }

        public void setModuloNumber(string data)
        {
            moduloNumberG = data;

        }


        public void start()
        {



   
            {
               

               MultiplierSystem multiplierSystem1 = new MultiplierSystem();
                MultiplierSystem multiplierSystem2 = new MultiplierSystem();
                EntranceElement entranceElement = new EntranceElement();
                Comparator comparator = new Comparator();
                Thread[] threads = new Thread[4];








                string mode = modeG;
                string firstNumber = firstNumberG;
                string secondNumber = secondNumberG;
                string moduloNumber = moduloNumberG;



                threads[0] = new Thread(delegate () { entranceElement.SendData(mode, firstNumber, secondNumber, moduloNumber); });
                threads[0].Start();
                threads[1] = new Thread(delegate () { comparator.getData(); });
                threads[1].Start();

                threads[2] = new Thread(delegate () { multiplierSystem1.getData(1); });
                threads[2].Start();
                threads[2].Join();

                threads[3] = new Thread(delegate () { multiplierSystem2.getData(2); });
                threads[3].Start();
                threads[3].Join();

                threads[0].Join();
                threads[1].Join();

                threads[0].Abort();
                threads[1].Abort();
                threads[2].Abort();
                threads[3].Abort();

                // Console.ReadKey();



            }




        }


    }
}

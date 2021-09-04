using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Media;
namespace alarm
{
    public partial class Form1 : Form
    {
      machine m = new machine();
      List<String> c = new List<String>();
      
        public Form1()
        {
            InitializeComponent();
            m.EtatAlarm += sonner;
            remplir();
        }

        public void remplir()
        {
            c.Add("80");
            c.Add("90");
            c.Add("100");
            c.Add("120");
            c.Add("95");
            c.Add("100");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < 6; i++)
            {

                label2.Text = c[i];
               
                m.Temperature = Convert.ToInt32(c[i]); 
                
                
                Thread.Sleep(2000);
                
                
            }
        }
        
       public class TempsArgs : EventArgs
        {
            int tps;

            public int Tps
            {
                get { return tps; }
                set { tps = value; }
            }
            public TempsArgs(int t)
            {
                tps = t;
            }
        }
        public class machine
        {
            public event EventHandler<TempsArgs> EtatAlarm;
            private int _temperature;

            public int Temperature
            {
                get { return _temperature; }
                set
                {
                    
                    _temperature = value;

                    if (EtatAlarm != null)
                        EtatAlarm(this, new TempsArgs(value));
                }
            }

        }


       
            public void sonner(object sender, TempsArgs e)
        {
            SoundPlayer sp = new SoundPlayer("a.wav");
                if (e.Tps >= 100)
                {
                   
                    sp.Play();
                    panel1.BackgroundImage = Image.FromFile("2.jpg");

                    MessageBox.Show("temperature depasse 100");
                }
                else
                {
                    sp.Stop();
                    panel1.BackgroundImage=Image.FromFile("1.jpg");
                    MessageBox.Show("temperature normal");
                }
            }


          
        
      
    }
}

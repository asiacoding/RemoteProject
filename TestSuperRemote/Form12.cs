using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSuperRemote
{
    public partial class MainFrom : Form
    {
        SerialPort MyPort = null;
        string Com = "";
        Timer timer = new Timer();
        bool IsOpneCom = false;
        public MainFrom()
        {
            InitializeComponent();
            
            Load += Form1_Load;
            
            ListBox.CheckForIllegalCrossThreadCalls = false;
            
            CheckForIllegalCrossThreadCalls = false;
            
            timer = new Timer()
            {
                Interval = 200,
                Enabled = true,
            };

            timer.Tick += Timer_Tick;

         
            foreach (var item in bab.Controls) //Set Image
                if (item is PictureBox GetBace) GetBace.ImageLocation = "images.png"; 

            ChangeCodeDevice(); // Hide
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!IsOpneCom) return;

                if (MyPort != null)
                {
                    if (MyPort.IsOpen)
                        MyPort.Close();

                    MyPort.Open();
                    string1 = MyPort.ReadExisting();
                    DrowingText();

                    AllObjectTest();
                    string1 = "";
                    MyPort.Close();

                }
            }
            catch (Exception )
            {
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RefComPost();

        }
        void RefComPost()
        {
            cb_PortComNames.Items.Clear();
            foreach (var item in SerialPort.GetPortNames())
            {
                cb_PortComNames.Items.Add(item);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Com = cb_PortComNames.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        private void LayoutOpnePort(bool Opened)
        {
            //  if Button OpnePorts is Enabled thne MyPort is closed
            OpnePorts.Enabled = !Opened;//is null =
            btClose.Enabled = !OpnePorts.Enabled;
            cb_PortComNames.Enabled = OpnePorts.Enabled;
            btnUpdataDataList.Enabled = OpnePorts.Enabled;
            IsOpneCom = !OpnePorts.Enabled;
        }
        string string1 = "";
        void DrowingText()
        {
            if (!string.IsNullOrEmpty(string1))
            {
                MainChat.Items.Add(string1);
                //MainChat.scroll
           //     MainChat.ScrollAlwaysVisible = false;
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            MyPort.Close();
            LayoutOpnePort(false);
        }
        private void btnUpdataDataList_Click(object sender, EventArgs e)
        {
            RefComPost();
        }

        private void ReferchPins(TextBox Trget, PictureBox Pic)
        {
            if (string1 == "")
            {
                return;
            }

            if (!string.IsNullOrEmpty(Trget.Text))
            {
                if (string1.Contains(Trget.Text))
                {

                    if (Pic.ImageLocation == "images.png")
                        Pic.ImageLocation = "imageRed.png";
                    else
                        Pic.ImageLocation = "images.png";
                }
            }
        }

        private void AllObjectTest()
        {
            ReferchPins(textBox1, pictureBox1);
            ReferchPins(textBox2, pictureBox2);
            ReferchPins(textBox3, pictureBox3);
            ReferchPins(textBox4, pictureBox4);
            ReferchPins(textBox5, pictureBox5);
            ReferchPins(textBox6, pictureBox6);
            ReferchPins(textBox7, pictureBox7);
            ReferchPins(textBox8, pictureBox8);
            ReferchPins(textBox9, pictureBox9);
            ReferchPins(textBox10, pictureBox10);
            ReferchPins(textBox11, pictureBox11);
            ReferchPins(textBox12, pictureBox12);
            ReferchPins(textBox13, pictureBox13);
            ReferchPins(textBox14, pictureBox14);
            ReferchPins(textBox15, pictureBox15);
            ReferchPins(textBox16, pictureBox16);
            ReferchPins(textBox17, pictureBox17);
            ReferchPins(textBox18, pictureBox18);
            ReferchPins(textBox19, pictureBox19);
            
            ReferchPins(textBox20, pictureBox20);
            ReferchPins(textBox21, pictureBox21);
            ReferchPins(textBox22, pictureBox22);
            ReferchPins(textBox23, pictureBox23);
            ReferchPins(textBox24, pictureBox24);
            ReferchPins(textBox25, pictureBox25);
            ReferchPins(textBox26, pictureBox26);
            ReferchPins(textBox27, pictureBox27);
            ReferchPins(textBox28, pictureBox28);
            ReferchPins(textBox29, pictureBox29);
            ReferchPins(textBox30, pictureBox30);
            ReferchPins(textBox31, pictureBox31);

        }

        private void OpnePorts_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Com))
                {
                    MessageBox.Show("Choose First [Port com] << ");
                    return;
                }
                if ((MyPort != null) && MyPort.IsOpen)
                {
                    MessageBox.Show("Your are Opne ....");
                    return;
                }
                MyPort = new SerialPort(Com, 9600, Parity.None, 8, StopBits.One);

                if (MyPort.IsOpen)
                    MyPort.Close();

                MyPort.Open();
                LayoutOpnePort(true);
            }
            catch (Exception ex)
            {
                LayoutOpnePort(MyPort != null);
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainChat.Items.Clear();
        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeCodeDevice();
        }


        private void ChangeCodeDevice()
        {
            textBox1.Visible =
            textBox2.Visible =
            textBox3.Visible =
            textBox4.Visible =
            textBox5.Visible =
            textBox6.Visible =
            textBox7.Visible =
            textBox8.Visible =
            textBox9.Visible =
            textBox10.Visible =
            textBox11.Visible = 
            textBox12.Visible = 
            textBox13.Visible = 
            textBox14.Visible = 
            textBox15.Visible = 
            textBox16.Visible = 
            textBox17.Visible = 
            textBox18.Visible = 
            textBox19.Visible =
            textBox20.Visible =
            
            textBox21.Visible =
            textBox22.Visible =
            textBox23.Visible =
            textBox24.Visible =
                   
            textBox25.Visible =
            textBox26.Visible =
            textBox27.Visible =
            textBox28.Visible =

            textBox29.Visible =
            textBox30.Visible =

            textBox31.Visible =


                !textBox1.Visible;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

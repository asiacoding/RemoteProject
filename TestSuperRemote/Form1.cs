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
    public partial class Form1 : Form
    {
        SerialPort MyPort = null;
        string Com = "";
        Timer timer = new Timer();
        bool IsOpneCom = false;
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            ListBox.CheckForIllegalCrossThreadCalls = false;
            CheckForIllegalCrossThreadCalls = false;
            timer = new Timer() { Interval = 200, Enabled = true, };
            timer.Tick += Timer_Tick;

            pictureBox1.Image = Properties.Resources.images;
            pictureBox2.Image = Properties.Resources.images;
            pictureBox3.Image = Properties.Resources.images;
            pictureBox4.Image = Properties.Resources.images;
            pictureBox5.Image = Properties.Resources.images;
            pictureBox6.Image = Properties.Resources.images;
            pictureBox7.Image = Properties.Resources.images;
            pictureBox8.Image = Properties.Resources.images;
            pictureBox9.Image = Properties.Resources.images;
            pictureBox10.Image = Properties.Resources.images;
            pictureBox11.Image = Properties.Resources.images;
            pictureBox12.Image = Properties.Resources.images;
            pictureBox13.Image = Properties.Resources.images;
            pictureBox14.Image = Properties.Resources.images;
            pictureBox15.Image = Properties.Resources.images;
            pictureBox16.Image = Properties.Resources.images;
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
            catch (Exception)
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
        private void LayoutOpnePort(bool Opened)
        {
            //if Button OpnePorts is Enabled thne MyPort is closed
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

                MainChat.ScrollAlwaysVisible = false;
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

        private void ReferchPins(TextBox Trget,PictureBox Pic)
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
            ReferchPins(textBox1,pictureBox1);
            ReferchPins(textBox2,pictureBox2);
            ReferchPins(textBox3,pictureBox3);
            ReferchPins(textBox4,pictureBox4);
            ReferchPins(textBox5,pictureBox5);
            ReferchPins(textBox6,pictureBox6);
            ReferchPins(textBox7,pictureBox7);
            ReferchPins(textBox8,pictureBox8);
            ReferchPins(textBox9,pictureBox9);
            ReferchPins(textBox10,pictureBox10);
            ReferchPins(textBox11,pictureBox11);
            ReferchPins(textBox12,pictureBox12);
            ReferchPins(textBox13,pictureBox13);
            ReferchPins(textBox14,pictureBox14);
            ReferchPins(textBox15,pictureBox15);
            ReferchPins(textBox16,pictureBox16);
        }




    }
}

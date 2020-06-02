using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsAppMCLab9
{
    public partial class Form1 : Form
    {
        private const byte slave_1_address = 0x43;
        private const byte slave_2_address = 0x44;
        private const byte slave_3_address = 0x45;
        private const byte commandRead = 0xB1;
        private const byte commandWrite = 0xA1;
        private const byte motor_A_address = 0xC0;
        private const byte motor_B_address = 0xC1;
        private const byte set_position_address = 0xE3;
        private const byte command_start = 0xE6;
        private const byte command_stop = 0xE5;
        private const byte one_phase_mode = 0xE0;
        private const byte two_phase_mode = 0xE1;
        private const byte half_step_mode = 0xE2;
        private const byte set_speed_prescalar_address = 0xE4;
        private int number_slaves = 0;
        private const int delay = 20;//for Proteus
        private bool flag = true;
        private byte slave_address = slave_1_address;
        private struct Elements
        {
            public int hScroll_A_value;
            public int hScroll_B_value;
            public int comboBox_modes_A_value;
            public int comboBox_modes_B_value;
            public int hScroll_speed_A_value;
            public int hScroll_speed_B_value;
        } 
        private byte[] block = new byte[6];
        private Elements[] elements = new Elements[3];
        private readonly byte[] CRC_8_ROHS_table =  {
            0x0,  0x91, 0xe3, 0x72, 0x7,  0x96, 0xe4, 0x75, 0xe,  0x9f, 0xed, 0x7c, 0x9,  0x98, 0xea, 0x7b,
            0x1c, 0x8d, 0xff, 0x6e, 0x1b, 0x8a, 0xf8, 0x69, 0x12, 0x83, 0xf1, 0x60, 0x15, 0x84, 0xf6, 0x67,
            0x38, 0xa9, 0xdb, 0x4a, 0x3f, 0xae, 0xdc, 0x4d, 0x36, 0xa7, 0xd5, 0x44, 0x31, 0xa0, 0xd2, 0x43,
            0x24, 0xb5, 0xc7, 0x56, 0x23, 0xb2, 0xc0, 0x51, 0x2a, 0xbb, 0xc9, 0x58, 0x2d, 0xbc, 0xce, 0x5f,
            0x70, 0xe1, 0x93, 0x2,  0x77, 0xe6, 0x94, 0x5,  0x7e, 0xef, 0x9d, 0xc,  0x79, 0xe8, 0x9a, 0xb,
            0x6c, 0xfd, 0x8f, 0x1e, 0x6b, 0xfa, 0x88, 0x19, 0x62, 0xf3, 0x81, 0x10, 0x65, 0xf4, 0x86, 0x17,
            0x48, 0xd9, 0xab, 0x3a, 0x4f, 0xde, 0xac, 0x3d, 0x46, 0xd7, 0xa5, 0x34, 0x41, 0xd0, 0xa2, 0x33,
            0x54, 0xc5, 0xb7, 0x26, 0x53, 0xc2, 0xb0, 0x21, 0x5a, 0xcb, 0xb9, 0x28, 0x5d, 0xcc, 0xbe, 0x2f,
            0xe0, 0x71, 0x3,  0x92, 0xe7, 0x76, 0x4,  0x95, 0xee, 0x7f, 0xd,  0x9c, 0xe9, 0x78, 0xa,  0x9b,
            0xfc, 0x6d, 0x1f, 0x8e, 0xfb, 0x6a, 0x18, 0x89, 0xf2, 0x63, 0x11, 0x80, 0xf5, 0x64, 0x16, 0x87,
            0xd8, 0x49, 0x3b, 0xaa, 0xdf, 0x4e, 0x3c, 0xad, 0xd6, 0x47, 0x35, 0xa4, 0xd1, 0x40, 0x32, 0xa3,
            0xc4, 0x55, 0x27, 0xb6, 0xc3, 0x52, 0x20, 0xb1, 0xca, 0x5b, 0x29, 0xb8, 0xcd, 0x5c, 0x2e, 0xbf,
            0x90, 0x1,  0x73, 0xe2, 0x97, 0x6,  0x74, 0xe5, 0x9e, 0xf,  0x7d, 0xec, 0x99, 0x8,  0x7a, 0xeb,
            0x8c, 0x1d, 0x6f, 0xfe, 0x8b, 0x1a, 0x68, 0xf9, 0x82, 0x13, 0x61, 0xf0, 0x85, 0x14, 0x66, 0xf7,
            0xa8, 0x39, 0x4b, 0xda, 0xaf, 0x3e, 0x4c, 0xdd, 0xa6, 0x37, 0x45, 0xd4, 0xa1, 0x30, 0x42, 0xd3,
            0xb4, 0x25, 0x57, 0xc6, 0xb3, 0x22, 0x50, 0xc1, 0xba, 0x2b, 0x59, 0xc8, 0xbd, 0x2c, 0x5e, 0xcf
        };
        public Form1()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            comboBox_mode_A.SelectedIndex = 0;
            comboBox_mode_B.SelectedIndex = 0;
            comboBox_slaves.SelectedIndex = 0;
        }

        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
                try
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();
                    buttonOpenPort.Text = "Close";
                    comboBox1.Enabled = false;
                    comboBox_mode_A.Enabled = true;
                    comboBox_mode_B.Enabled = true;
                    comboBox_slaves.Enabled = true;
                    hScrollBar_A.Enabled = true;
                    hScrollBar_B.Enabled = true;
                    progressBar_A_left.Enabled = true;
                    progressBar_A_right.Enabled = true;
                    progressBar_B_left.Enabled = true;
                    progressBar_B_right.Enabled = true;
                    button_start_A.Enabled = true;
                    button_start_A.Enabled = true;
                    button_start_B.Enabled = true;
                    button_stop_A.Enabled = true;
                    button_stop_B.Enabled = true;
                    progressBar_speed_A.Enabled = true;
                    progressBar_speed_B.Enabled = true;
                    hScrollBar_speed_A.Enabled = true;
                    hScrollBar_speed_B.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Port " + comboBox1.Text + " is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
            {
                serialPort1.Close();
                buttonOpenPort.Text = "Open";
                comboBox1.Enabled = true;
                comboBox_mode_A.Enabled = false;
                comboBox_mode_B.Enabled = false;
                comboBox_slaves.Enabled = false;
                hScrollBar_A.Enabled = false;
                hScrollBar_B.Enabled = false;
                progressBar_A_left.Enabled = false;
                progressBar_A_right.Enabled = false;
                progressBar_B_left.Enabled = false;
                progressBar_B_right.Enabled = false;
                button_start_A.Enabled = false;
                button_start_A.Enabled = false;
                button_start_B.Enabled = false;
                button_stop_A.Enabled = false;
                button_stop_B.Enabled = false;
                progressBar_speed_A.Enabled = false;
                progressBar_speed_B.Enabled = false;
                hScrollBar_speed_A.Enabled = false;
                hScrollBar_speed_B.Enabled = false;
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(SerialPort.GetPortNames().ToArray());
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        { 
            try
            {
              
                return;
            }

            catch
            {
                MessageBox.Show("Port " + comboBox1.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private byte crc8_rohs(byte[] b1)
        {
            byte crc = 0xFF;
            for(int k = 2; k < b1.Length - 1; ++k)
            {
                crc = CRC_8_ROHS_table[crc ^ b1[k]];
            }
            return crc;
        }

        private void sendPositionToSerialPort(int position, byte motor_address)
        {
            byte[] b1 = new byte[8];
            b1[0] = slave_address;
            b1[1] = commandWrite;
            b1[2] = 6;
            b1[3] = motor_address;
            b1[4] = set_position_address;
            b1[5] = (byte)(position >> 8);
            b1[6] = (byte)position;
            b1[7] = crc8_rohs(b1);
            for (int i = 0; i < 8; ++i)//for Proteus
            {
                serialPort1.Write(b1, i, 1);
                System.Threading.Thread.Sleep(delay);
            }
        }
        private void sendCommandToSerialPort(byte command, byte motor_address)
        {
            byte[] b1 = new byte[6];
            b1[0] = slave_address;
            b1[1] = commandWrite;
            b1[2] = 4;
            b1[3] = motor_address;
            b1[4] = command;
            b1[5] = crc8_rohs(b1);
            //serialPort1.Write(b1, 0, 5);
            for (int i = 0; i < 6; ++i)//for Proteus
            {
                serialPort1.Write(b1, i, 1);
                System.Threading.Thread.Sleep(delay);
            }
        }

        private void hScrollBar_A_ValueChanged(object sender, EventArgs e)
        {
            label_motor_A.Text = hScrollBar_A.Value.ToString();
            if(hScrollBar_A.Value >= 0)
            {
                progressBar_A_left.Value = 0;
                progressBar_A_right.Value = hScrollBar_A.Value;
            }
            else
            {
                progressBar_A_right.Value = 0;
                progressBar_A_left.Value = -hScrollBar_A.Value;
            }
            if (flag)
            {
                int position = hScrollBar_A.Value;
                elements[number_slaves].hScroll_A_value = hScrollBar_A.Value;
                sendPositionToSerialPort(position, motor_A_address);
            }
        }

        private void hScrollBar_B_ValueChanged(object sender, EventArgs e)
        {
            label_motor_B.Text = hScrollBar_B.Value.ToString();
            if (hScrollBar_B.Value >= 0)
            {
                progressBar_B_left.Value = 0;
                progressBar_B_right.Value = hScrollBar_B.Value;
            }
            else
            {
                progressBar_B_right.Value = 0;
                progressBar_B_left.Value = -hScrollBar_B.Value;
            }
            if (flag)
            {
                int position = hScrollBar_B.Value;
                elements[number_slaves].hScroll_B_value = hScrollBar_B.Value;
                sendPositionToSerialPort(position, motor_B_address);
            }
        }

        private void button_stop_A_Click(object sender, EventArgs e)
        {
            sendCommandToSerialPort(command_stop, motor_A_address);
        }

        private void button_start_A_Click(object sender, EventArgs e)
        {
            sendCommandToSerialPort(command_start, motor_A_address);
        }

        private void button_stop_B_Click(object sender, EventArgs e)
        {
            sendCommandToSerialPort(command_stop, motor_B_address);
        }

        private void button_start_B_Click(object sender, EventArgs e)
        {
            sendCommandToSerialPort(command_start, motor_B_address);
        }

        private void comboBox_mode_A_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen && flag)
            {
                int mode = 0;
                switch (comboBox_mode_A.SelectedIndex)
                {
                    case 0: mode = one_phase_mode; break;
                    case 1: mode = two_phase_mode; break;
                    case 2: mode = half_step_mode; break;
                }
                elements[number_slaves].comboBox_modes_A_value = comboBox_mode_A.SelectedIndex;
                sendCommandToSerialPort((byte)mode, motor_A_address);
            }
        }

        private void comboBox_mode_B_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen && flag)
            {
                int mode = 0;
                switch (comboBox_mode_B.SelectedIndex)
                {
                    case 0: mode = one_phase_mode; break;
                    case 1: mode = two_phase_mode; break;
                    case 2: mode = half_step_mode; break;
                }
                elements[number_slaves].comboBox_modes_B_value = comboBox_mode_B.SelectedIndex;
                sendCommandToSerialPort((byte)mode, motor_B_address);
            }
        }

        private void setSlaves()
        {
            hScrollBar_A.Value = elements[number_slaves].hScroll_A_value;
            hScrollBar_B.Value = elements[number_slaves].hScroll_B_value;
            comboBox_mode_A.SelectedIndex = elements[number_slaves].comboBox_modes_A_value;
            comboBox_mode_B.SelectedIndex = elements[number_slaves].comboBox_modes_B_value;
            hScrollBar_speed_A.Value = elements[number_slaves].hScroll_speed_A_value;
            hScrollBar_speed_B.Value = elements[number_slaves].hScroll_speed_B_value;

        }

        private void comboBox_slaves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                flag = false;
                switch (comboBox_slaves.SelectedIndex)
                {
                    case 0:
                        number_slaves = 0;
                        slave_address = slave_1_address;
                        break;
                    case 1:
                        number_slaves = 1;
                        slave_address = slave_2_address;
                        break;
                    case 2:
                        number_slaves = 2;
                        slave_address = slave_3_address;
                        break;
                }
                setSlaves();
                flag = true;
            }
        }

        private void sendSpeedPrescalarToSerialPort(byte prescalar, byte motor_address)
        {
            byte[] b1 = new byte[7];
            b1[0] = slave_address;
            b1[1] = commandWrite;
            b1[2] = 5;
            b1[3] = motor_address;
            b1[4] = set_speed_prescalar_address;
            b1[5] = prescalar;
            b1[6] = crc8_rohs(b1);
            //serialPort1.Write(b1, 0, 6);//for real 
            for (int i = 0; i < 7; ++i)//for Proteus
            {
                serialPort1.Write(b1, i, 1);
                System.Threading.Thread.Sleep(delay);
            }
        }

        private void hScrollBar_speed_A_ValueChanged(object sender, EventArgs e)
        {
            progressBar_speed_A.Value = hScrollBar_speed_A.Value;
            elements[number_slaves].hScroll_speed_A_value = hScrollBar_speed_A.Value;
            int prescalar = hScrollBar_speed_A.Value + 1;
            label_speed_A.Text = prescalar.ToString();
            if(flag)
                sendSpeedPrescalarToSerialPort((byte)prescalar, motor_A_address);
        }

        private void hScrollBar_speed_B_ValueChanged(object sender, EventArgs e)
        {
            progressBar_speed_B.Value = hScrollBar_speed_B.Value;
            elements[number_slaves].hScroll_speed_B_value = hScrollBar_speed_B.Value;
            int prescalar = hScrollBar_speed_B.Value + 1;
            label_speed_B.Text = prescalar.ToString();
            if(flag)
                sendSpeedPrescalarToSerialPort((byte)prescalar, motor_B_address);
        }
    }
}
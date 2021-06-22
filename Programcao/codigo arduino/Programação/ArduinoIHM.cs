using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO; 

namespace Arduino
{
    public partial class ArduinoIHM : Form
    {
        string estado="";
        public ArduinoIHM()
        {
            InitializeComponent();
        }

        public static void setLOG(Button umbutao)
        {
            DateTime hoje = DateTime.Now;
            Arduino umArduino = new Arduino();
            umArduino.setCodigo((umbutao.Tag).ToString());
            umArduino.setDataHora((hoje).ToString());
            umArduino.setDispositivo("led "+ umbutao.Tag);
            umArduino.setAcao(umbutao.Text);
            ArduinoDAL.insiraUmArduino(umArduino);


        }
        private void tratarBotoes(object sender, EventArgs e)
        {
            Button generico = (Button)sender;
            setLOG(generico);
            estado = (generico.Tag).ToString();
            serialPort1.WriteLine(estado);
            if (generico.Text == "Ligar")
            {
                generico.Text= "Desligar";
                ArduinoBLL.ligaDispositivo(generico.Tag.ToString());
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            }
            else
            {
                generico.Text = "Ligar";
                ArduinoBLL.desligaDispositivo(generico.Tag.ToString());
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            ArduinoBLL.setDisplay(0,serialPort1);
            estado = "d";
            serialPort1.WriteLine(estado);
            textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            button1.Text = "Desliga";
            setLOG(button1);
            button1.Text = "Ligar";
            button2.Text = "Desliga";
            setLOG(button2);
            button2.Text = "Ligar";
            button3.Text = "Desliga";
            setLOG(button3);
            button3.Text = "Ligar";
            button4.Text = "Desliga";
            setLOG(button4);
            button4.Text = "Ligar";
            button5.Text = "Desliga";
            setLOG(button5);
            button5.Text = "Ligar";
            button6.Text = "Desliga";
            setLOG(button6);
            button6.Text = "Ligar";
            button7.Text = "Desliga";
            setLOG(button7);
            button7.Text = "Ligar";
            button8.Text = "Desliga";
            setLOG(button8);
            button8.Text = "Ligar";
            

        }

        private async void button11_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 5; i++)
            {
                ArduinoBLL.setDisplay(~0, serialPort1);
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
                setLOG(button1);
                button1.Text = "Desliga";
                setLOG(button3);
                button2.Text = "Desliga";
                setLOG(button3);
                button3.Text = "Desliga";
                setLOG(button4);
                button4.Text = "Desliga";
                setLOG(button5);
                button5.Text = "Desliga";
                setLOG(button6);
                button6.Text = "Desliga";
                setLOG(button7);
                button7.Text = "Desliga";
                setLOG(button8);
                button8.Text = "Desliga";
                estado = "l";
                serialPort1.WriteLine(estado);
                await Task.Delay(2000);

                ArduinoBLL.setDisplay(0, serialPort1);
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
                setLOG(button1);
                button1.Text = "Ligar";
                setLOG(button3);
                button2.Text = "Ligar";
                setLOG(button3);
                button3.Text = "Ligar";
                setLOG(button4);
                button4.Text = "Ligar";
                setLOG(button5);
                button5.Text = "Ligar";
                setLOG(button6);
                button6.Text = "Ligar";
                setLOG(button7);
                button7.Text = "Ligar";
                setLOG(button8);
                button8.Text = "Ligar";
                estado = "d";
                serialPort1.WriteLine(estado);
                await Task.Delay(2000);
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            Button[] button = { button1, button2, button3, button4, button5, button6, button7, button8 };

            for (int i = 1; i < 9; i++)
            {
                setLOG(button[i - 1]);
                estado=(i).ToString();
                serialPort1.WriteLine(estado);
                ArduinoBLL.ligaDispositivo(i.ToString());
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
                button[i - 1].Text = "Desligar";
                await Task.Delay(2000);
            }
        }

        private void ArduinoIHM_Load(object sender, EventArgs e)
        {
            ArduinoBLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            try

            {
                serialPort1.Open();
                MessageBox.Show("Porta serial COM1 conectada com sucesso.");
                //serialPort1.WriteLine("1");
               // serialPort1.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show("Erro ao se conectar a porta COM1 (" + erro.Message + ")");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ArduinoBLL.setDisplay(~0, serialPort1);
            estado = "l";
            serialPort1.WriteLine(estado);
            
            textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            button1.Text = "Ligar";
            setLOG(button1);
            button1.Text = "Desligar";
            button2.Text = "Ligar";
            setLOG(button2);
            button2.Text = "Desligar";
            button3.Text = "Ligar";
            setLOG(button3);
            button3.Text = "Desligar";
            button4.Text = "Ligar";
            setLOG(button4);
            button4.Text = "Desligar";
            button5.Text = "Ligar";
            setLOG(button5);
            button5.Text = "Desligar";
            button6.Text = "Ligar";
            setLOG(button6);
            button6.Text = "Desligar";
            button7.Text = "Ligar";
            setLOG(button7);
            button7.Text = "Desligar";
            button8.Text = "Ligar";
            setLOG(button8);
            button8.Text = "Desligar";
        }

        private void ArduinoIHM_FormClosing(object sender, FormClosingEventArgs e)
        {
            ArduinoBLL.desconecta();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampoMinado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Parent = pictureBox1;
        }

        int[] vetorNum = new int[49];
        int pontuaçãoTotal = 0;
        int numAleatorio = 0;
        Random rdne = new Random();

        void GerarVetor()
        {
            int conte = 0;
            for (int i = 0; i < vetorNum.Length; i++)
                vetorNum[i] = 0;

            for(int i = 0; i<49; i++)
            {
                do
                {
                    numAleatorio = rdne.Next(5, 10);
                    conte = 0;
                    foreach (int numero in vetorNum)
                    {
                        if (numAleatorio == numero)
                            conte++;
                    }
                } while (conte == 49);
                vetorNum[i] = numAleatorio;
            }
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        PictureBox[] btn = new PictureBox[49];

        private void button1_Click(object sender, EventArgs e)
        {
            GerarVetor();

            int x = 0, y = 0;

            for(int i = 0; i > 49; i++)
            {
                if (x == 400)
                {
                    x = 0;
                    y += 100;
                }
                btn[i] = new PictureBox();
                btn[i].Parent = pictureBox1;
                btn[i].Left += 200 + x;
                btn[i].Top += 50 + y;
                btn[i].Width = 80;
                btn[i].Height = 80;
                btn[i].Load("download.jpg");
                btn[i].Click += new EventHandler(btnClick);
                x += 100;
            }
          
        }

        void sorteador ()
        {        
            Random numero = new Random();
            int sorte = numero.Next(5, 10);
            pontuaçãoTotal += sorte;
        }

        void btnClick(object sender, EventArgs e)
        {
            sorteador();
            if(pontuaçãoTotal > 25)
            {
                MessageBox.Show("Você expludiu! Tente novamente.");
                Application.Restart();
            }

            label1.Text = pontuaçãoTotal.ToString();
        }
    }
}

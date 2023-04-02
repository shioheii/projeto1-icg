/* Colegio Técnico Antônio Teixeira Fernandes (Univap)
 * Curso Técnico em Informática - Data de Entrega: 22/03/2023
 * Autores do Projeto: Arthur de Nazareth Falcão Braga
 *                     Bruno Shiohei Kinoshita do Nascimento 
 * Turma: 3H
 * Atividade Proposta em aula
 * Observação: <colocar se houver>
 * 
 * 
 * ******************************************************************/

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int desenha = 0;
        Color color(int r, int g, int b)
        {
            Color color = new Color();
            color = Color.FromArgb(r, g, b);
            return color;
        }

        void ponto(int x, int y, Color cor, PaintEventArgs e)
        {
            Pen caneta = new Pen(cor, 0);
            e.Graphics.DrawLine(caneta, x, y, x + 1, y);
        }

        void linha(int xi, int yi, int xf, int yf, Pen caneta, PaintEventArgs e)
        {
            e.Graphics.DrawLine(caneta, xi, yi, xf, yf);
        }

        void desenharCoordenadas(PaintEventArgs e)
        {
            Color corEixosCartesianos = color(0, 0, 0);
            Pen canetaEixosCartesianos = new Pen(corEixosCartesianos, 0);
            linha(0, 540, 1920, 540, canetaEixosCartesianos, e);
            linha(960, 0, 960, 1080, canetaEixosCartesianos, e);
        }

        void desenharLinha(PaintEventArgs e)
        {
            int xi = int.Parse(textBox1.Text);
            int yi = int.Parse(textBox2.Text);
            int m = int.Parse(textBox3.Text);
            int xf = int.Parse(textBox4.Text);
            int b = int.Parse(textBox5.Text);

            int yf = 0;
            label1.Text = "y = " + m + "x + " + b;

            yi += b;
            yf = m * xf + b;

            Color corLinha = color(150, 0, 0);
            Pen canetaLinha = new Pen(corLinha, 0);
            linha(xi + 960, 540 - yi, xf + 960, 540 - yf, canetaLinha, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            desenha = 1;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (desenha == 1)
            {
                desenharCoordenadas(e);
                desenharLinha(e);
            }
        }
    }
}

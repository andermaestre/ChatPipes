using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;
using Biblio;

namespace ChatPipes
{
    public partial class Form1 : Form
    {
        Process Auricular = new Process();
        ProcessStartInfo psi=new ProcessStartInfo();
        StreamReader sr;
        public Form1()
        {
            InitializeComponent();

            psi.FileName = "..\\..\\..\\Auricular\\bin\\Debug\\Auricular.exe";
            psi.UseShellExecute = true;
            Auricular.StartInfo = psi;
            Auricular.Start();

            NamedPipeClientStream clientStream = new NamedPipeClientStream(".", "pipe", PipeDirection.In);
            sr = new StreamReader(clientStream);

            clientStream.Connect();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {

        }
        
    }
}

using SimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCP2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server; // Declarando classe SimpleTCP para fazer as conecções dos sockets.
        string lista; // Declarando variável para receber os valores da lista.
        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            txtInfo.Text += $"(Slave) Servidor iniciado, Aguardando a conexão...{Environment.NewLine}";
            btnStart.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            server = new SimpleTcpServer(txtIP.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lista = Encoding.UTF8.GetString(e.Data); // variável 'lista' recebendo os dados(lista de nomes) da outra aplicação.
                txtInfo.Text += $"(Slave) Lista de nomes do IP: {e.IpPort}  recebida! {Environment.NewLine}";
                txtInfo.Text += $"(Slave) Selecione um dos IPs conectados ao lado para realizar a comunicação... {Environment.NewLine}";
                btnSave.Enabled = true;
            });
        }

        private void Events_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"(Slave) O IP: {e.IpPort}  foi desconectado. {Environment.NewLine}";
                lstClientIP.Items.Remove(e.IpPort);
            });
        }

        private void Events_ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"(Slave) o IP: {e.IpPort}  foi conectado, aguardando envio... {Environment.NewLine}";
                lstClientIP.Items.Add(e.IpPort);

            });
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (lstClientIP.SelectedItem != null) // Lógica para selecionar algum ip da listbox.
                {
                    StreamWriter arquivoTxt = new StreamWriter("c:\\temp\\nomes_de_categoria1.txt"); // Cria o arquivo .txt na pasta 'temp' dentro do disco local 'C'.
                    arquivoTxt.WriteLine("Nomes de categoria 1:\n" + lista);
                    txtInfo.Text += $"(Slave) Arquivo foi salvo em: ' C:\\temp\\nomes_de_categoria1.txt ' {Environment.NewLine}";
                    server.Send(lstClientIP.SelectedItem.ToString(), $"(Master) O arquivo foi criado com sucesso pelo servidor! {Environment.NewLine}"); // Comunicar-se com cliete.
                    arquivoTxt.Close();
                }
            }
        }
    }
}

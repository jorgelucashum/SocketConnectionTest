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

namespace TCP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client; // Declarando classe SimpleTCP para fazer as conecções dos sockets.

        private void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            if (client.IsConnected)
            {
                string[] linhas1 = File.ReadAllText("Prova Estagio DEV - Anexo 1.txt").Split('\n', ';'); // Ler e transformar o txt em um array do tipo string dividido pelas linhas e ';'.
                List<string> linhas = new List<string>();

                for (int i = 0; i < linhas1.Length; i++) // Estrutura de repetição feita para percorrer todo o array e adicionar os nomes da categoria '1' em uma lista separada.
                {
                    if (linhas1[i] == "1" || linhas1[i] == "1\r") // Lógica para selecionar os nomes da categoria '1' dentro do array criado.
                    {
                        linhas.Add(linhas1[i - 1]); // Adicionar os nomes da categoria '1' para uma lista.
                    }
                }

                foreach (string linha in linhas) 
                {
                    if (!string.IsNullOrEmpty(linha))
                    {
                        client.Send(linha + "\n"); // Enviar os nomes do arquivo .txt da lista para a outra aplicação.                       
                    }
                }
                txtInfo.Text += $"(Master) Listas de nomes lida e enviada! {Environment.NewLine}";
            }
        }

        private void btncConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                btnSend.Enabled = true;
                btncConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error); // Exceção para mensagem de erro.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient(txtIP.Text);
            client.Events.Connected += Events_Connected;
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Disconnected += Events_Disconnected;
            btnSend.Enabled = false;

        }

        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"(Master) Servidor Desconectado. {Environment.NewLine}";
            });
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{Encoding.UTF8.GetString(e.Data)}";
            });
        }

        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"(Master) Conectado ao servidor. {Environment.NewLine}";
            });
        }
    }
}

using System;
using System.Collections.Generic; 
using System.IO;
using System.Linq; // Para ordenar as lista
using System.Net; 
using System.Net.Mail; //para enviar e-mails
using System.Runtime.InteropServices; // Para DLLs do Windows
using System.Text;
using System.Windows.Forms;

namespace MonitorProdutividade
{
    public partial class Form1 : Form
    {
        // DDLs do Windows
        //Importa o método GetForegroundWindow da user32.dll do Windows e retorna um ponteiro para a janela que o usuário está usando
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]

        //Esse método traduz o ponteiro da janela para o texto do título dela
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        // Armazena o nome da janela e o tempo em segundos 
        private Dictionary<string, int> registroTempo = new Dictionary<string, int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; //o timer dispara eventos a cada 1 segundo
            timer1.Enabled = true;
            timer1.Tick -= Timer1_Tick; //Liga o evento de "tique" do relógio ao método que processa a lógica.
            timer1.Tick += Timer1_Tick;
        }

        // lógica do timer que é executada a cada segundo
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string nomeJanela = pegarNomeJanela(); 
                //atualiza a interface gráfica para responder o usuário em tempo real 
                if (lblJanelaAtiva != null)
                    lblJanelaAtiva.Text = "Janela Atual: " + nomeJanela;

                if (!string.IsNullOrEmpty(nomeJanela))
                {
                    // Se a janela já existe no registro, incrementa o tempo.
                    if (registroTempo.ContainsKey(nomeJanela))
                        registroTempo[nomeJanela]++;
                    else
                        //se for uma nova janela, cria uma nova entrada no dicionario
                        registroTempo.Add(nomeJanela, 1);
                }
                //atualiza a list box 
                atualizalista(); 
            }
            catch { }
        }

        //métodos auxiliares 
        private string pegarNomeJanela()
        {
            const int limiteCaracteres = 256;
            StringBuilder buffer = new StringBuilder(limiteCaracteres);
            IntPtr handle = GetForegroundWindow();
            // Copia o texto da janela para o buffer. Retorna > 0 se tiver sucesso.
            if (GetWindowText(handle, buffer, limiteCaracteres) > 0)
                return buffer.ToString();
            return "Indefinido/Área de Trabalho"; //para janelas sem título 
        }

        private void atualizalista()
        {
            // Verifica se a lista "registros" existe no Design
            if (registros == null) return;
            //Armazena a posição atual da rolagem
            int topoAtual = registros.TopIndex;
            registros.Items.Clear();
            registros.Items.Add("--- RELATÓRIO DE USO ---");
            // Utiliza LINQ para ordenar os registros do maior tempo para o menor
            var relatorioOrdenado = registroTempo.OrderByDescending(x => x.Value);

            foreach (var item in relatorioOrdenado)
            { 
                TimeSpan t = TimeSpan.FromSeconds(item.Value); //formata o tempo 
                registros.Items.Add($"[{t:hh\\:mm\\:ss}] - {item.Key}");
            }

            if (registros.Items.Count > 0)
                registros.TopIndex = Math.Min(topoAtual, registros.Items.Count - 1);
        }

        // envio do e~mail
        private void enviaRelatorio()
        {
            try
            {   
                // ========================================================
                string meuEmail = "SEUEMAIL@gmail.com";
                string senhaApp = "senha";
                // ========================================================

                //constrói o corpo do e-mail iterando sobre o dicionário de dados 
                StringBuilder corpoEmail = new StringBuilder();
                corpoEmail.AppendLine("Relatório de Produtividade:");
                corpoEmail.AppendLine("--------------------------------");

                foreach (var item in registroTempo.OrderByDescending(x => x.Value))
                {
                    TimeSpan t = TimeSpan.FromSeconds(item.Value);
                    corpoEmail.AppendLine($"{item.Key}: {t:hh\\:mm\\:ss}");
                }

                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential(meuEmail, senhaApp);

                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress(meuEmail);
                mensagem.To.Add(meuEmail); // O destinatário é o próprio usuário (auto-monitoramento)
                mensagem.Subject = "Relatório Projeto 1";
                mensagem.Body = corpoEmail.ToString();
                //envio efetivo da mensagem 
                clienteSmtp.Send(mensagem);

                MessageBox.Show("E-mail enviado com sucesso!", "Sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao enviar: " + ex.Message);
            }
        }
        //Aciona a função de envio.
        private void button1_Click(object sender, EventArgs e)
        {
            enviaRelatorio();
        }
    }
}
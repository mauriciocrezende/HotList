using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;

namespace Atualizacao_HotList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Carregar ListBox na Inicialização
            Tools.CarregarListBox(lstServidores, lstAssociados, tbemail);
            
        }

        private void LimparListBox()
        {
            int total = lstServidores.Items.Count;
            for (int x = 0; x < total; x++)
            {
                lstServidores.Items.Remove(lstServidores.SelectedItems[0]);
            }
        }

        

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificaEmail(tbemail.Text) == false)
                {
                    MessageBox.Show("Favor preencher o campo email.", "HotList", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                AtualizaListBox();

                if (Tools.IsEmail(tbemail.Text) == false)
                {
                    MessageBox.Show("Favor preencher um email válido.", "HotList", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                getFilesToFTP();
                MessageBox.Show("Atualização concluida com sucesso.", "HotList", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Tools.gerarLog("Atualização concluida com sucesso.");
            }
            catch (Exception ee)
            {
                Tools.gerarLog(ee.Message + " Falha ao atualizar repositório(s).");

                string[] emails = LerEmails();

                foreach (string email in emails)
                {
                    Tools.SendEmail(ee.Message + "\nFalha ao atualizar repositório(s) no(s) servidore(s). \nVerifique a conexão e tente novamente. Caso erro persista, procure o desenvolvedor.", email);
                }
            }
        }

        //Receber do ftp da riocard os arquivos L211
        //Adequação por Mauricio Rezende
        private void getFilesToFTP()
        {
            try
            {
                SessionOptions sessionOptions = new SessionOptions();

                sessionOptions.Protocol = Protocol.Sftp;
                sessionOptions.HostName = ConfigurationManager.AppSettings["Riocard_Sftp_Host"];
                sessionOptions.UserName = ConfigurationManager.AppSettings["Riocard_Sftp_User"];
                sessionOptions.Password = ConfigurationManager.AppSettings["Riocard_Sftp_Pass"];
                sessionOptions.SshHostKeyFingerprint = ConfigurationManager.AppSettings["Riocard_Sftp_SshHostKeyFingerprint"];

                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Download files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;

                    string diaAnterior = DateTime.Now.AddDays(-1).ToString("dd");
                    string datadodia = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
                    TransferOperationResult transferResult;

                    //Cria diretorio de saida caso não exista
                    string dirSaida = ConfigurationManager.AppSettings["Dir_Saida"];
                    Directory.CreateDirectory(dirSaida);

                    string AnoNumeral = DateTime.Now.Year.ToString();
                    string mesNumeral = DateTime.Now.ToString("MM");
                    string mesExtenso = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(Convert.ToInt32(mesNumeral)).ToUpper();
                    if (mesExtenso.Contains("Ç")) { mesExtenso = mesExtenso.Replace("Ç", "C"); }
                    string mesAtual = mesNumeral + "_" + mesExtenso;

                    //Endereço no ftp
                    ///saida/MERCURY_SUPERVIA/2019/07_JULHO
                    transferResult =
                        session.GetFiles("/saida/MERCURY_SUPERVIA/" + AnoNumeral + "/" + mesAtual + "/" + diaAnterior, dirSaida + datadodia , false, transferOptions);
                    
                    // Throw on any error
                    transferResult.Check();

                    DirectoryInfo dir = new DirectoryInfo(dirSaida + datadodia);
                    FileInfo[] file = dir.GetFiles("*", SearchOption.AllDirectories);

                    Tools.gerarLog("Arquivos Copiados: ");

                    foreach (FileInfo f in file)
                    {
                        Tools.gerarLog("Endereço ftp: /saida/MERCURY_SUPERVIA/" + AnoNumeral + "/" + mesAtual + "/" + diaAnterior + " -> Nome do Arquivo: " + f.Name);
                    }

                    
                    // Mover para a Servidor
                    ProcessFiles(dirSaida + datadodia);
                    //ProcessFileL211(dirSaida + datadodia);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message + ": Problema ao transferir os arquivo do FTP da riocard.");
                Tools.gerarLog(e.Message + ": Problema ao transferir os arquivo do FTP da riocard.");
                throw new Exception();
            }
        }

        private void ProcessFiles(string dirSaida)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirSaida);

                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    for (int i = 0; i < lstAssociados.Items.Count; i++)
                    {
                        string DirDestionation = Path.Combine(lstAssociados.Items[i].ToString(), d.Name.ToString());
                        Tools.CopyAll(new DirectoryInfo(d.FullName), new DirectoryInfo(DirDestionation));
                    }
                    
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message + " Falha ao copiar os arquivos para o Destino");
                Tools.gerarLog(e.Message + " Falha ao copiar os arquivos para o Destino");
                throw new Exception();
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja mesmo sair?", "HotList", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (DialogResult.Yes == resultado)
            {
                AtualizaListBox();
                Application.ExitThread();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btIncluirTodos_Click(object sender, EventArgs e)
        {
            foreach (string item in lstServidores.SelectedItems)
            {
                lstAssociados.Items.Add(item);
            }
            
            int total = lstServidores.SelectedItems.Count;
            for (int x = 0; x < total; x++)
            {
                lstServidores.Items.Remove(lstServidores.SelectedItems[0]);
            }

            AtualizaListBox();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (string item in lstAssociados.SelectedItems)
            {
                lstServidores.Items.Add(item);
            }

            int total = lstAssociados.SelectedItems.Count;
            for (int x = 0; x < total; x++)
            {
                lstAssociados.Items.Remove(lstAssociados.SelectedItems[0]);
            }

            AtualizaListBox();

        }

        private void btIncluirServidor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbIncluir.Text))
            {
                MessageBox.Show("Digite um endereço válido.", "HotList", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbIncluir.Focus();
            }
            else
            {
                lstServidores.Items.Add(tbIncluir.Text);
                AtualizaListBox();
                tbIncluir.Text = "";
                tbIncluir.Focus();
            }
        }

        private void AtualizaListBox()
        {
            string directory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Conf");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string Servidores = System.IO.Path.Combine(directory, "Servidores.txt");
            string Associados = System.IO.Path.Combine(directory, "Associados.txt");
            string Emails = System.IO.Path.Combine(directory, "Emails.txt");

            //Parametro "false" para sobescrever tudo que contém no arquivo
            StreamWriter writerServidores = new StreamWriter(Servidores, false);
            StreamWriter writerAssociados = new StreamWriter(Associados, false);
            StreamWriter writerEmails = new StreamWriter(Emails, false);

            //ListBox lstServidores
            using (writerServidores)
            {
                // Escreve no arquivo o que está na ListBox
                for (int i = 0; i < lstServidores.Items.Count; i++)
                {
                    writerServidores.WriteLine(lstServidores.Items[i].ToString());
                }
            }

            //ListBox lstAssociados
            using (writerAssociados)
            {
                // Escreve no arquivo o que está na ListBox
                for (int i = 0; i < lstAssociados.Items.Count; i++)
                {
                    writerAssociados.WriteLine(lstAssociados.Items[i].ToString());
                }
            }

            using (writerEmails)
            {
                // Escreve no arquivo o que está no campo de email
                var array = tbemail.Text.Replace(" ", "").Split(';');
                
                for (int i = 0; i < array.Count(); i++)
                {
                    array[i].Trim();
                    writerEmails.WriteLine(array[i].ToString());
                }
            }
        }

        private void tmAutomatico_Tick(object sender, EventArgs e)
        {

            if (ckAutomatico.Checked)
            {
                string HoraAtual = DateTime.Now.ToString("HH:mm");
                string HoraProgramada = tbHora.Text;

                if (HoraAtual == HoraProgramada)
                {
                    try
                    {
                        getFilesToFTP();
                        MessageBox.Show("Arquivos processados com sucesso.", "HotList", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ee)
                    {
                        //MessageBox.Show(ee.Message + " Falha ao copiar os arquivos. - TimerAutomatico ");
                        Tools.gerarLog(ee.Message + " Falha ao copiar os arquivos. - TimerAutomatico ");
                        string[] emails = LerEmails();

                        foreach (string email in emails)
                        {
                            Tools.SendEmail(ee.Message + "\nFalha ao atualizar repositório(s) no(s) servidore(s). \nVerifique a conexão e tente novamente. Caso erro persista, procure o desenvolvedor.", email);
                        }
                    }
                }
            }
        }

        private void DeleteList(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) // botao delete
            {
                var resultado = MessageBox.Show("Deseja remover?", "HotList", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == resultado)
                {
                    int Counter = lstServidores.SelectedItems.Count;
                    for (int i = 0; i < Counter; i++)
                    {
                        lstServidores.Items.RemoveAt(i);
                    }
                }

                AtualizaListBox();
            }
        }

        private void ckAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            if (ckAutomatico.Checked)
            {
                if (VerificaEmail(tbemail.Text) == false)
                {
                    MessageBox.Show("Favor preencher o campo email.", "HotList", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ckAutomatico.Checked = false;
                    tbemail.Focus();
                    return;
                }
                if (Tools.IsEmail(tbemail.Text) == false)
                {
                    MessageBox.Show("Favor preencher um email válido.", "HotList", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ckAutomatico.Checked = false;
                    return;
                }
                tbemail.Enabled = false;
                tbHora.Enabled = false;
                AtualizaListBox();
            }
            else
            {
                tbHora.Enabled = true;
                tbemail.Enabled = true;
                AtualizaListBox();
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {

            if (lstAssociados.SelectedItems.Count > 0)
            {
                MessageBox.Show("Desmarque o(s) iten(s) selecionado(s) na caixa dos servidores que serão atualizados", "HotList", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var resultado = MessageBox.Show("Deseja remover?", "HotList", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult.Yes == resultado)
                {
                    int Counter = lstServidores.SelectedItems.Count;
                    for (int i = 0; i < Counter; i++)
                    {
                        lstServidores.Items.RemoveAt(lstServidores.SelectedIndex);
                    }
                }
            }
            
            AtualizaListBox();
        }

        public string[] LerEmails()
        {
            string directory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Conf");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string Emails = System.IO.Path.Combine(directory, "Emails.txt");

            //Parametro "false" para sobescrever tudo que contém no arquivo
            StreamWriter writerEmails = new StreamWriter(Emails, false);

            // Escreve no arquivo o que está no campo de email
            var array = tbemail.Text.Replace(" ", "").Split(';');
            
            return array;
        }

        public bool VerificaEmail(string CampoEmail)
        {
            bool strRetorno = false;

            if (CampoEmail != string.Empty)
            {
                strRetorno = true;
            }

            return strRetorno;
        }

        private void lstServidores_MouseClick(object sender, MouseEventArgs e)
        {

        }


        //Parametro para marcar/desmarcar item da lista
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        //public const uint KEYEVENTF_KEYUP = 0x02;
        public const uint VK_CONTROL = 0x11;

        private void lstServidores_MouseDown(object sender, MouseEventArgs e)
        {
            //keybd_event(Convert.ToByte(VK_CONTROL), 0, 0, 0);
        }

        private void lstAssociados_MouseDown(object sender, MouseEventArgs e)
        {
            //keybd_event(Convert.ToByte(VK_CONTROL), 0, 0, 0);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var resultado = MessageBox.Show("Deseja mesmo sair?", "HotList", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.No == resultado)
            {
                e.Cancel = true;
            }
            AtualizaListBox();
        }
        
    }
}

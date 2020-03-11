using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atualizacao_HotList
{
    public class Tools
    {
        public static void gerarLog(string msg)
        {
            string directory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string nomeArquivo = System.IO.Path.Combine(directory, "HostList_log" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            StreamWriter w = File.AppendText(nomeArquivo);
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine("  :{0}", msg);
            w.WriteLine("-------------------------------");
            w.WriteLine();
            w.Close();
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            if (source.FullName.ToLower() == target.FullName.ToLower())
            {
                return;
            }

            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            if (Directory.Exists(source.FullName) == false)
            {
                Directory.CreateDirectory(source.FullName);
            }

            // Copy each file into it's new directory.]
            try
            {
                foreach (FileInfo fi in source.EnumerateFiles())
                {
                    try
                    {
                        fi.CopyTo(System.IO.Path.Combine(target.ToString(), fi.Name));
                    }
                    catch
                    {
                        if (File.Exists(System.IO.Path.Combine(target.ToString(), fi.Name)))
                        {
                            File.Delete(System.IO.Path.Combine(target.ToString(), fi.Name));
                            fi.CopyTo(System.IO.Path.Combine(target.ToString(), fi.Name));
                        }
                    }
                    Console.WriteLine(@"Copied {0}\{1}", target.FullName, fi.Name);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Illegal characters in path."))
                {
                    foreach (FileInfo fi in source.EnumerateFiles("*.zip"))
                    {
                        try
                        {
                            fi.CopyTo(System.IO.Path.Combine(target.ToString(), fi.Name), true);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("aqui " + e.Message);
                        }
                        Console.WriteLine(@"Copied {0}\{1}", target.FullName, fi.Name);
                    }
                }
            }

            try
            {
                // Copy each subdirectory using recursion.
                foreach (DirectoryInfo diSourceSubDir in source.EnumerateDirectories())
                {
                    if (diSourceSubDir.Name.Contains("System Volume")) continue;
                    DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }
            catch (Exception e)
            {
                if (e.Message.Equals("Illegal characters in path."))
                {
                    return;
                }
            }
        }

        public static void CarregarListBox(ListBox lstServidores, ListBox lstAssociados, TextBox lstEmails)
        {
            try
            {
                string directory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Conf");

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string arquivo = Path.Combine(directory, "Servidores.txt");

                string[] lines = System.IO.File.ReadAllLines(arquivo);

                foreach (string line in lines)
                {
                    lstServidores.Items.Add(line);
                }


                arquivo = Path.Combine(directory, "Associados.txt");

                lines = System.IO.File.ReadAllLines(arquivo);

                foreach (string line in lines)
                {
                    lstAssociados.Items.Add(line);
                }

                arquivo = Path.Combine(directory, "Emails.txt");

                lines = System.IO.File.ReadAllLines(arquivo);

                foreach (string line in lines)
                {
                    if (line != lines.Last())
                    {
                        lstEmails.Text += line + ";";
                    }
                    else
                    {
                        lstEmails.Text += line;
                    }
                }

            }
            catch (Exception e)
            {
                gerarLog(e.Message + " Falha ao carregar o arquivo de configuração de abertura da tela. - CarregarListBox");
                throw new Exception();
            }
        }

        public static void SendEmail(string msgBody, string SendEmail)
        {

            //Instancia o Objeto Email como MailMessage 
            MailMessage email = new MailMessage();

            email.To.Add(SendEmail);

            email.Subject = "Aplicação HotList";

            email.Body = msgBody;

            email.IsBodyHtml = true;

            email.Priority = MailPriority.Normal;

            email.From = new MailAddress("superviagprs@gmail.com");

            SmtpClient cliente = new SmtpClient();

            cliente.UseDefaultCredentials = false;

            cliente.Credentials = new NetworkCredential("superviagprs@gmail.com", "Supervia@2019");

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            try
            {
                cliente.Send(email);
            }
            catch (System.Exception erro)
            {
                gerarLog(erro.Message + " Falha ao enviar o email, favor verificar a conexão!");
            }
        }

        public static bool IsEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

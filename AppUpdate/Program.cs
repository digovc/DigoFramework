using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AppUpdate
{
    public class Program
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("Kernel32")]
        private static extern IntPtr GetConsoleWindow();

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public static void Main(string[] args)
        {
            #region VARIÁVEIS

            Process objProcess;

            String dirCompleto;

            #endregion
            try
            {
                #region AÇÕES

                IntPtr hwnd;
                hwnd = GetConsoleWindow();
                ShowWindow(hwnd, SW_HIDE);

                dirCompleto = Application.ExecutablePath;

                if (!dirCompleto.Contains("AppUpdate2"))
                {

                    File.Delete(Path.GetDirectoryName(dirCompleto) + "\\AppUpdate2.exe");
                    File.Copy(dirCompleto, Path.GetDirectoryName(dirCompleto) + "\\AppUpdate2.exe");

                    objProcess = new Process();
                    objProcess.StartInfo.FileName = "AppUpdate2.exe";
                    objProcess.StartInfo.Arguments = String.Join(" ", args);
                    objProcess.StartInfo.CreateNoWindow = true;
                    objProcess.Start();

                    return;

                }

                //Thread.Sleep(3000);

                foreach (string dir in args)
                {
                    if (Directory.Exists(dir))
                    {
                        processarDiretorio(dir);
                    }
                    else
                    {
                        Console.WriteLine("{0} não é uma pasta válida.", dir);
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public static void processarDiretorio(string dir)
        {
            #region VARIÁVEIS

            string[] lstDirArquivo;

            #endregion
            try
            {
                #region AÇÕES


                lstDirArquivo = Directory.GetFiles(dir);

                foreach (string dirArquivo in lstDirArquivo)
                {
                    processarArquivo(dirArquivo);
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public static void processarArquivo(string dirArquivo)
        {
            #region VARIÁVEIS

            String dirArquivoOriginal;
            String dirArquivoBackup;
            String strExtencao;

            #endregion
            try
            {
                #region AÇÕES

                strExtencao = Path.GetExtension(dirArquivo);

                if (strExtencao == ".new")
                {
                    dirArquivoOriginal = dirArquivo.Replace(".new", "");

                    dirArquivoBackup = Path.GetDirectoryName(dirArquivoOriginal) + "\\Backup update\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + Path.GetFileName(dirArquivoOriginal);

                    System.IO.Directory.CreateDirectory(Path.GetDirectoryName(dirArquivoBackup));

                    try
                    {
                        File.Move(dirArquivoOriginal, dirArquivoBackup);
                    }
                    catch
                    {
                        File.Delete(dirArquivoBackup);
                        File.Move(dirArquivoOriginal, dirArquivoBackup);
                    }

                    try
                    {
                        File.Move(dirArquivo, dirArquivo.Replace(".new", ""));
                    }
                    catch { }
                }

                #endregion
            }
            catch
            {
                //throw ex;
            }
            finally
            {
            }
        }
    }
}

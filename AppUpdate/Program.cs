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
        #region CONSTANTES

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("Kernel32")]
        private static extern IntPtr GetConsoleWindow();

        #endregion

        #region ATRIBUTOS

        private static String _dir;
        private static String dir
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (String.IsNullOrEmpty(_dir))
                    {
                        _dir = Path.GetDirectoryName(Application.ExecutablePath);
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

                //return @"D:\Projetos\SincKlein\Trunk (Desenvolvimento)\bin\Debug";                
                return _dir;
            }
        }

        private static String _dirBackupUpdate;
        private static String dirBackupUpdate
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (String.IsNullOrEmpty(_dirBackupUpdate))
                    {
                        _dirBackupUpdate = Program.dir + "\\Backup update\\" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        Directory.CreateDirectory(_dirBackupUpdate);
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

                return _dirBackupUpdate;
            }
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// 
        /// </summary>
        private static void abrirAppUpdateCopia()
        {
            #region VARIÁVEIS

            Process objProcess;

            #endregion
            try
            {
                #region AÇÕES

                objProcess = new Process();
                objProcess.StartInfo.FileName = "AppUpdate2.exe";
                objProcess.StartInfo.CreateNoWindow = true;
                objProcess.Start();

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

        /// <summary>
        /// 
        /// </summary>
        private static void criarAppUpdateCopia()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                File.Delete(Program.dir + "\\AppUpdate2.exe");
                File.Copy(Application.ExecutablePath, Program.dir + "\\AppUpdate2.exe");

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

            #endregion
            try
            {
                #region AÇÕES

                if (Path.GetExtension(dirArquivo).ToLower() == ".new")
                {
                    dirArquivoOriginal = dirArquivo.Replace(".new", "");
                    dirArquivoBackup = Program.dirBackupUpdate + "\\" + Path.GetFileName(dirArquivoOriginal);
                    
                    File.Move(dirArquivoOriginal, dirArquivoBackup);
                    File.Move(dirArquivo, dirArquivo.Replace(".new", ""));
                }

                #endregion
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public static void processarDir()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                foreach (string dirArquivo in Directory.GetFiles(Program.dir))
                {
                    Program.processarArquivo(dirArquivo);
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

        #endregion

        #region EVENTOS

        public static void Main(string[] args)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                Program.ShowWindow(Program.GetConsoleWindow(), 0);

                if (Application.ExecutablePath.ToLower().Contains("appupdate2.exe"))
                {
                    Program.processarDir();
                }
                else
                {
                    Program.criarAppUpdateCopia();
                    Program.abrirAppUpdateCopia();
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

        #endregion
    }
}

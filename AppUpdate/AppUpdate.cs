using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AppUpdate
{
    public class AppUpdate
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static AppUpdate _i;

        private string[] _arrStrParam;
        private string _dir;
        private string _dirBackupUpdate;
        private string _dirExecutavel;

        public static AppUpdate i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new AppUpdate();

                return _i;
            }
        }

        private string[] arrStrParam
        {
            get
            {
                return _arrStrParam;
            }

            set
            {
                _arrStrParam = value;
            }
        }

        private string dir
        {
            get
            {
                if (_dir != null)
                {
                    return _dir;
                }

                _dir = Path.GetDirectoryName(Application.ExecutablePath);

                return _dir;
            }
        }

        private string dirBackupUpdate
        {
            get
            {
                if (_dirBackupUpdate != null)
                {
                    return _dirBackupUpdate;
                }

                _dirBackupUpdate = this.getDirBackupUpdate();

                return _dirBackupUpdate;
            }
        }

        private string dirExecutavel
        {
            get
            {
                if (_dirExecutavel != null)
                {
                    return _dirExecutavel;
                }

                _dirExecutavel = this.getDirExecutavel();

                return _dirExecutavel;
            }
        }

        #endregion Atributos

        #region Construtores

        private AppUpdate()
        {
        }

        #endregion Construtores

        #region Métodos

        public static void Main(string[] arrStrParam)
        {
            ShowWindow(GetConsoleWindow(), 0);

            i.arrStrParam = arrStrParam;

            i.aguardarFechar();

            if (Application.ExecutablePath.ToLower().Contains("appupdate2.exe"))
            {
                i.processarDir();

                i.abrirSistema();
            }
            else
            {
                i.criarAppUpdateCopia();

                i.abrirAppUpdateCopia();
            }
        }

        private void abrirAppUpdateCopia()
        {
            using (var objProcess = new Process())
            {
                objProcess.StartInfo.Arguments = string.Format("\"{0}\"", this.dirExecutavel);
                objProcess.StartInfo.CreateNoWindow = true;
                objProcess.StartInfo.FileName = "AppUpdate2.exe";

                objProcess.Start();
            }
        }

        private void abrirSistema()
        {
            if (!File.Exists(this.dirExecutavel))
            {
                return;
            }

            using (var objProcess = new Process())
            {
                objProcess.StartInfo.FileName = Path.GetFileName(this.dirExecutavel);

                objProcess.Start();
            }
        }

        private void aguardarFechar()
        {
            if (!File.Exists(this.dirExecutavel))
            {
                return;
            }

            bool booRodando;

            do
            {
                booRodando = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(this.dirExecutavel)).FirstOrDefault(objProcess => objProcess.MainModule.FileName.StartsWith(Path.GetDirectoryName(this.dirExecutavel))) != default(Process);

                Thread.Sleep(100);

            } while (booRodando);

            Thread.Sleep(1000);
        }

        private void criarAppUpdateCopia()
        {
            File.Delete(Path.Combine(i.dir, "AppUpdate2.exe"));

            File.Copy(Application.ExecutablePath, Path.Combine(i.dir, "AppUpdate2.exe"));
        }

        private string getDirBackupUpdate()
        {
            var dirBackupUpdateResultado = Path.Combine(dir, "Backup update", DateTime.Now.ToString("yyyyMMddHHmmss"));

            Directory.CreateDirectory(dirBackupUpdateResultado);

            return dirBackupUpdateResultado;
        }

        private string getDirExecutavel()
        {
            if (this.arrStrParam == null)
            {
                return null;
            }

            if (this.arrStrParam.Length < 1)
            {
                return null;
            }

            return string.Join(null, arrStrParam);
        }

        private void processarArquivo(string dirArquivo)
        {
            if (Path.GetExtension(dirArquivo).ToLower() != ".new")
            {
                return;
            }

            string dirArquivoOriginal = dirArquivo.Replace(".new", null);

            string dirArquivoBackup = Path.Combine(i.dirBackupUpdate, Path.GetFileName(dirArquivoOriginal));

            File.Move(dirArquivoOriginal, dirArquivoBackup);

            File.Move(dirArquivo, dirArquivo.Replace(".new", null));
        }

        private void processarDir()
        {
            foreach (string dirArquivo in Directory.GetFiles(i.dir))
            {
                i.processarArquivo(dirArquivo);
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos

        #region Exteno

        [DllImport("Kernel32")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        #endregion Exteno
    }
}
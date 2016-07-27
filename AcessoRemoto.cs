using System;
using System.Diagnostics;
using System.Threading;
using DigoFramework.Arquivo;

namespace DigoFramework
{
    public class AcessoRemoto : Objeto
    {
        #region Constantes

        public enum EnmStatus
        {
            ACESSO_REMOTO_EM_CURSO,
            CONECTADO,
            CONECTANDO,
            DESCONECTADO
        }

        #endregion Constantes

        #region Atributos

        private ArquivoXml _arqConvite;
        private EnmStatus _enmStatus = EnmStatus.DESCONECTADO;
        private Process _objProcessMsra;
        private string _strArgAtivarSessao;
        private string _strId;
        private string _strSenha;

        public EnmStatus enmStatus
        {
            get
            {
                return _enmStatus;
            }

            set
            {
                _enmStatus = value;
            }
        }

        public string strId
        {
            get
            {
                return _strId;
            }

            set
            {
                if (_strId == value)
                {
                    return;
                }

                _strId = value;

                this.atualizarStrId();
            }
        }

        public string strSenha
        {
            get
            {
                return _strSenha;
            }

            set
            {
                if (_strSenha == value)
                {
                    return;
                }

                _strSenha = value;

                this.atualizarStrSenha();
            }
        }

        protected ArquivoXml arqConvite
        {
            get
            {
                if (_arqConvite != null)
                {
                    return _arqConvite;
                }

                _arqConvite = this.getArqConvite();

                return _arqConvite;
            }
        }

        private Process objProcessMsra
        {
            get
            {
                if (_objProcessMsra != null)
                {
                    return _objProcessMsra;
                }

                _objProcessMsra = this.getObjProcessMsra();

                return _objProcessMsra;
            }
        }

        private string strArgAtivarSessao
        {
            get
            {
                _strArgAtivarSessao = this.getStrArgAtivarSessao();

                return _strArgAtivarSessao;
            }
        }

        #endregion Atributos

        #region Construtores

        public AcessoRemoto()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                Aplicativo.i.finalizarProcesso("msra");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Construtores

        #region Destrutor

        ~AcessoRemoto()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.desativarSessao();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Destrutor

        #region Métodos

        /// <summary>
        /// Liga o aplicativo "msra" e ativa uma nova conexão, que aguardará pelo acesso remoto.
        /// </summary>
        public void ativarSessao()
        {
            if (this.enmStatus == EnmStatus.CONECTADO)
            {
                return;
            }

            this.enmStatus = EnmStatus.CONECTANDO;
            this.arqConvite.deletar();
            this.objProcessMsra.StartInfo.Arguments = this.strArgAtivarSessao;
            this.objProcessMsra.Start();

            while (!this.arqConvite.booExiste)
            {
                Thread.Sleep(100);
            }

            this.enmStatus = EnmStatus.CONECTADO;
        }

        /// <summary>
        /// Desliga o aplicativo "msra.exe", parando a sessão atual.
        /// </summary>
        public void desativarSessao()
        {
            if (this.enmStatus == EnmStatus.DESCONECTADO)
            {
                return;
            }

            Aplicativo.i.finalizarProcesso(objProcessMsra.Id);

            this.arqConvite.deletar();
            this.enmStatus = EnmStatus.DESCONECTADO;
        }

        /// <summary>
        /// Envia o arquivo para um servidor "HTTP".
        /// </summary>
        public void enviarConviteHttp(string url)
        {
            if (!this.arqConvite.booExiste)
            {
                return;
            }

            this.arqConvite.uploadHttp(url);
        }

        /// <summary>
        /// Abre o aplicativo "msra" e passa os parâmetros de localização do arquivo e senha para
        /// executar o acesso ao cliente.
        /// </summary>
        public void fazerAcessoRemoto(string dirArqConvite, string strSenha)
        {
            if (this.enmStatus == EnmStatus.ACESSO_REMOTO_EM_CURSO)
            {
                return;
            }

            this.enmStatus = EnmStatus.CONECTANDO;

            this.objProcessMsra.StartInfo.Arguments = "";
            this.objProcessMsra.StartInfo.Arguments += "/openfile ";
            this.objProcessMsra.StartInfo.Arguments += dirArqConvite;
            this.objProcessMsra.Start();

            this.enmStatus = EnmStatus.ACESSO_REMOTO_EM_CURSO;
        }

        private void atualizarStrId()
        {
            if (string.IsNullOrEmpty(this.strId))
            {
                return;
            }

            this.strId = this.strId.Replace(" ", "");
        }

        private void atualizarStrSenha()
        {
            if (string.IsNullOrEmpty(this.strSenha) || this.strSenha.Length < 6)
            {
                throw new Exception("A senha não pode ter menos que 6 caracteres alfanuméricos.");
            }

            if (!Utils.getBooStrAlfanumerico(this.strSenha))
            {
                throw new Exception("A senha deve conter apenas caracteres alfanuméricos.");
            }
        }

        private ArquivoXml getArqConvite()
        {
            ArquivoXml arqResultado = new ArquivoXml();

            arqResultado.dir = arqResultado.dirTemp;
            arqResultado.strNome = "remote_access.msrcincident";

            return arqResultado;
        }

        private Process getObjProcessMsra()
        {
            Process objProcessResultado = new Process();

            objProcessResultado.StartInfo.CreateNoWindow = true;
            objProcessResultado.StartInfo.FileName = "msra.exe";
            objProcessResultado.StartInfo.RedirectStandardOutput = false;
            objProcessResultado.StartInfo.UseShellExecute = true;
            objProcessResultado.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            return objProcessResultado;
        }

        private string getStrArgAtivarSessao()
        {
            string strResultado = "/saveasfile _dir_completo _str_senha";

            strResultado = strResultado.Replace("_dir_completo", this.arqConvite.dirCompleto);
            strResultado = strResultado.Replace("_str_senha", this.strSenha);

            return strResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
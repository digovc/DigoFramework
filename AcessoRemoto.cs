using DigoFramework.arquivo;
using System;
using System.Diagnostics;
using System.Threading;

namespace DigoFramework
{
    public class AcessoRemoto : Objeto
    {
        #region CONSTANTES

        public enum EnmStatus
        {
            ACESSO_REMOTO_EM_CURSO,
            CONECTADO,
            CONECTANDO,
            DESCONECTADO
        }

        #endregion

        #region ATRIBUTOS

        private ArquivoXml _arqConvite;
        private EnmStatus _enmStatus = EnmStatus.DESCONECTADO;
        private Process _prcMsra;
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
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _strId = value;

                    if (string.IsNullOrEmpty(_strId))
                    {
                        return;
                    }

                    _strId = _strId.Replace(" ", "");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
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
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (string.IsNullOrEmpty(value) || value.Length < 6)
                    {
                        throw new Exception("A senha não pode ter menos que 6 caracteres alfanuméricos.");
                    }

                    if (!Utils.getBooStrAlfanumerico(value))
                    {
                        throw new Exception("A senha deve conter apenas caracteres alfanuméricos.");
                    }

                    _strSenha = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
            }
        }

        protected ArquivoXml arqConvite
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_arqConvite == null)
                    {
                        _arqConvite = new ArquivoXml();
                        _arqConvite.dir = _arqConvite.dirTemp;
                        _arqConvite.strNome = "remote_access.msrcincident";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _arqConvite;
            }
        }

        private Process prcMsra
        {
            get
            {
                #region VARIÁVEIS

                string arg;

                #endregion

                #region AÇÕES

                try
                {
                    if (_prcMsra == null)
                    {
                        _prcMsra = new Process();
                        _prcMsra.StartInfo.UseShellExecute = true;
                        _prcMsra.StartInfo.RedirectStandardOutput = false;
                        _prcMsra.StartInfo.CreateNoWindow = true;
                        _prcMsra.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        _prcMsra.StartInfo.FileName = "msra.exe";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _prcMsra;
            }
        }

        private string strArgAtivarSessao
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _strArgAtivarSessao = "";
                    _strArgAtivarSessao += "/saveasfile ";
                    _strArgAtivarSessao += this.arqConvite.dirCompleto;
                    _strArgAtivarSessao += " ";
                    _strArgAtivarSessao += this.strSenha;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _strArgAtivarSessao;
            }
        }

        #endregion

        #region CONSTRUTORES

        public AcessoRemoto()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                Aplicativo.i.matarProcesso("msra");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        #endregion

        #region DESTRUTOR

        ~AcessoRemoto()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

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

            #endregion
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Liga o aplicativo "msra" e ativa uma nova conexão, que aguardará pelo acesso remoto.
        /// </summary>
        public void ativarSessao()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                if (this.enmStatus == EnmStatus.CONECTADO)
                {
                    return;
                }

                this.enmStatus = EnmStatus.CONECTANDO;
                this.arqConvite.deletar();
                this.prcMsra.StartInfo.Arguments = this.strArgAtivarSessao;
                this.prcMsra.Start();

                while (!this.arqConvite.booExiste)
                {
                    Thread.Sleep(100);
                }

                this.enmStatus = EnmStatus.CONECTADO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Desliga o aplicativo "msra.exe", parando a sessão atual.
        /// </summary>
        public void desativarSessao()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                if (this.enmStatus == EnmStatus.DESCONECTADO)
                {
                    return;
                }

                Aplicativo.i.matarProcesso(prcMsra.Id);

                this.arqConvite.deletar();
                this.enmStatus = EnmStatus.DESCONECTADO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Envia o arquivo para um servidor "HTTP".
        /// </summary>
        public void enviarConviteHttp(string url)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                if (!this.arqConvite.booExiste)
                {
                    return;
                }

                this.arqConvite.uploadHttp(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Abre o aplicativo "msra" e passa os parâmetros de localização do arquivo e senha para
        /// executar o acesso ao cliente.
        /// </summary>
        public void fazerAcessoRemoto(string dirArqConvite, string strSenha)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                if (this.enmStatus == EnmStatus.ACESSO_REMOTO_EM_CURSO)
                {
                    return;
                }

                this.enmStatus = EnmStatus.CONECTANDO;

                this.prcMsra.StartInfo.Arguments = "";
                this.prcMsra.StartInfo.Arguments += "/openfile ";
                this.prcMsra.StartInfo.Arguments += dirArqConvite;
                this.prcMsra.Start();

                this.enmStatus = EnmStatus.ACESSO_REMOTO_EM_CURSO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        #endregion

        #region EVENTOS

        #endregion
    }
}
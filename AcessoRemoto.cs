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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
            }
        }

        protected ArquivoXml arqConvite
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _arqConvite;
            }
        }

        private Process prcMsra
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _prcMsra;
            }
        }

        private string strArgAtivarSessao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

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
                Aplicativo.i.matarProcesso("msra");
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

        #region DESTRUTOR

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

        #endregion DESTRUTOR

        #region Métodos

        /// <summary>
        /// Liga o aplicativo "msra" e ativa uma nova conexão, que aguardará pelo acesso remoto.
        /// </summary>
        public void ativarSessao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Desliga o aplicativo "msra.exe", parando a sessão atual.
        /// </summary>
        public void desativarSessao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Envia o arquivo para um servidor "HTTP".
        /// </summary>
        public void enviarConviteHttp(string url)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Abre o aplicativo "msra" e passa os parâmetros de localização do arquivo e senha para
        /// executar o acesso ao cliente.
        /// </summary>
        public void fazerAcessoRemoto(string dirArqConvite, string strSenha)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
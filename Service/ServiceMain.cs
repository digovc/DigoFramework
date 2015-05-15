using System;
using System.Threading;

namespace DigoFramework.Service
{
    public abstract class ServiceMain : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private bool _booBackground;
        private bool _booPararServico;
        private ThreadPriority _enmPrioridade;
        private Thread _thr;

        protected bool booBackground
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _booBackground = this.thr.IsBackground;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _booBackground;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _booBackground = value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        protected bool booPararServico
        {
            get
            {
                return _booPararServico;
            }

            set
            {
                _booPararServico = value;
            }
        }

        protected ThreadPriority enmPrioridade
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _enmPrioridade = this.thr.Priority;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _enmPrioridade;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _enmPrioridade = value;
                    this.thr.Priority = _enmPrioridade;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        private Thread thr
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_thr != null)
                    {
                        return _thr;
                    }

                    _thr = new Thread(this.inicializar);

                    _thr.Name = this.strNomeExibicao;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _thr;
            }

            set
            {
                _thr = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        protected ServiceMain(string strNome)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.strNome = strNome;

                this.booBackground = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        private void inicializar(object obj)
        {
            #region VARIÁVEIS

            string strErro;

            #endregion VARIÁVEIS

            #region AÇÕES
            try
            {
                this.servico();
                this.finalizar();
            }
            catch (Exception ex)
            {
                strErro = "Erro inesperado no serviço \"_srv_nome\".\nAlgumas funções podem podem parar de funcionar. Tente reiniciar o aplicativo.";
                strErro = strErro.Replace("_srv_nome", this.strNome);

                new Erro(strErro, ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }
            #endregion AÇÕES
        }

        private void finalizar()
        {
            #region VARIÁVEIS
            #endregion VARIÁVEIS

            #region AÇÕES
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            #endregion AÇÕES
        }

        public void iniciarServico()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.booPararServico = false;
                this.thr.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Faz uma chamada solicitando a parada do serviço assim que possível.
        /// </summary>
        public virtual void pararServico()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.booPararServico = true;
                this.thr.Abort();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        protected void dormir(int intMilesegundos)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                Thread.Sleep(intMilesegundos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        protected void dormirMinutos(int intMinutos)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.dormirSegundos(intMinutos * 60);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        protected void dormirSegundos(int intSegundos)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.dormir(intSegundos * 1000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        protected abstract void servico();

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}
using System;
using System.Threading;

namespace DigoFramework.Service
{
    public abstract class ServiceMain : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private bool _booBackground;
        private bool _booPararServico;
        private bool _booRodando;
        private ThreadPriority _enmPrioridade;
        private Thread _thr;

        public bool booRodando
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _booRodando = this.thr.IsAlive;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _booRodando;
            }
        }

        protected bool booBackground
        {
            get
            {
                #region VARIÁVEIS

                #endregion

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

                #endregion

                return _booBackground;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _booBackground = value;
                    this.thr.IsBackground = _booBackground;
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

                #endregion

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

                #endregion

                return _enmPrioridade;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

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

                #endregion
            }
        }

        private Thread thr
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_thr != null)
                    {
                        return _thr;
                    }

                    _thr = new Thread(this.servico);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _thr;
            }

            set
            {
                _thr = value;
            }
        }

        #endregion

        #region CONSTRUTORES
                     
        public ServiceMain()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.booBackground = true;
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

        public void iniciarServico()
        {
            #region VARIÁVEIS

            #endregion

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

            #endregion
        }

        /// <summary>
        /// Faz uma chamada solicitando a parada do serviço assim que possível.
        /// </summary>
        public virtual void pararServico()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.booPararServico = true;
                this.thr = null;
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

        protected void dormir(int intMilesegundos)
        {
            #region VARIÁVEIS

            #endregion

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

            #endregion
        }

        protected void dormirMinutos(int intMinutos)
        {
            #region VARIÁVEIS

            #endregion

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

            #endregion
        }

        protected void dormirSegundos(int intSegundos)
        {
            #region VARIÁVEIS

            #endregion

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

            #endregion
        }

        protected abstract void servico();

        #endregion

        #region EVENTOS

        #endregion
    }
}
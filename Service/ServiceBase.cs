using System;
using System.Threading;

namespace DigoFramework.Service
{
    public abstract class ServiceBase : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booBackground;
        private bool _booParar;
        private ThreadPriority _enmPrioridade;
        private long _lngDormindo;
        private Thread _trd;

        protected bool booBackground
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booBackground = this.trd.IsBackground;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _booBackground;
            }

            set
            {
                _booBackground = value;
            }
        }

        protected bool booParar
        {
            get
            {
                return _booParar;
            }

            set
            {
                _booParar = value;
            }
        }

        protected ThreadPriority enmPrioridade
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _enmPrioridade = this.trd.Priority;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _enmPrioridade;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _enmPrioridade = value;

                    this.trd.Priority = _enmPrioridade;
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

        private long lngDormindo
        {
            get
            {
                return _lngDormindo;
            }

            set
            {
                _lngDormindo = value;
            }
        }

        private Thread trd
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_trd != null)
                    {
                        return _trd;
                    }

                    _trd = new Thread(this.iniciarServico);

                    _trd.IsBackground = true;
                    _trd.Name = this.strNomeExibicao;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _trd;
            }

            set
            {
                _trd = value;
            }
        }

        #endregion Atributos

        #region Construtores

        protected ServiceBase(string strNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        public void iniciar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.booParar = false;
                this.trd.Start();
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
        /// Faz uma chamada solicitando a parada do serviço assim que possível.
        /// </summary>
        public virtual void parar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.booParar = true;
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

        protected void dormir(int intMilesegundos)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (intMilesegundos < 1)
                {
                    return;
                }

                while (this.lngDormindo < intMilesegundos)
                {
                    if (this.booParar)
                    {
                        return;
                    }

                    Thread.Sleep(100);

                    this.lngDormindo += 100;
                }

                this.lngDormindo = 0;
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

        protected void dormirMinutos(int intMinutos)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        protected void dormirSegundos(int intSegundos)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        protected virtual void inicializar()
        {
        }

        protected abstract void servico();

        private void finalizar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void iniciarServico(object obj)
        {
            #region Variáveis

            string strErro;

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
                this.servico();
                this.finalizar();
            }
            catch (Exception ex)
            {
                strErro = "Erro inesperado no serviço \"_srv_nome\".\nAlgumas funções podem parar de funcionar, tente reiniciar o aplicativo.";
                strErro = strErro.Replace("_srv_nome", this.strNome);

                new Erro(strErro, ex);
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
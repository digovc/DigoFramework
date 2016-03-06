﻿using System;
using System.Threading;

namespace DigoFramework.Service
{
    public abstract class ServiceMain : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booBackground;
        private bool _booParar;
        private ThreadPriority _enmPrioridade;
        private long _lngDormindo;
        private Thread _thr;

        protected bool booBackground
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _booBackground;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
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
                    _enmPrioridade = this.thr.Priority;
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
                    this.thr.Priority = _enmPrioridade;
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

        private Thread thr
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_thr != null)
                    {
                        return _thr;
                    }

                    _thr = new Thread(this.iniciarServico);

                    _thr.IsBackground = true;
                    _thr.Name = this.strNomeExibicao;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _thr;
            }

            set
            {
                _thr = value;
            }
        }

        #endregion Atributos

        #region Construtores

        protected ServiceMain(string strNome)
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
                this.thr.Start();
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

                new Erro(strErro, ex, Erro.ErroTipo.FATAL);
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
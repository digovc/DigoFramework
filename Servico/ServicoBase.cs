using System;
using System.Threading;

namespace DigoFramework.Servico
{
    public abstract class ServicoBase : Objeto
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
                _booBackground = this.trd.IsBackground;

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
                _enmPrioridade = this.trd.Priority;

                return _enmPrioridade;
            }

            set
            {
                _enmPrioridade = value;

                this.trd.Priority = _enmPrioridade;
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
                if (_trd != null)
                {
                    return _trd;
                }

                _trd = new Thread(this.iniciarServico);

                _trd.IsBackground = true;
                _trd.Name = this.strNomeExibicao;

                return _trd;
            }

            set
            {
                _trd = value;
            }
        }

        #endregion Atributos

        #region Construtores

        protected ServicoBase(string strNome)
        {
            this.strNome = strNome;

            this.booBackground = true;
        }

        #endregion Construtores

        #region Métodos

        public void iniciar()
        {
            this.booParar = false;
            this.trd.Start();
        }

        /// <summary>
        /// Faz uma chamada solicitando a parada do serviço assim que possível.
        /// </summary>
        public virtual void parar()
        {
            this.booParar = true;
        }

        protected void dormir(int intMilesegundos)
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

        protected void dormirMinuto(int intMinuto)
        {
            this.dormirSegundo(intMinuto * 60);
        }

        protected void dormirSegundo(int intSegundo)
        {
            this.dormir(intSegundo * 1000);
        }

        protected virtual void finalizar()
        {
        }

        protected virtual void inicializar()
        {
        }

        protected abstract void servico();

        private void iniciarServico(object obj)
        {
            string strErro;

            try
            {
                this.inicializar();
                this.servico();
            }
            catch (Exception ex)
            {
                strErro = "Erro inesperado no serviço \"_srv_nome\".\nAlgumas funções podem parar de funcionar, tente reiniciar o aplicativo.";
                strErro = strErro.Replace("_srv_nome", this.strNome);

                new Erro(strErro, ex);
            }
            finally
            {
                this.finalizar();
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
using System;
using System.Threading;

namespace DigoFramework.Service
{
    public abstract class ServiceBase : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booParar;
        private long _lngDormindo;
        private Thread _trd;

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

        protected Thread trd
        {
            get
            {
                if (_trd != null)
                {
                    return _trd;
                }

                _trd = this.getTrd();

                return _trd;
            }

            private set
            {
                _trd = value;
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

        #endregion Atributos

        #region Construtores

        protected ServiceBase(string strNome)
        {
            this.strNome = strNome;
        }

        private Thread getTrd()
        {
            Thread trdResultado = new Thread(this.iniciarServico);

            trdResultado.IsBackground = true;
            trdResultado.Name = this.strNomeExibicao;

            return trdResultado;
        }

        #endregion Construtores

        #region Métodos

        public void iniciar()
        {
            this.booParar = false;

            while (this.trd.IsAlive)
            {
                continue;
            }

            this.trd = null;

            this.trd.Start();
        }

        /// <summary>
        /// Faz uma chamada solicitando a parada do serviço assim que possível.
        /// </summary>
        public virtual void parar()
        {
            this.booParar = true;
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
            try
            {
                this.inicializar();
                this.servico();
                this.finalizar();
            }
            catch (Exception ex)
            {
                string strErro = "Erro inesperado no serviço \"_srv_nome\".\nAlgumas funções podem parar de funcionar, tente reiniciar o aplicativo.";

                strErro = strErro.Replace("_srv_nome", this.strNome);

                new Erro(strErro, ex);
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
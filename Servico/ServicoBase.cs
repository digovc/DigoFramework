using System;
using System.Threading;

namespace DigoFramework.Servico
{
    public abstract class ServicoBase : Objeto
    {
        #region Constantes

        private const int INT_MICRO_INTERVALO = (1000 * 15);

        #endregion Constantes

        #region Atributos

        private bool _booAcordar;
        private bool _booBackground;
        private bool _booParar;
        private ThreadPriority _enmPrioridade;
        private long _lngDormindo;
        private Thread _trd;

        public bool booAcordar
        {
            get
            {
                return _booAcordar;
            }

            set
            {
                _booAcordar = value;
            }
        }

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

                _trd = this.getTrd();

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

        /// <summary>
        /// Inicia o serciço, neste momento uma thread em segundo plano executa a lógica contida
        /// dentro do método <see cref="servico"/>.
        /// </summary>
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

        protected void dormir(int intMilesegundo)
        {
            if (intMilesegundo < 1)
            {
                return;
            }

            while (this.lngDormindo < intMilesegundo)
            {
                if (this.booAcordar)
                {
                    this.booAcordar = false;
                    return;
                }

                if (this.booParar)
                {
                    return;
                }

                Thread.Sleep(INT_MICRO_INTERVALO);

                this.lngDormindo += INT_MICRO_INTERVALO;
            }

            this.lngDormindo = 0;
        }

        protected void dormirHora(int intHora)
        {
            this.dormirMinuto(intHora * 60);
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
            Log.i.info(string.Format("Serviço \"{0}\" finalizado.", (!string.IsNullOrEmpty(this.strNome) ? this.strNome : this.GetType().Name)));
        }

        protected virtual void inicializar()
        {
            Log.i.info(string.Format("Inicializando o serviço \"{0}\".", (!string.IsNullOrEmpty(this.strNome) ? this.strNome : this.GetType().Name)));
        }

        protected abstract void servico();

        protected virtual void setEventos()
        {
        }

        protected override void setStrNome(string strNome)
        {
            base.setStrNome(strNome);

            this.trd.Name = strNome;
        }

        private Thread getTrd()
        {
            var trdResultado = new Thread(this.iniciarServico);

            trdResultado.IsBackground = true;

            return trdResultado;
        }

        private void iniciarServico(object obj)
        {
            try
            {
                this.inicializar();

                this.setEventos();

                this.servico();
            }
            catch (Exception ex)
            {
                new Erro(string.Format("Erro inesperado no serviço \"{0}\".", this.strNome), ex);
            }
            finally
            {
                try
                {
                    this.finalizar();
                }
                catch (Exception ex)
                {
                    new Erro(string.Format("Erro inesperado ao finalizar o serviço \"{0}\".", this.strNome), ex);
                }
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
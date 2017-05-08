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
            Log.i.info(string.Format("Serviço \"{0}\" finalizado.", (!string.IsNullOrEmpty(this.strNome) ? this.strNome : this.GetType().Name)));
        }

        protected virtual void inicializar()
        {
            Log.i.info(string.Format("Inicializando o serviço \"{0}\".", (!string.IsNullOrEmpty(this.strNome) ? this.strNome : this.GetType().Name)));

            this.setEventos();
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
            Thread trdResultado = new Thread(this.iniciarServico);

            trdResultado.IsBackground = true;
            //trdResultado.Name = this.strNome;

            return trdResultado;
        }

        private void iniciarServico(object obj)
        {
            try
            {
                this.inicializar();

                Log.i.info(string.Format("Serviço \"{0}\" inicializado.", this.strNome));

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
using DigoFramework.Anotacao;
using System.Threading;

namespace DigoFramework
{
    public abstract class Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static int _intObjetoIdStatic;

        private int _intObjetoId;
        private string _strDescricao;
        private string _strNome;
        private string _strNomeExibicao;
        private string _strNomeSimplificado;
        private Thread _trdLock;

        /// <summary>
        /// Inteiro que identifica a instância do objeto.
        /// </summary>
        [AppConfigInvisivel]
        public int intObjetoId
        {
            get
            {
                if (_intObjetoId > 0)
                {
                    return _intObjetoId;
                }

                _intObjetoId = intObjetoIdStatic++;

                return _intObjetoId;
            }
        }

        [AppConfigInvisivel]
        public string strDescricao
        {
            get
            {
                return _strDescricao;
            }

            set
            {
                _strDescricao = value;
            }
        }

        /// <summary>
        /// Nome que identifica este objeto.
        /// </summary>
        [AppConfigInvisivel]
        public string strNome
        {
            get
            {
                return _strNome;
            }

            set
            {
                if (_strNome == value)
                {
                    return;
                }

                _strNome = value;

                this.setStrNome(_strNome);
            }
        }

        /// <summary>
        /// Nome que identifica este objeto, utilizado para exibição para o usuario.
        /// </summary>
        [AppConfigInvisivel]
        public string strNomeExibicao
        {
            get
            {
                if (!string.IsNullOrEmpty(_strNomeExibicao))
                {
                    return _strNomeExibicao;
                }

                _strNomeExibicao = this.getStrNomeExibicao();

                return _strNomeExibicao;
            }

            set
            {
                if (_strNomeExibicao == value)
                {
                    return;
                }

                _strNomeExibicao = value;

                this.setStrNomeExibicao(_strNomeExibicao);
            }
        }

        [AppConfigInvisivel]
        public string strNomeSimplificado
        {
            get
            {
                if (!string.IsNullOrEmpty(_strNomeSimplificado))
                {
                    return _strNomeSimplificado;
                }

                _strNomeSimplificado = Utils.simplificar(this.strNome);

                return _strNomeSimplificado;
            }
        }

        private static int intObjetoIdStatic
        {
            get
            {
                return _intObjetoIdStatic;
            }

            set
            {
                _intObjetoIdStatic = value;
            }
        }

        private Thread trdLock
        {
            get
            {
                return _trdLock;
            }

            set
            {
                _trdLock = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Bloqueia este processo até que o método <see cref="liberarThread"/> seja chamado.
        /// <para/>
        /// Isso tem o propósito de evitar problemas com concorrência em sistemas com multi-processos.
        /// </summary>
        public void bloquearThread()
        {
            if (Thread.CurrentThread.Equals(this.trdLock))
            {
                return;
            }

            if (this.trdLock != null)
            {
                this.esperarThread();
            }

            this.trdLock = Thread.CurrentThread;
        }

        /// <summary>
        /// Método vazio que não executa nenhuma ação.
        /// </summary>
        public void fazerNada()
        {
            return;
        }

        /// <summary>
        /// Libera o fluxo normal do processo.
        /// </summary>
        public void liberarThread()
        {
            if (this.trdLock == null)
            {
                return;
            }

            this.trdLock = null;
        }

        protected virtual string getStrNomeExibicao()
        {
            if (string.IsNullOrEmpty(this.strNome))
            {
                return "<Desconhecido>";
            }

            string strResultado = this.strNome;

            strResultado = Utils.getStrPrimeiraMaiuscula(strResultado);

            strResultado = strResultado.Replace("_", " ");
            strResultado = strResultado.Trim();

            return strResultado;
        }

        protected virtual void setStrNome(string strNome)
        {
        }

        private void esperarThread()
        {
            while (this.trdLock != null)
            {
                Thread.Sleep(5);
            }
        }

        private void setStrNomeExibicao(string strNomeExibicao)
        {
            if (string.IsNullOrEmpty(strNomeExibicao))
            {
                return;
            }

            if (char.IsUpper(strNomeExibicao[0]))
            {
                return;
            }

            this.strNomeExibicao = Utils.getStrPrimeiraMaiuscula(strNomeExibicao);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
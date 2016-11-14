using DigoFramework.Anotacao;

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
                _strNome = value;
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
                _strNomeExibicao = value;
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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método vazio que não executa nenhuma ação.
        /// </summary>
        public void fazerNada()
        {
            return;
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
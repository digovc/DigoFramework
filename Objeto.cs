using System;

namespace DigoFramework
{
    abstract public class Objeto
    {
        #region CONSTANTES

        static public Int32 intContagem;

        #endregion

        #region ATRIBUTOS

        private Int32 _intId = Objeto.intContagem + 1;
        /// <summary>
        /// Inteiro que indica o número que identifica o Objeto
        /// </summary>
        public Int32 intId { get { return _intId; } set { _intId = value; } }

        private String _strDescricao = String.Empty;
        public String strDescricao
        {
            get
            {
                return (_strDescricao != Utils.STRING_VAZIA ? _strDescricao : this.strNome);
            }
            set { _strDescricao = value; }
        }

        private String _strNome = Utils.STRING_VAZIA;
        public String strNome
        {
            get { return _strNome; }
            set
            {
                _strNome = value;
                this.strNomeSimplificado = Utils.getStrSimplificada(_strNome);
            }
        }

        private String _strNomeSimplificado = String.Empty;
        public String strNomeSimplificado { get { return _strNomeSimplificado; } set { _strNomeSimplificado = value; } }

        #endregion

        #region CONSTRUTORES

        public Objeto()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            Objeto.intContagem = Objeto.intContagem + 1;

            #endregion
        }
        #endregion

        #region MÉTODOS

        #endregion
    }
}
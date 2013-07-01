using System;

namespace DigoFramework
{
    abstract public class Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES
        private Int32 _intId = 0;
        /// <summary>
        /// Inteiro que indica o número que identifica o Objeto
        /// </summary>
        public Int32 intId { get { return _intId; } set { _intId = value; } }

        private String _strDescricao = String.Empty;
        public String strDescricao { get { return _strDescricao; } set { _strDescricao = value; } }

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
            // EXTERNOS
            // VARIÁVEIS
            // AÇÕES
            intId++;
        }
        #endregion

        #region MÉTODOS

        #endregion
    }
}
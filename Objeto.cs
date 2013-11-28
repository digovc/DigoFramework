using System;

namespace DigoFramework
{
    public abstract class Objeto
    {
        #region CONSTANTES

        public static Int32 intContagem;

        #endregion

        #region ATRIBUTOS

        private Int32 _intId = Objeto.intContagem + 1;
        public Int32 intId { get { return _intId; } set { _intId = value; } }

        private String _strDescricao = String.Empty;
        public String strDescricao
        {
            get
            {
                //return (_strDescricao != Utils.STRING_VAZIA ? _strDescricao : this.strNome);
                return _strDescricao;
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
            }
        }

        private String _strNomeSimplificado = String.Empty;
        public String strNomeSimplificado
        {
            get
            {
                _strNomeSimplificado = Utils.getStrSimplificada(_strNome);
                return _strNomeSimplificado;
            }
        }

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
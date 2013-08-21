using System;
using System.Collections.Generic;

namespace DigoFramework
{
    public class MensagemUsuario : Objeto
    {
        #region CONSTANTES

        public enum Lingua
        {
            Portugues,
            Ingles
        }

        #endregion

        #region ATRIBUTOS

        private Lingua _objLingua = Lingua.Portugues;
        public Lingua objLingua { get { return _objLingua; } set { _objLingua = value; } }

        private String _strMensagem = String.Empty;
        public String strMensagem { get { return _strMensagem; } set { _strMensagem = value; } }

        #endregion

        #region CONSTRUTORES

        public MensagemUsuario(String strMensagem, Int32 intId = -1, Lingua objLingua = Lingua.Portugues)
        {
            #region VARIÁVEIS

            this.strMensagem = strMensagem;
            if (intId != -1) { this.intId = intId; }
            this.objLingua = objLingua;

            #endregion

            #region AÇÕES
            #endregion
        }

        #endregion

        #region MÉTODOS
        #endregion

        #region EVENTOS
        #endregion
    }
}

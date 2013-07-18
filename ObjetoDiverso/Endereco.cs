using System;

namespace DigoFramework.ObjetoDiverso
{
    public class Endereco : Objeto
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private Int32 _intCep;
        public Int32 intCep { get { return _intCep; } set { _intCep = value; } }

        private Int32 _intNumero = 0;
        public Int32 intNumero { get { return _intNumero; } set { _intNumero = value; } }

        private Bairro _objBairro = new Bairro();
        public Bairro objBairro { get { return _objBairro; } set { _objBairro = value; } }

        private Logradouro _objLogradouro = new Logradouro();
        public Logradouro objLogradouro { get { return _objLogradouro; } set { _objLogradouro = value; } }

        private String _strComplemento = String.Empty;
        public String strComplemento { get { return _strComplemento; } set { _strComplemento = value; } }

        #endregion

        #region CONSTRUTORES
        #endregion

        #region MÉTODOS
        #endregion
    }
}

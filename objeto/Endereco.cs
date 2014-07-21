using System;

namespace DigoFramework.objeto
{
    public class Endereco : ObjMain
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Int32 _intCep;
        private Int32 _intNumero = 0;

        private Bairro _objBairro = new Bairro();

        private Logradouro _objLogradouro = new Logradouro();

        private String _strComplemento = String.Empty;

        public Int32 intCep
        {
            get
            {
                return _intCep;
            }

            set
            {
                _intCep = value;
            }
        }

        public Int32 intNumero
        {
            get
            {
                return _intNumero;
            }

            set
            {
                _intNumero = value;
            }
        }

        public Bairro objBairro
        {
            get
            {
                return _objBairro;
            }

            set
            {
                _objBairro = value;
            }
        }

        public Logradouro objLogradouro
        {
            get
            {
                return _objLogradouro;
            }

            set
            {
                _objLogradouro = value;
            }
        }

        public String strComplemento
        {
            get
            {
                return _strComplemento;
            }

            set
            {
                _strComplemento = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}
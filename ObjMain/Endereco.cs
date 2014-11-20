using System;

namespace DigoFramework.ObjMain
{
    public class Endereco : ObjMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private int _intCep;
        private int _intNumero;
        private Bairro _objBairro;
        private Logradouro _objLogradouro;
        private string _strComplemento;

        public int intCep
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

        public int intNumero
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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_objBairro != null)
                    {
                        return _objBairro;
                    }

                    _objBairro = new Bairro();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_objLogradouro != null)
                    {
                        return _objLogradouro;
                    }

                    _objLogradouro = new Logradouro();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _objLogradouro;
            }

            set
            {
                _objLogradouro = value;
            }
        }

        public string strComplemento
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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS
    }
}
using System;

namespace DigoFramework.ObjMain
{
    public class Endereco : ObjMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

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

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos
    }
}
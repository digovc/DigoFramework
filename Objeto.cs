using System;

namespace DigoFramework
{
    public abstract class Objeto
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private static int _intIndex;
        private static int intIndex { get { return _intIndex; } set { _intIndex = value; } }

        private Int32 _intId;
        public Int32 intId { get { return _intId; } set { _intId = value; } }

        private String _strDescricao;
        public String strDescricao { get { return _strDescricao; } set { _strDescricao = value; } }

        private String _strNome;
        public String strNome { get { return _strNome; } set { _strNome = value; } }

        private String _strNomeExibicao;
        public String strNomeExibicao
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (String.IsNullOrEmpty(_strNomeExibicao))
                    {
                        _strNomeExibicao = Utils.formatarTitulo(this.strNome);
                    }
                    else
                    {
                        _strNomeExibicao = Utils.formatarTitulo(_strNomeExibicao);
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _strNomeExibicao;
            }
            set { _strNomeExibicao = value; }
        }

        private String _strNomeSimplificado;
        public String strNomeSimplificado
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _strNomeSimplificado = Utils.simplificarStr(_strNome);

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _strNomeSimplificado;
            }
        }

        #endregion

        #region CONSTRUTORES

        public Objeto()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                Objeto.intIndex++;
                this.intId = Objeto.intIndex;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        #endregion

        #region MÉTODOS

        #endregion
    }
}
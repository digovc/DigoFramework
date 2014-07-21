using System;

namespace DigoFramework.relatorio.objeto
{
    public abstract class ObjRelatorioMain : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private int _intRegistroId;

        public int intRegistroId
        {
            get
            {
                return _intRegistroId;
            }

            set
            {
                _intRegistroId = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        public ObjRelatorioMain()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.strNome = "Sem nome";
                this.strDescricao = "Sem descrição";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        #endregion

        #region DESTRUTOR

        #endregion

        #region MÉTODOS

        #endregion

        #region EVENTOS

        #endregion
    }
}
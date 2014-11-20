using System;

namespace DigoFramework.Relatorio.ObjMain
{
    public abstract class ObjRelatorioMain : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public ObjRelatorioMain()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region DESTRUTOR

        #endregion DESTRUTOR

        #region MÉTODOS

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}
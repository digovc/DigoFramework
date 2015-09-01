using System;

namespace DigoFramework.Relatorio.ObjMain
{
    public abstract class ObjRelatorioMain : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

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

        #endregion Atributos

        #region Construtores

        public ObjRelatorioMain()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
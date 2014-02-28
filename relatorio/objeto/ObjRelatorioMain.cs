using DigoFramework;
using System;

namespace DigoFramework.relatorio.objeto
{
    public abstract class ObjRelatorioMain : Objeto
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private int _intRegistroId;
        public int intRegistroId { get { return _intRegistroId; } set { _intRegistroId = value; } }

        #endregion

        #region CONSTRUTORES

        public ObjRelatorioMain()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.strNome = "Sem nome";
                this.strDescricao = "Sem descrição";

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

        #region DESTRUTOR
        #endregion

        #region MÉTODOS
        #endregion

        #region EVENTOS
        #endregion
    }
}

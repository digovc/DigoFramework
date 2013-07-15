using System;

namespace DigoFramework.ArquivoSis
{
    public class ArquivoExe : Arquivo
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Boolean _booPrincipal = false;
        public Boolean booPrincipal { get { return _booPrincipal; } set { _booPrincipal = value; } }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        public override void salvar()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            System.IO.File.WriteAllText(this.dirDiretorio, this.strConteudo);

            #endregion
        }

        #endregion
    }
}


namespace DigoFramework.ArquivoSis
{
    public class ArquivoTxt : Arquivo
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

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

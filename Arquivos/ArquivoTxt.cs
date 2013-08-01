
namespace DigoFramework.Arquivos
{
    public class ArquivoTxt : Arquivo
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        #endregion

        #region CONSTRUTORES

        public ArquivoTxt()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objMimeTipo = Arquivo.MimeTipo.TEXT_PLAIN;

            #endregion
        }

        #endregion

        #region MÉTODOS

        protected override void setInMimeType()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objMimeTipo = MimeTipo.TEXT_PLAIN;

            #endregion
        }

        #endregion
    }
}

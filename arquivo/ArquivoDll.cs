namespace DigoFramework.Arquivo
{
    public class ArquivoDll : ArquivoBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.enmContentType = EnmContentType.BIN_APPLICATION_OCTET_STREAM;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
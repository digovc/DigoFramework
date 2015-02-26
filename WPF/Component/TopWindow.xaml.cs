using System;
using System.Windows.Controls;

namespace DigoFramework.WPF.Component
{
    /// <summary>
    /// Interaction logic for TopWindow.xaml
    /// </summary>
    public partial class TopWindow : UserControl
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public TopWindow()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.InitializeComponent();
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

        #region MÉTODOS

        private void sair()
        {
            #region VARIÁVEIS
            #endregion VARIÁVEIS

            #region AÇÕES
            try
            {
            
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

        #endregion MÉTODOS

        #region EVENTOS

        private void btnSair_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.sair();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion EVENTOS
    }
}
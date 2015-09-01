using System;
using System.Windows.Controls;

namespace DigoFramework.WPF.Component
{
    /// <summary>
    /// Interaction logic for TopWindow.xaml
    /// </summary>
    public partial class TopWindow : UserControl
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public TopWindow()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        private void sair()
        {
            #region Variáveis
            #endregion Variáveis

            #region Ações
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
            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        private void btnSair_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Eventos
    }
}
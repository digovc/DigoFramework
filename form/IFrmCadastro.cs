namespace DigoFramework.form
{
    public interface IFrmCadastro
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Carrega os dados default do formulário como valores de "combobox", datas padrão, etc.
        /// </summary>
        void carregarDados();

        /// <summary>
        /// Carrega os valores de um registro do banco de dados nos seus respectivos campos do formulário.
        /// </summary>
        void carregarRegistro();

        /// <summary>
        /// Salva os valores inseridos pelos usuário nos campos do formulário na tabela para
        /// persistência no banco de dados.
        /// </summary>
        void salvarRegistro();

        /// <summary>
        /// Método que faz com que o campo inicial receba o foco da tela.
        /// </summary>
        void setFocoInicial();

        #endregion

        #region EVENTOS

        #endregion
    }
}
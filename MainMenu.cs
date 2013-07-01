using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DigoFramework
{
    public class MainMenu : Objeto
    {
        #region CONSTANTES


        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private MenuStrip _objMainMenu = new MenuStrip();
        public MenuStrip objMainMenu { get { return _objMainMenu; } set { _objMainMenu = value; } }

        private List<Modulo> _lstObjModulos = new List<Modulo>();
        public List<Modulo> lstObjModulos
        {
            get { return _lstObjModulos; }
            set
            {
                _lstObjModulos = value;
                this.preparaMenu();
            }
        }

        #endregion

        #region CONSTRUTORES

        public MainMenu(List<Modulo> lMdlModulos)
        {
            // EXTERNOS
            // VARIÁVEIS
            // AÇÕES
            this.lstObjModulos = lMdlModulos;
        }

        #endregion

        #region MÉTODOS

        private void preparaMenu()
        {
            // EXTERNOS
            // VARIÁVEIS
            Int16 intIdMenuPrincipal = 0;
            Int16 intIdSubMenu = 0;
            // AÇÕES
            foreach (Modulo mdlModulo in this.lstObjModulos)
            {
                if (mdlModulo.booVisivel)
                {
                    ToolStripMenuItem objMenuPrincipal = new ToolStripMenuItem();
                    this.objMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { objMenuPrincipal });
                    objMenuPrincipal.Name = "objMenuPrincipal" + Convert.ToString(intIdMenuPrincipal);
                    objMenuPrincipal.Text = mdlModulo.strNome;

                    foreach (DbTabela tblTabela in mdlModulo.lstObjTabelas)
                    {
                        if (tblTabela.booVisivel)
                        {
                            ToolStripMenuItem objSubMenu = new ToolStripMenuItem();
                            objMenuPrincipal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { objSubMenu });
                            objSubMenu.Name = "objSubMenu" + Convert.ToString(intIdSubMenu);
                            objSubMenu.Text = tblTabela.strNome;

                            // Opção para Cadastro geral
                            ToolStripMenuItem objSubMenuCadastro = new ToolStripMenuItem();
                            objSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { objSubMenuCadastro });
                            objSubMenuCadastro.Name = "objSubMenuCadastro" + Convert.ToString(intIdMenuPrincipal);
                            objSubMenuCadastro.Text = "Cadastro";
                            objSubMenuCadastro.Click += new System.EventHandler(tblTabela.acaoAbrirFormCadastro);

                            // Opção para Novo
                            ToolStripMenuItem objSubMenuNovo = new ToolStripMenuItem();
                            objSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { objSubMenuNovo });
                            objSubMenuNovo.Name = "objSubMenuNovo" + Convert.ToString(intIdMenuPrincipal);
                            objSubMenuNovo.Text = "Novo";
                            objSubMenuNovo.Click += new System.EventHandler(tblTabela.acaoAbrirFormEdicao);

                            // Opção para Relatórios
                            ToolStripMenuItem objSubMenuRelatorio = new ToolStripMenuItem();
                            objSubMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { objSubMenuRelatorio });
                            objSubMenuRelatorio.Name = "objSubMenuRelatorio" + Convert.ToString(intIdMenuPrincipal);
                            objSubMenuRelatorio.Text = "Relatórios";

                            //objSubMenu.Click += new System.EventHandler(this.test);
                            intIdSubMenu++;
                        }
                    }
                    intIdMenuPrincipal++;
                }
            }
        }
        #endregion
    }
}

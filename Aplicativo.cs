﻿using System;
using System.Configuration;
using System.Windows.Forms;
using DigoFramework.DataBase;
using Microsoft.Win32;
using DigoFramework.Formulário;
using System.Collections.Generic;
using DigoFramework.ArquivoSis;

namespace DigoFramework
{
    public abstract class Aplicativo : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Boolean _booBeta = true;
        public Boolean booBeta { get { return _booBeta; } set { _booBeta = value; } }

        private Boolean _booDesenvolvimentoProducao = true;
        public Boolean booDesenvolvimentoProducao { get { return _booDesenvolvimentoProducao; } set { _booDesenvolvimentoProducao = value; } }

        private Boolean _booIniciarComWindows;
        public Boolean booIniciarComWindows
        {
            get { return _booIniciarComWindows; }
            set
            {
                _booIniciarComWindows = value;
                RegistryKey objRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (_booIniciarComWindows) { objRegistryKey.SetValue(this.strNome, this.dirExecutavelCompleto); }
                else { objRegistryKey.DeleteValue(this.strNome, false); }
            }
        }

        private String _dirExecutavel = Application.StartupPath;
        public String dirExecutavel { get { return _dirExecutavel; } }

        public String dirExecutavelCompleto { get { return Application.ExecutablePath; } }

        private Form _frmCadastro;
        public Form frmCadastro { get { return _frmCadastro; } set { _frmCadastro = value; } }

        private Form _frmEdicao;
        public Form frmEdicao { get { return _frmEdicao; } set { _frmEdicao = value; } }

        private Form _frmMain;
        public Form frmMain
        {
            get { return _frmMain; }
            set
            {
                _frmMain = value;
                _frmMain.Text = this.getStrTituloAplicativo();
            }
        }

        private Int16 _intVersao = 1;
        public Int16 intVersao { get { return _intVersao; } set { _intVersao = value; } }

        private Int16 _intVersaoSub = 0;
        public Int16 intVersaoSub { get { return _intVersaoSub; } set { _intVersaoSub = value; } }

        private Int32 _intVersaoBug = 0;
        public Int32 intVersaoBug
        {
            get { return _intVersaoBug; }
            set
            {
                _intVersaoBug = value;
                try { frmMain.Text = this.getStrTituloAplicativo(); }
                catch (Exception) { }
            }
        }

        private Int32 _intVersaoBuid = 0;
        public Int32 intVersaoBuid
        {
            get { return _intVersaoBuid; }
            set
            {
                _intVersaoBuid = value;
                try { frmMain.Text = this.getStrTituloAplicativo(); }
                catch (Exception) { }
            }
        }

        private List<Arquivo> _lstObjArquivoDependencia = new List<Arquivo>();
        public List<Arquivo> lstObjArquivoDependencia { get { return _lstObjArquivoDependencia; } set { _lstObjArquivoDependencia = value; } }

        private ArquivoExe _objArquivoExePrincipal = new ArquivoExe();
        public ArquivoExe objArquivoExePrincipal
        {
            get
            {
                _objArquivoExePrincipal.booPrincipal = true;
                _objArquivoExePrincipal.strNome = this.strNome;
                _objArquivoExePrincipal.strDescricao = this.strDescricao;
                _objArquivoExePrincipal.dirDiretorio = this.dirExecutavel;
                return _objArquivoExePrincipal;
            }
        }

        private ArquivoXml _objArquivoXmlConfig = new ArquivoXml();
        public ArquivoXml objArquivoXmlConfig { get { return _objArquivoXmlConfig; } set { _objArquivoXmlConfig = value; } }

        private DbTabela _objTabelaSelecionada;
        public DbTabela objTabelaSelecionada { get { return _objTabelaSelecionada; } set { _objTabelaSelecionada = value; } }

        #endregion

        #region CONSTRUTORES

        public Aplicativo()
        {
            #region VARIÁVEIS

            this.lstObjArquivoDependencia.Add(this.objArquivoExePrincipal);

            #endregion

            #region AÇÕES

            try { this.setInObjArquivoXmlConfig(); }
            catch (Exception ex) { new Erro("Erro ao criar Arquivo XML de configuração do Aplicativo.", ex, Erro.ErroTipo.Notificao); }

            #endregion
        }

        #endregion

        #region MÉTODOS

        public String getStrTituloAplicativo()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            return String.Format("{0} - {1} ({2})", this.strNome, this.strDescricao, this.getStrVersaoCompleta());

            #endregion
        }

        public String getStrVersaoCompleta()
        {
            // EXTERNOS
            // VARIÁVEIS
            String strVersaoCompleta = Utils.STRING_VAZIA;

            // AÇÕES
            strVersaoCompleta += Convert.ToString(this.intVersao);
            strVersaoCompleta += '.';
            strVersaoCompleta += Convert.ToString(this.intVersaoSub);
            strVersaoCompleta += '.';
            strVersaoCompleta += Convert.ToString(this.intVersaoBug);
            strVersaoCompleta += '.';
            strVersaoCompleta += Convert.ToString(this.intVersaoBuid);
            strVersaoCompleta += (this.booBeta ? " Beta" : "");

            return strVersaoCompleta;
        }

        public FrmEspera mostraFormularioEspera(String strTarefaDescricao = "Rotina do Sistema {sis_nome} sendo realizada...", String strTarefaTitulo = "Por favor, aguarde...")
        {
            #region VARIÁVEIS

            FrmEspera frmEspera = new FrmEspera();

            #endregion

            #region AÇÕES

            if (strTarefaDescricao == "Rotina do Sistema {sis_nome} sendo realizada...")
            {
                strTarefaDescricao = "Rotina do Sistema " + this.strNome + " sendo realizada...";
            }
            frmEspera.strTarefaTitulo = strTarefaTitulo;
            frmEspera.strTarefaDescricao = strTarefaDescricao;
            frmEspera.Show();
            Application.DoEvents();
            return frmEspera;

            #endregion
        }

        private void setInObjArquivoXmlConfig()
        {
            #region VARIÁVEIS

            Int32 intBuidNova = 0;
            String dirArquivoXmlConfig = this.dirExecutavel + "\\AppConfig.xml";

            #endregion

            #region AÇÕES

            // Criar o arquivo caso não exista
            if (!System.IO.File.Exists(dirArquivoXmlConfig))
            {
                this.objArquivoXmlConfig.dirDiretorio = dirArquivoXmlConfig;
                this.objArquivoXmlConfig.addNode("VersaoBuid", "0");
            }
            else
            {
                this.objArquivoXmlConfig.dirDiretorio = dirArquivoXmlConfig;
            }

            // Atualiza buid do Sistema
            if (this.booDesenvolvimentoProducao)
            {
                intBuidNova = Convert.ToInt32(this.objArquivoXmlConfig.getStrElementoConteudo("DigoFramework/VersaoBuid"));
                intBuidNova++;
                this.objArquivoXmlConfig.setStrElementoConteudo("DigoFramework/VersaoBuid", intBuidNova.ToString());
            }

            this.intVersaoBuid = intBuidNova;

            #endregion
        }

        #endregion
    }
}

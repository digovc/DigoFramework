using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using DigoFramework.Arquivos;
using DigoFramework.DataBase;
using DigoFramework.Formulário;
using Microsoft.Win32;

namespace DigoFramework
{
    public abstract class Aplicativo : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private static Aplicativo _appInstancia;
        public static Aplicativo appInstancia { get { return _appInstancia; } }

        private bool _booAplicativoWeb = false;
        public bool booAplicativoWeb
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    _booAplicativoWeb = false;
                }
                else
                {
                    _booAplicativoWeb = true;
                }
                return _booAplicativoWeb;
            }
        }

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
        public String dirExecutavel
        {
            get
            {
                if (this.booAplicativoWeb)
                {
                    _dirExecutavel = HttpContext.Current.Server.MapPath("~/");
                }
                return _dirExecutavel;
            }
        }

        public String dirExecutavelCompleto { get { return Application.ExecutablePath.Replace("EXE", "exe"); } }

        private FrmEspera _frmEspera;
        private FrmEspera frmEspera
        {
            get
            {
                if (_frmEspera == null)
                {
                    _frmEspera = new FrmEspera();
                }
                return _frmEspera;
            }
        }

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

        private Ftp _ftpUpdate;
        public Ftp ftpUpdate
        {
            get
            {
                if (_ftpUpdate == null)
                {
                    _ftpUpdate = new Ftp();
                }
                return _ftpUpdate;
            }
            set { _ftpUpdate = value; }
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

        private List<Arquivo> _lstObjArquivoDependencia;
        public List<Arquivo> lstObjArquivoDependencia
        {
            get
            {
                #region VARIÁVEIS

                Boolean booArquivoExePrincipalAdicionado = false;

                #endregion
                try
                {
                    #region AÇÕES

                    if (_lstObjArquivoDependencia == null)
                    {
                        _lstObjArquivoDependencia = new List<Arquivo>();
                    }

                    for (int intTemp = 0; intTemp < _lstObjArquivoDependencia.Count; intTemp++)
                    {
                        if (_lstObjArquivoDependencia[intTemp].intId == this.objArquivoExePrincipal.intId)
                        {
                            booArquivoExePrincipalAdicionado = true;
                            break;
                        }
                    }

                    if (!booArquivoExePrincipalAdicionado)
                    {
                        _lstObjArquivoDependencia.Insert(0, this.objArquivoExePrincipal);
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _lstObjArquivoDependencia;
            }
        }

        private List<MensagemUsuario> _lstObjMensagemUsuario;
        public List<MensagemUsuario> lstObjMensagemUsuario
        {
            get
            {
                if (_lstObjMensagemUsuario == null)
                {
                    _lstObjMensagemUsuario = new List<MensagemUsuario>();
                }
                return _lstObjMensagemUsuario;
            }
        }

        private List<MensagemUsuario> _lstObjMensagemUsuarioPadrao;
        public List<MensagemUsuario> lstObjMensagemUsuarioPadrao
        {
            get
            {
                if (_lstObjMensagemUsuarioPadrao == null)
                {
                    _lstObjMensagemUsuarioPadrao = new List<MensagemUsuario>();

                    _lstObjMensagemUsuarioPadrao.Add(new MensagemUsuario("Arquivo não existe.", 100));
                }
                return _lstObjMensagemUsuarioPadrao;
            }
        }

        private String[] _lstStrArgumentoEntrada;
        public String[] lstStrArgumentoEntrada
        {
            get { return _lstStrArgumentoEntrada; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _lstStrArgumentoEntrada = value;

                    foreach (var strArgumentoEntrada in _lstStrArgumentoEntrada)
                    {
                        if (strArgumentoEntrada == "Atualizado")
                        {
                            MessageBox.Show("Sistema " + this.strNome + " atualizado com sucesso para versão " + this.getStrVersaoCompleta() + ".");
                        }
                    }


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
        }

        private List<DbTabela> _lstTbl;
        public List<DbTabela> lstTbl { get { return _lstTbl; } set { _lstTbl = value; } }

        private ArquivoExe _objArquivoExePrincipal;
        public ArquivoExe objArquivoExePrincipal
        {
            get
            {
                if (_objArquivoExePrincipal == null)
                {
                    _objArquivoExePrincipal = new ArquivoExe();
                    _objArquivoExePrincipal.booPrincipal = true;
                    _objArquivoExePrincipal.strDescricao = this.strDescricao;
                    _objArquivoExePrincipal.dirCompleto = this.dirExecutavelCompleto;
                }

                return _objArquivoExePrincipal;
            }
        }

        private ArquivoXml _objArquivoXmlConfig;
        public ArquivoXml objArquivoXmlConfig
        {
            get
            {
                if (_objArquivoXmlConfig == null)
                {
                    _objArquivoXmlConfig = new ArquivoXml();
                }
                return _objArquivoXmlConfig;
            }
        }

        private ArquivoXml _objArquivoXmlUpdate;
        private ArquivoXml objArquivoXmlUpdate
        {
            get
            {
                if (_objArquivoXmlUpdate == null)
                {
                    _objArquivoXmlUpdate = new ArquivoXml();
                    _objArquivoXmlUpdate.strNome = this.strNome + "_Update.xml";
                    _objArquivoXmlUpdate.dirCompleto = _objArquivoXmlUpdate.dirTemporarioCompleto;

                    this.ftpUpdate.downloadArquivo(_objArquivoXmlUpdate.strNome, _objArquivoXmlUpdate.dirTemporarioCompleto);
                }

                return _objArquivoXmlUpdate;
            }
        }

        private DataBase.DataBase _objDataBasePrincipal;
        public DataBase.DataBase objDataBasePrincipal { get { return _objDataBasePrincipal; } set { _objDataBasePrincipal = value; } }

        #endregion

        #region CONSTRUTORES

        //public Aplicativo()
        //{
        //    #region VARIÁVEIS

        //    //this.booDesenvolvimentoProducao = booDesenvolvimentoProducao;

        //    #endregion

        //    #region AÇÕES

        //    try
        //    {
        //        this.setInObjArquivoXmlConfig();
        //    }
        //    catch (Exception ex)
        //    {
        //        new Erro("Erro ao criar Arquivo XML de configuração do Aplicativo.", ex, Erro.ErroTipo.Notificao);
        //    }

        //    #endregion
        //}

        public Aplicativo()
        {
            #region VARIÁVEIS

            Aplicativo._appInstancia = this;

            #endregion

            #region AÇÕES

            try
            {
                this.setInObjArquivoXmlConfig();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar Arquivo XML de configuração do Aplicativo.\n" + ex.Message);
            }

            #endregion
        }

        #endregion

        #region DESTRUTOR

        ~Aplicativo()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            try { this.setOutObjArquivoXmlConfig(); }
            catch (Exception ex) { new Erro("Erro ao criar Arquivo XML de configuração do Aplicativo.", ex, Erro.ErroTipo.Notificao); }

            #endregion
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// 
        /// </summary>
        private void abrirAppUpdate(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            Process objProcess;
            Process[] pname;


            #endregion
            try
            {
                #region AÇÕES

                objProcess = new Process();
                objProcess.StartInfo.FileName = "AppUpdate.exe";
                objProcess.StartInfo.Arguments = this.dirExecutavel;
                objProcess.StartInfo.Arguments += " " + this.dirExecutavelCompleto;
                objProcess.StartInfo.CreateNoWindow = true;
                objProcess.Start();

                Thread.Sleep(1500);

                do
                {
                    pname = Process.GetProcessesByName("AppUpdate2");
                } while (pname.Length > 0);

                objProcess = new Process();
                objProcess.StartInfo.FileName = this.dirExecutavelCompleto;
                objProcess.StartInfo.Arguments = "Atualizado";
                objProcess.Start();

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

        /// <summary>
        /// Verifica se há uma nova versão de algum dos arquivos na lista de dependência do aplicativo.
        /// <returns> Retorna false se todos arquivos estiverem atualizados.</returns>
        /// </summary>
        public bool atualizar()
        {
            #region VARIÁVEIS

            Boolean booAplicativoDesatualizado = false;
            Boolean booArquivoAtualizado;

            FrmEspera frmEspera;

            Arquivo objArquivoTemp;
            XmlNodeList objXmlNodeListTemp;

            String strArquivoMd5;
            String strArquivoNome;
            String strArquivoNomeSimplificado;

            #endregion
            try
            {
                #region AÇÕES

                frmEspera = this.mostraFormularioEspera("Verificando se existe uma nova versão no servidor.");

                objXmlNodeListTemp = this.objArquivoXmlUpdate.getXmlNodeList();

                frmEspera.intProgressoMaximo = objXmlNodeListTemp.Count;

                foreach (XmlNode objXmlNode in objXmlNodeListTemp)
                {
                    frmEspera.strTarefaDescricao = "Analisando arquivo \"" + objXmlNode.Name + "\".";

                    booArquivoAtualizado = false;
                    objArquivoTemp = null;

                    strArquivoNomeSimplificado = objXmlNode.Name;
                    strArquivoNome = objXmlNode.ChildNodes.Item(0).InnerText;
                    strArquivoMd5 = objXmlNode.ChildNodes.Item(1).InnerText;

                    foreach (Arquivo objArquivo in this.lstObjArquivoDependencia)
                    {
                        if (objArquivo.strNomeSimplificado == strArquivoNomeSimplificado)
                        {
                            objArquivoTemp = objArquivo;
                            break;
                        }
                    }

                    if (objArquivoTemp != null)
                    {
                        booArquivoAtualizado = objArquivoTemp.strMd5 == strArquivoMd5;
                    }

                    if (!booArquivoAtualizado)
                    {
                        if (objArquivoTemp == null)
                        {
                            objArquivoTemp = new ArquivoDiverso(Arquivo.MimeTipo.TEXT_PLAIN);
                            objArquivoTemp.strNome = strArquivoNome;
                            objArquivoTemp.dir = this.dirExecutavel;
                        }

                        frmEspera.strTarefaDescricao = "Arquivo \"" + objXmlNode.Name + "\" desatualizado. Fazendo download da versão mais atual.";

                        booAplicativoDesatualizado = true;

                        objArquivoTemp.atualizarPeloFtp();

                        frmEspera.strTarefaDescricao = "Arquivo \"" + objXmlNode.Name + "\" desatualizado. Descompactando versão mais atual.";

                        objArquivoTemp.descompactarUpdate();
                    }

                    frmEspera.dblProgresso++;
                }

                frmEspera.strTarefaDescricao = "";
                frmEspera.booConcluido = true;

                if (booAplicativoDesatualizado)
                {
                    MessageBox.Show("Para concluir a atualização o sistema " + this.strNome + " será reiniciado.");
                    this.frmMain.Close();
                    AppDomain.CurrentDomain.ProcessExit += new EventHandler(this.abrirAppUpdate);
                }



                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return booAplicativoDesatualizado;
        }

        /// <summary>
        /// 
        /// </summary>
        public void gerarXmlAtualizacao(String dir)
        {
            #region VARIÁVEIS

            ArquivoXml xml;

            #endregion
            try
            {
                #region AÇÕES

                xml = new ArquivoXml();
                xml.strNome = this.strNome + "_Update.xml";
                xml.dir = dir;

                foreach (Arquivo objArquivoReferencia in this.lstObjArquivoDependencia)
                {
                    xml.setStrElementoConteudo(objArquivoReferencia.strNomeSimplificado, "");
                    xml.addNode("nome", objArquivoReferencia.strNome, objArquivoReferencia.strNomeSimplificado);
                    xml.addNode("md5", objArquivoReferencia.strMd5, objArquivoReferencia.strNomeSimplificado);
                }

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

        /// <summary>
        /// 
        /// </summary>
        public String getStrMensagemUsuario(Int32 intId, DigoFramework.MensagemUsuario.Lingua objLingua = MensagemUsuario.Lingua.Portugues)
        {
            #region VARIÁVEIS

            String strMensagem = "";

            #endregion

            #region AÇÕES

            foreach (MensagemUsuario objMensagem in this.lstObjMensagemUsuario)
            {
                if (objMensagem.intId == intId & objMensagem.objLingua == objLingua)
                {
                    strMensagem = objMensagem.strMensagem;
                }
            }
            return strMensagem;

            #endregion
        }

        public String getStrMensagemUsuarioPadrao(Int32 intId, DigoFramework.MensagemUsuario.Lingua objLingua = MensagemUsuario.Lingua.Portugues)
        {
            #region VARIÁVEIS

            String strMensagemPadrao = "";

            #endregion

            #region AÇÕES

            foreach (MensagemUsuario objMensagemPadrao in this.lstObjMensagemUsuarioPadrao)
            {
                if (objMensagemPadrao.intId == intId & objMensagemPadrao.objLingua == objLingua)
                {
                    strMensagemPadrao = objMensagemPadrao.strMensagem;
                }
            }

            return strMensagemPadrao;

            #endregion
        }

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

        public FrmEspera mostraFormularioEspera(String strTarefaDescricao = "Rotina do sistema {sis_nome} sendo realizada.", String strTarefaTitulo = "Por favor aguarde...")
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            if (strTarefaDescricao == "Rotina do Sistema {sis_nome} sendo realizada...")
            {
                strTarefaDescricao = "Rotina do Sistema " + this.strNome + " sendo realizada...";
            }
            this.frmEspera.strTarefaTitulo = strTarefaTitulo;
            this.frmEspera.strTarefaDescricao = strTarefaDescricao;
            new Thread(() => this.frmEspera.ShowDialog()).Start();
            return this.frmEspera;

            #endregion
        }

        private void setInObjArquivoXmlConfig()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objArquivoXmlConfig.dirCompleto = this.dirExecutavel + "\\AppConfig.xml";
            this.intVersaoBuid = Convert.ToInt32(this.objArquivoXmlConfig.getStrElementoConteudo("VersaoBuid"));

            #endregion
        }

        private void setOutObjArquivoXmlConfig()
        {
            #region VARIÁVEIS

            Int32 intBuidNova = 0;
            Int32 intQtdAcesso = 0;

            #endregion

            #region AÇÕES

            this.objArquivoXmlConfig.setStrElementoConteudo("dttUltimoAcesso", DateTime.Now.ToString());
            intQtdAcesso = Convert.ToInt32(this.objArquivoXmlConfig.getStrElementoConteudo("intQtdAcesso"));
            intQtdAcesso++;
            this.objArquivoXmlConfig.setStrElementoConteudo("intQtdAcesso", intQtdAcesso.ToString());
            if (this.booDesenvolvimentoProducao)
            {
                intBuidNova = Convert.ToInt32(this.objArquivoXmlConfig.getStrElementoConteudo("VersaoBuid"));
                intBuidNova++;
                this.objArquivoXmlConfig.setStrElementoConteudo("VersaoBuid", intBuidNova.ToString());
            }

            #endregion
        }

        #endregion

        #region EVENTOS

        //delegate void nomeAlteradoHandler(object source, EventArgs e);
        //public event nomeAlteradoHandler nomeAlterado;
        //public virtual void onNomeAlteradoHandler(EventArgs e)
        //{
        //    if (nomeAlterado != null)
        //        nomeAlterado(this, e);
        //}

        #endregion
    }
}

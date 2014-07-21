using DigoFramework.arquivo;
using DigoFramework.database;
using DigoFramework.form;
using DigoFramework.objeto;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace DigoFramework
{
    public abstract class Aplicativo : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private static Aplicativo _i;
        private ArquivoExe _arqExePrincipal;
        private ArquivoXml _arqXmlConfig;
        private bool _booAplicativoWeb = false;
        private Boolean _booAtualizado;
        private Boolean _booAtualizarTituloFrmMain = true;
        private Boolean _booBeta = true;
        private Boolean _booDesenvolvimento = true;
        private Boolean _booIniciarComWindows;
        private String _dirExecutavel = Application.StartupPath;
        private FrmEspera _frmEspera;
        private Form _frmPrincipal;
        private Ftp _ftpUpdate;
        private int _intVersaoBuid;
        private List<FrmMain> _lstFrmCache;
        private List<Arquivo> _lstObjArquivoDependencia;
        private List<MensagemUsuario> _lstObjMensagemUsuario;
        private List<MensagemUsuario> _lstObjMensagemUsuarioPadrao;
        private String[] _lstStrArgumentoEntrada;
        private List<DbTabela> _lstTbl;
        private ArquivoXml _objArquivoXmlUpdate;
        private Cliente _objCliente;
        private DataBase _objDataBasePrincipal;
        private Fornecedor _objFornecedor;
        private String _strInput;
        private String _strSiteOficial;

        private DbTabela _tblSelecionada;

        public static Aplicativo i
        {
            get
            {
                return _i;
            }

            private set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    if (_i == null)
                    {
                        _i = value;
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

        public ArquivoExe arqExePrincipal
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    if (_arqExePrincipal == null)
                    {
                        _arqExePrincipal = new ArquivoExe();
                        _arqExePrincipal.booPrincipal = true;
                        _arqExePrincipal.strDescricao = this.strDescricao;
                        _arqExePrincipal.dirCompleto = this.dirExecutavelCompleto;
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

                return _arqExePrincipal;
            }
        }

        public ArquivoXml arqXmlConfig
        {
            get
            {
                if (_arqXmlConfig == null)
                {
                    _arqXmlConfig = new ArquivoXml();
                }
                return _arqXmlConfig;
            }
        }

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

        public Boolean booAtualizado
        {
            get
            {
                #region VARIÁVEIS

                Boolean booArquivoAtualizado;

                Arquivo objArquivoTemp;
                XmlNodeList objXmlNodeListTemp;

                String strArquivoMd5;
                String strArquivoNomeSimplificado;

                #endregion

                try
                {
                    #region AÇÕES

                    _booAtualizado = true;
                    objXmlNodeListTemp = this.objArquivoXmlUpdate.getXmlNodeList();

                    foreach (XmlNode objXmlNode in objXmlNodeListTemp)
                    {
                        booArquivoAtualizado = false;
                        objArquivoTemp = null;
                        strArquivoNomeSimplificado = objXmlNode.Name;
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
                            return false;
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

                return _booAtualizado;
            }
        }

        public Boolean booBeta
        {
            get
            {
                return _booBeta;
            }

            set
            {
                _booBeta = value;
            }
        }

        public Boolean booDesenvolvimento
        {
            get
            {
                return _booDesenvolvimento;
            }

            set
            {
                _booDesenvolvimento = value;
            }
        }

        public Boolean booIniciarComWindows
        {
            get
            {
                return _booIniciarComWindows;
            }

            set
            {
                _booIniciarComWindows = value;

                RegistryKey objRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (_booIniciarComWindows)
                {
                    objRegistryKey.SetValue(this.strNome, this.dirExecutavelCompleto);
                }
                else
                {
                    objRegistryKey.DeleteValue(this.strNome, false);
                }
            }
        }

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

        public String dirExecutavelCompleto
        {
            get
            {
                return Application.ExecutablePath.Replace("EXE", "exe");
            }
        }

        public FrmEspera frmEspera
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

        public Form frmPrincipal
        {
            get
            {
                return _frmPrincipal;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    _frmPrincipal = value;

                    if (this.booAtualizarTituloFrmMain)
                    {
                        _frmPrincipal.Text = this.getStrTituloAplicativo();
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

            set
            {
                _ftpUpdate = value;
            }
        }

        public List<FrmMain> lstFrmCache
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    if (_lstFrmCache == null)
                    {
                        _lstFrmCache = new List<FrmMain>();
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

                return _lstFrmCache;
            }
        }

        public List<Arquivo> lstObjArquivoDependencia
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    if (_lstObjArquivoDependencia == null)
                    {
                        _lstObjArquivoDependencia = new List<Arquivo>();
                        _lstObjArquivoDependencia.Add(this.arqExePrincipal);
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

        public String[] lstStrArgumentoEntrada
        {
            get
            {
                return _lstStrArgumentoEntrada;
            }

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

        public List<DbTabela> lstTbl
        {
            get
            {
                return _lstTbl;
            }

            set
            {
                _lstTbl = value;
            }
        }

        public Cliente objCliente
        {
            get
            {
                return _objCliente;
            }

            set
            {
                _objCliente = value;
            }
        }

        public DataBase objDataBasePrincipal
        {
            get
            {
                return _objDataBasePrincipal;
            }

            set
            {
                _objDataBasePrincipal = value;
            }
        }

        public Fornecedor objFornecedor
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    if (_objFornecedor == null)
                    {
                        _objFornecedor = new Fornecedor();
                        _objFornecedor.strNome = "Digosoftware";
                        _objFornecedor.strDescricao = "Automação e solução para Windows.";
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

                return _objFornecedor;
            }

            set
            {
                _objFornecedor = value;
            }
        }

        public String strInput
        {
            get
            {
                return _strInput;
            }

            set
            {
                _strInput = value;
            }
        }

        public String strSiteOficial
        {
            get
            {
                return _strSiteOficial;
            }

            set
            {
                _strSiteOficial = value;
            }
        }

        public DbTabela tblSelecionada
        {
            get
            {
                return _tblSelecionada;
            }

            set
            {
                _tblSelecionada = value;
            }
        }

        protected Boolean booAtualizarTituloFrmMain
        {
            get
            {
                return _booAtualizarTituloFrmMain;
            }

            set
            {
                _booAtualizarTituloFrmMain = value;
            }
        }

        protected ArquivoXml objArquivoXmlUpdate
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

        private int intVersaoBuid
        {
            get
            {
                return _intVersaoBuid;
            }

            set
            {
                _intVersaoBuid = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        public Aplicativo()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                Aplicativo.i = this;
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

            try
            {
                this.setOutObjArquivoXmlConfig();
            }
            catch (Exception ex)
            {
                new Erro("Erro ao criar Arquivo XML de configuração do Aplicativo.", ex, Erro.ErroTipo.NOTIFICACAO);
            }

            #endregion
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrm(Type clsFrm)
        {
            #region VARIÁVEIS

            DialogResult objDialogResult;

            #endregion

            try
            {
                #region AÇÕES

                FrmMain frm = (FrmMain)Activator.CreateInstance(clsFrm);
                objDialogResult = frm.ShowDialog();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return objDialogResult;
        }

        /// <summary>
        /// Verifica se existe uma instância do "FrmBase" no cache de formulários e o coloca na
        /// tela. Caso não exista, cria uma nova instância do "FrmBase" e o coloca na tela.
        /// </summary>
        public DialogResult abrirFrmCache(Type cls)
        {
            #region VARIÁVEIS

            DialogResult objDialogResultResultado;
            FrmMain frmParaAbrir = null;

            #endregion

            try
            {
                #region AÇÕES

                frmParaAbrir = Aplicativo.i.getFrmBaseCacheInstancia(cls);
                objDialogResultResultado = frmParaAbrir.ShowDialog();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return objDialogResultResultado;
        }

        /// <summary>
        /// Verifica se há uma nova versão de algum dos arquivos na lista de dependência do
        /// aplicativo. <param name="dirLanUpdate">Caso seja diferente de "" o arquivo é baixado por
        /// este endereço na rede interna.</param><param name="dirLanSalvarUpdate">Caso seja
        /// diferente de "" o arquivo é copiado para este endereço na rede interna.</param><returns>
        /// Retorna false se todos arquivos estiverem atualizados.</returns>
        /// </summary>
        public bool atualizar(String dirLanUpdate = Utils.STRING_VAZIA, String dirLanSalvarUpdate = Utils.STRING_VAZIA)
        {
            #region VARIÁVEIS

            Boolean booAplicativoDesatualizado = false;
            Boolean booArquivoAtualizado;

            FrmEspera frmEspera = null;

            Arquivo objArquivoTemp;
            Arquivo objArquivoXmlUpdateLocal;

            XmlNodeList objXmlNodeListTemp;

            String strArquivoMd5;
            String strArquivoNome;
            String strArquivoNomeSimplificado;

            #endregion

            try
            {
                #region AÇÕES

                frmEspera = this.mostrarFormularioEspera("Verificando se existe uma nova versão no servidor.");

                if (!String.IsNullOrEmpty(dirLanSalvarUpdate))
                {
                    this.gerarXmlAtualizacao(dirLanSalvarUpdate);
                }

                if (String.IsNullOrEmpty(dirLanUpdate))
                {
                    objXmlNodeListTemp = this.objArquivoXmlUpdate.getXmlNodeList();
                }
                else
                {
                    objArquivoXmlUpdateLocal = new ArquivoXml();
                    objArquivoXmlUpdateLocal.strNome = this.strNome + "_Update.xml";
                    objXmlNodeListTemp = this.objArquivoXmlUpdate.getXmlNodeList();
                }

                frmEspera.intProgressoMaximo = objXmlNodeListTemp.Count;

                foreach (XmlNode objXmlNode in objXmlNodeListTemp)
                {
                    frmEspera.strTarefaDescricao = "Analisando o arquivo \"" + objXmlNode.Name + "\".";

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

                    if (objArquivoTemp == null)
                    {
                        objArquivoTemp = new ArquivoDiverso(Arquivo.EnmMimeTipo.TEXT_PLAIN);
                        objArquivoTemp.strNome = strArquivoNome;
                        objArquivoTemp.dir = this.dirExecutavel;
                    }

                    booArquivoAtualizado = objArquivoTemp.strMd5 == strArquivoMd5;

                    if (!booArquivoAtualizado)
                    {
                        booAplicativoDesatualizado = true;
                        frmEspera.strTarefaDescricao = "Arquivo \"" + strArquivoNome + "\" desatualizado. Fazendo download da versão mais atual.";

                        if (String.IsNullOrEmpty(dirLanUpdate))
                        {
                            objArquivoTemp.atualizarPeloFtp(dirLanSalvarUpdate);
                        }
                        else
                        {
                            objArquivoTemp.atualizarPorLan(dirLanUpdate);
                        }

                        frmEspera.strTarefaDescricao = "Arquivo \"" + strArquivoNome + "\" desatualizado. Descompactando versão mais atual.";
                        objArquivoTemp.descompactarUpdate();
                    }

                    frmEspera.dblProgresso++;
                }

                frmEspera.booConcluido = true;

                if (booAplicativoDesatualizado)
                {
                    MessageBox.Show("Para concluir a atualização o sistema " + this.strNome + " será reiniciado.");

                    try
                    {
                        this.frmPrincipal.Close();
                    }
                    catch
                    {
                    }

                    AppDomain.CurrentDomain.ProcessExit += new EventHandler(this.abrirAppUpdate);
                }

                #endregion
            }
            catch (Exception ex)
            {
                frmEspera.booConcluido = true;
                throw ex;
            }
            finally
            {
            }

            return booAplicativoDesatualizado;
        }

        /// <summary>
        /// Cria um repositório para atualização automática.
        /// </summary>
        public void gerarRepositorioUpdate(String dirRepositorioUpdate = Utils.STRING_VAZIA)
        {
            #region VARIÁVEIS

            FrmEspera frmEspera = null;

            #endregion

            try
            {
                #region AÇÕES

                frmEspera = this.mostrarFormularioEspera("", "Criando repositório local");
                frmEspera.intProgressoMaximo = this.lstObjArquivoDependencia.Count + 1;

                if (String.IsNullOrEmpty(dirRepositorioUpdate))
                {
                    dirRepositorioUpdate = this.dirExecutavel;
                }

                this.gerarXmlAtualizacao(dirRepositorioUpdate);
                frmEspera.dblProgresso++;

                foreach (Arquivo objArquivo in this.lstObjArquivoDependencia)
                {
                    frmEspera.strTarefaDescricao = "Criando arquivo: " + objArquivo.strNome;
                    objArquivo.compactar(dirRepositorioUpdate);
                    frmEspera.dblProgresso++;
                }

                frmEspera.booConcluido = true;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                frmEspera.booConcluido = true;
            }
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
                    xml.setStrElemento(objArquivoReferencia.strNomeSimplificado, "");
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
            #region VARIÁVEIS

            String strResultado;

            #endregion

            try
            {
                #region AÇÕES

                strResultado = this.arqExePrincipal.getStrVersao();
                strResultado += this.booBeta ? " Beta" : "";

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;
        }

        /// <summary>
        /// Mostra um formulário para inserção de texto simples.
        /// </summary>
        public string input(string strTitulo = "Insira o texto", string strDescricao = "Utilize o campo abaixo para inserção do texto.", string strValorDefault = "")
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion

            #region AÇÕES

            try
            {
                FrmInput.i.strTitulo = strTitulo;
                FrmInput.i.strDescricao = strDescricao;
                FrmInput.i.strValorDefault = strValorDefault;
                FrmInput.i.ShowDialog();

                strResultado = this.strInput;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        /// <summary>
        /// Termina processos que contém em seu nome o parâmetro "strProcessoNome".
        /// </summary>
        public void matarProcesso(string strProcessoNome)
        {
            #region VARIÁVEIS

            Process[] arrObjProcess;

            #endregion

            #region AÇÕES

            try
            {
                arrObjProcess = Process.GetProcessesByName(strProcessoNome);

                foreach (Process process in arrObjProcess)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Termina o processo indicado pelo "pid" passado como parâmetro. Assim como os processos
        /// filhos deste.
        /// </summary>
        public void matarProcesso(int intPid)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                using (var searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + intPid))
                using (ManagementObjectCollection moc = searcher.Get())
                {
                    foreach (ManagementObject mo in moc)
                    {
                        this.matarProcesso(Convert.ToInt32(mo["ProcessID"]));
                    }
                    try
                    {
                        Process proc = Process.GetProcessById(intPid);
                        proc.CloseMainWindow();
                        proc.Kill();
                    }
                    catch (ArgumentException)
                    { /* process already exited */
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        public FrmEspera mostrarFormularioEspera(String strTarefaDescricao = "Rotina do sistema {sis_nome} sendo realizada.", String strTarefaTitulo = "Por favor aguarde...")
        {
            #region VARIÁVEIS

            #endregion

            try
            {
                #region AÇÕES

                if (strTarefaDescricao.Contains("{sis_nome}"))
                {
                    strTarefaDescricao = "Rotina do Sistema " + this.strNome + " sendo realizada...";
                }

                this.frmEspera.strTarefaTitulo = strTarefaTitulo;
                this.frmEspera.strTarefaDescricao = strTarefaDescricao;

                new Thread(() => this.frmEspera.ShowDialog()).Start();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return this.frmEspera;
        }

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
                objProcess.StartInfo.Arguments = this.arqExePrincipal.dirCompleto;
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
        /// Retorna a instância de um formulário do cache de formulários. Caso este formulário não
        /// exista no cache cria uma nova e o retorna.
        /// </summary>
        private FrmMain getFrmBaseCacheInstancia(Type cls)
        {
            #region VARIÁVEIS

            FrmMain frmBaseResultado = null;

            #endregion

            try
            {
                #region AÇÕES

                foreach (FrmMain frm in this.lstFrmCache)
                {
                    if (frm.GetType() == cls)
                    {
                        frmBaseResultado = frm;
                        break;
                    }
                }

                if (frmBaseResultado == null)
                {
                    frmBaseResultado = (FrmMain)Activator.CreateInstance(cls);
                    this.lstFrmCache.Add(frmBaseResultado);
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

            return frmBaseResultado;
        }

        private void setInObjArquivoXmlConfig()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            this.arqXmlConfig.dirCompleto = this.dirExecutavel + "\\AppConfig.xml";
            this.intVersaoBuid = Convert.ToInt32(this.arqXmlConfig.getStrElemento("VersaoBuid"));

            #endregion
        }

        private void setOutObjArquivoXmlConfig()
        {
            #region VARIÁVEIS

            Int32 intBuidNova = 0;
            Int32 intQtdAcesso = 0;

            #endregion

            #region AÇÕES

            try
            {
                this.arqXmlConfig.setStrElemento("dttUltimoAcesso", DateTime.Now.ToString());

                intQtdAcesso = Convert.ToInt32(this.arqXmlConfig.getStrElemento("intQtdAcesso"));
                intQtdAcesso++;

                this.arqXmlConfig.setStrElemento("intQtdAcesso", intQtdAcesso.ToString());

                if (this.booDesenvolvimento)
                {
                    intBuidNova = Convert.ToInt32(this.arqXmlConfig.getStrElemento("VersaoBuid"));
                    intBuidNova++;
                    this.arqXmlConfig.setStrElemento("VersaoBuid", intBuidNova.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
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
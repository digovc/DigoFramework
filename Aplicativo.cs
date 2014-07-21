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
        private string[] _arrStrArgumentoEntrada;
        private bool _booAplicativoWeb;
        private bool _booAtualizado;
        private bool _booAtualizarTituloFrmMain = true;
        private bool _booBeta = true;
        private bool _booDesenvolvimento = true;
        private bool _booIniciarComWindows;
        private string _dirExecutavel;
        private FrmEspera _frmEspera;
        private Form _frmPrincipal;
        private Ftp _ftpUpdate;
        private int _intVersaoBuid;
        private List<FrmMain> _lstFrmCache;
        private List<Arquivo> _lstObjArquivoDependencia;
        private List<MensagemUsuario> _lstObjMensagemUsuario;
        private List<MensagemUsuario> _lstObjMensagemUsuarioPadrao;
        private List<DbTabela> _lstTbl;
        private ArquivoXml _objArquivoXmlUpdate;
        private Cliente _objCliente;
        private DataBase _objDataBasePrincipal;
        private Fornecedor _objFornecedor;
        private string _strInput;
        private string _strSiteOficial;

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

                #region AÇÕES

                try
                {
                    if (_i == null)
                    {
                        _i = value;
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
        }

        public ArquivoExe arqExePrincipal
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_arqExePrincipal != null)
                    {
                        return _arqExePrincipal;
                    }

                    _arqExePrincipal = new ArquivoExe();
                    _arqExePrincipal.booPrincipal = true;
                    _arqExePrincipal.strDescricao = this.strDescricao;
                    _arqExePrincipal.dirCompleto = this.dirExecutavelCompleto;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _arqExePrincipal;
            }
        }

        public ArquivoXml arqXmlConfig
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_arqXmlConfig != null)
                    {
                        return _arqXmlConfig;
                    }

                    _arqXmlConfig = new ArquivoXml();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _arqXmlConfig;
            }
        }

        public string[] arrStrArgumentoEntrada
        {
            get
            {
                return _arrStrArgumentoEntrada;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _arrStrArgumentoEntrada = value;

                    foreach (var strArgumentoEntrada in _arrStrArgumentoEntrada)
                    {
                        if (strArgumentoEntrada == "Atualizado")
                        {
                            MessageBox.Show("Sistema " + this.strNome + " atualizado com sucesso para versão " + this.getStrVersaoCompleta() + ".");
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
        }

        public bool booAplicativoWeb
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (HttpContext.Current == null)
                    {
                        _booAplicativoWeb = false;
                    }
                    else
                    {
                        _booAplicativoWeb = true;
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

                return _booAplicativoWeb;
            }
        }

        public bool booAtualizado
        {
            get
            {
                #region VARIÁVEIS

                bool booArquivoAtualizado;

                Arquivo objArquivoTemp;
                XmlNodeList objXmlNodeListTemp;

                string strArquivoMd5;
                string strArquivoNomeSimplificado;

                #endregion

                #region AÇÕES

                try
                {
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
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _booAtualizado;
            }
        }

        public bool booBeta
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

        public bool booDesenvolvimento
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

        public bool booIniciarComWindows
        {
            get
            {
                return _booIniciarComWindows;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
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
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
            }
        }

        public string dirExecutavel
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (this.booAplicativoWeb)
                    {
                        return HttpContext.Current.Server.MapPath("~/");
                    }

                    if (!string.IsNullOrEmpty(_dirExecutavel))
                    {
                        return _dirExecutavel;
                    }

                    _dirExecutavel = Application.StartupPath;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _dirExecutavel;
            }
        }

        public string dirExecutavelCompleto
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    return Application.ExecutablePath.Replace("EXE", "exe");
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
        }

        public FrmEspera frmEspera
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_frmEspera != null)
                    {
                        return _frmEspera;
                    }

                    _frmEspera = new FrmEspera();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

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

                #region AÇÕES

                try
                {
                    _frmPrincipal = value;

                    if (this.booAtualizarTituloFrmMain)
                    {
                        _frmPrincipal.Text = this.getStrTituloAplicativo();
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
        }

        public Ftp ftpUpdate
        {
            get
            {
                #region VARIÁVEIS

                string strServer;
                string strUser;
                string strPass;

                #endregion

                #region AÇÕES

                try
                {
                    if (_ftpUpdate != null)
                    {
                        return _ftpUpdate;
                    }

                    strServer = this.arqXmlConfig.getStrElemento("ftpUpdate");
                    strUser = this.arqXmlConfig.getStrElemento("strUser");
                    strPass = this.arqXmlConfig.getStrElemento("strPass");

                    _ftpUpdate = new Ftp(strServer, strUser, strPass);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

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

                #region AÇÕES

                try
                {
                    if (_lstFrmCache != null)
                    {
                        return _lstFrmCache;
                    }

                    _lstFrmCache = new List<FrmMain>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstFrmCache;
            }
        }

        public List<Arquivo> lstObjArquivoDependencia
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstObjArquivoDependencia != null)
                    {
                        return _lstObjArquivoDependencia;
                    }

                    _lstObjArquivoDependencia = new List<Arquivo>();
                    _lstObjArquivoDependencia.Add(this.arqExePrincipal);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstObjArquivoDependencia;
            }
        }

        public List<MensagemUsuario> lstObjMensagemUsuario
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstObjMensagemUsuario != null)
                    {
                        return _lstObjMensagemUsuario;
                    }

                    _lstObjMensagemUsuario = new List<MensagemUsuario>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstObjMensagemUsuario;
            }
        }

        public List<MensagemUsuario> lstObjMensagemUsuarioPadrao
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstObjMensagemUsuarioPadrao != null)
                    {
                        return _lstObjMensagemUsuarioPadrao;
                    }

                    _lstObjMensagemUsuarioPadrao = new List<MensagemUsuario>();
                    _lstObjMensagemUsuarioPadrao.Add(new MensagemUsuario("Arquivo não existe.", 100));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstObjMensagemUsuarioPadrao;
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

                #region AÇÕES

                try
                {
                    if (_objFornecedor == null)
                    {
                        _objFornecedor = new Fornecedor();
                        _objFornecedor.strNome = "Digosoftware";
                        _objFornecedor.strDescricao = "Automação e solução para Windows.";
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

                return _objFornecedor;
            }

            set
            {
                _objFornecedor = value;
            }
        }

        public string strInput
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

        public string strSiteOficial
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

        protected bool booAtualizarTituloFrmMain
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
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_objArquivoXmlUpdate != null)
                    {
                        return _objArquivoXmlUpdate;
                    }

                    _objArquivoXmlUpdate = new ArquivoXml();
                    _objArquivoXmlUpdate.strNome = this.strNome + "_Update.xml";
                    _objArquivoXmlUpdate.dirCompleto = _objArquivoXmlUpdate.dirTemporarioCompleto;

                    this.ftpUpdate.downloadArquivo(_objArquivoXmlUpdate.strNome, _objArquivoXmlUpdate.dirTemporarioCompleto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

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
            finally
            {
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
            finally
            {
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

            #region AÇÕES

            try
            {
                FrmMain frm = (FrmMain)Activator.CreateInstance(clsFrm);
                objDialogResult = frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

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

            #region AÇÕES

            try
            {
                frmParaAbrir = Aplicativo.i.getFrmCacheInstancia(cls);
                objDialogResultResultado = frmParaAbrir.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return objDialogResultResultado;
        }

        /// <summary>
        /// Verifica se há uma nova versão de algum dos arquivos na lista de dependência do
        /// aplicativo. <param name="dirLanUpdate">Caso seja diferente de "" o arquivo é baixado por
        /// este endereço na rede interna.</param><param name="dirLanSalvarUpdate">Caso seja
        /// diferente de "" o arquivo é copiado para este endereço na rede interna.</param><returns>
        /// Retorna false se todos arquivos estiverem atualizados.</returns>
        /// </summary>
        public bool atualizar(string dirLanUpdate = Utils.STR_VAZIA, string dirLanSalvarUpdate = Utils.STR_VAZIA)
        {
            #region VARIÁVEIS

            bool booResultado = false;
            bool booArquivoAtualizado;

            FrmEspera frmEspera = null;

            Arquivo objArquivoTemp;
            Arquivo objArquivoXmlUpdateLocal;

            XmlNodeList objXmlNodeListTemp;

            string strArquivoMd5;
            string strArquivoNome;
            string strArquivoNomeSimplificado;

            #endregion

            #region AÇÕES

            try
            {
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
                        booResultado = true;
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

                if (booResultado)
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
            }
            catch (Exception ex)
            {
                frmEspera.booConcluido = true;
                throw ex;
            }
            finally
            {
            }

            #endregion

            return booResultado;
        }

        /// <summary>
        /// Cria um repositório para atualização automática.
        /// </summary>
        public void gerarRepositorioUpdate(string dirRepositorioUpdate = Utils.STR_VAZIA)
        {
            #region VARIÁVEIS

            FrmEspera frmEspera = null;

            #endregion

            #region AÇÕES

            try
            {
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                frmEspera.booConcluido = true;
            }

            #endregion
        }

        /// <summary>
        /// Cria o "xml" para ser utilizado no processo de atualização.
        /// </summary>
        public void gerarXmlAtualizacao(string dir)
        {
            #region VARIÁVEIS

            ArquivoXml xml;

            #endregion

            #region AÇÕES

            try
            {
                xml = new ArquivoXml();
                xml.strNome = this.strNome + "_Update.xml";
                xml.dir = dir;

                foreach (Arquivo objArquivoReferencia in this.lstObjArquivoDependencia)
                {
                    xml.setStrElemento(objArquivoReferencia.strNomeSimplificado, "");
                    xml.addNode("nome", objArquivoReferencia.strNome, objArquivoReferencia.strNomeSimplificado);
                    xml.addNode("md5", objArquivoReferencia.strMd5, objArquivoReferencia.strNomeSimplificado);
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
        /// Retornar uma "string" contendo a mensagem destinada ao usuário.
        /// </summary>
        public string getStrMensagemUsuario(Int32 intId, DigoFramework.MensagemUsuario.Lingua objLingua = MensagemUsuario.Lingua.PORTUGUES)
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion

            #region AÇÕES

            try
            {
                foreach (MensagemUsuario objMensagem in this.lstObjMensagemUsuario)
                {
                    if (objMensagem.intId == intId & objMensagem.objLingua == objLingua)
                    {
                        strResultado = objMensagem.strMensagem;
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

            return strResultado;
        }

        public string getStrMensagemUsuarioPadrao(Int32 intId, DigoFramework.MensagemUsuario.Lingua objLingua = MensagemUsuario.Lingua.PORTUGUES)
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion

            #region AÇÕES

            try
            {
                foreach (MensagemUsuario objMensagemPadrao in this.lstObjMensagemUsuarioPadrao)
                {
                    if (objMensagemPadrao.intId == intId & objMensagemPadrao.objLingua == objLingua)
                    {
                        strResultado = objMensagemPadrao.strMensagem;
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

            return strResultado;
        }

        public string getStrTituloAplicativo()
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion

            #region AÇÕES

            try
            {
                strResultado = "_app_nome - _app_descricao (_app_versao)";
                strResultado = strResultado.Replace("_app_nome", this.strNomeExibicao);
                strResultado = strResultado.Replace("_app_descricao", this.strDescricao);
                strResultado = strResultado.Replace("_app_versao", this.getStrVersaoCompleta());
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

        public string getStrVersaoCompleta()
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                strResultado = this.arqExePrincipal.getStrVersao();
                strResultado += this.booBeta ? " Beta" : "";
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

        public FrmEspera mostrarFormularioEspera(string strTarefaDescricao = "Rotina do sistema {sis_nome} sendo realizada.", string strTarefaTitulo = "Por favor aguarde...")
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                if (strTarefaDescricao.Contains("{sis_nome}"))
                {
                    strTarefaDescricao = "Rotina do Sistema " + this.strNome + " sendo realizada...";
                }

                this.frmEspera.strTarefaTitulo = strTarefaTitulo;
                this.frmEspera.strTarefaDescricao = strTarefaDescricao;

                new Thread(() => this.frmEspera.ShowDialog()).Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return this.frmEspera;
        }

        private void abrirAppUpdate(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            Process objProcess;
            Process[] pname;

            #endregion

            #region AÇÕES

            try
            {
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
        /// Retorna a instância de um formulário do cache de formulários. Caso este formulário não
        /// exista no cache cria uma nova e o retorna.
        /// </summary>
        private FrmMain getFrmCacheInstancia(Type cls)
        {
            #region VARIÁVEIS

            FrmMain frmResultado = null;

            #endregion

            #region AÇÕES

            try
            {
                foreach (FrmMain frm in this.lstFrmCache)
                {
                    if (frm.GetType() == cls)
                    {
                        frmResultado = frm;
                        break;
                    }
                }

                if (frmResultado == null)
                {
                    frmResultado = (FrmMain)Activator.CreateInstance(cls);
                    this.lstFrmCache.Add(frmResultado);
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

            return frmResultado;
        }

        private void setInObjArquivoXmlConfig()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.arqXmlConfig.dirCompleto = this.dirExecutavel + "\\AppConfig.xml";
                this.intVersaoBuid = Convert.ToInt32(this.arqXmlConfig.getStrElemento("VersaoBuid"));
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

        private void setOutObjArquivoXmlConfig()
        {
            #region VARIÁVEIS

            int intBuidNova = 0;
            int intQtdAcesso = 0;

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

        #endregion
    }
}
using System;
using System.Reflection;
using System.Windows.Forms;
using DigoFramework.Anotacao;
using DigoFramework.Arquivo;

namespace DigoFramework
{
    /// <summary>
    /// Classe para abstração do arquivo de configuração da aplicação (AppConfig.xml).
    /// </summary>
    public abstract class ConfigMain : Objeto
    {
        #region Constantes

        private static readonly char[] STR_ARR_SEPARADOR = new char[] { '<', ';', '>' };

        #endregion Constantes

        #region Atributos

        private static ConfigMain _i;

        private ArquivoXml _arqXmlConfig;
        private DateTime _dttAppUltimoAcesso;
        private int _intAppQtdAcesso;
        private int _intAppVersaoBuild;
        private string _strFtpUpdateSenha;
        private string _strFtpUpdateServer;
        private string _strFtpUpdateUser;

        public static ConfigMain i
        {
            get
            {
                return _i;
            }

            private set
            {
                _i = value;
            }
        }

        internal DateTime dttAppUltimoAcesso
        {
            get
            {
                return _dttAppUltimoAcesso;
            }

            set
            {
                _dttAppUltimoAcesso = value;
            }
        }

        internal int intAppQtdAcesso
        {
            get
            {
                return _intAppQtdAcesso;
            }

            set
            {
                _intAppQtdAcesso = value;
            }
        }

        internal int intAppVersaoBuild
        {
            get
            {
                return _intAppVersaoBuild;
            }

            set
            {
                _intAppVersaoBuild = value;
            }
        }

        internal string strFtpUpdateSenha
        {
            get
            {
                return _strFtpUpdateSenha;
            }

            set
            {
                _strFtpUpdateSenha = value;
            }
        }

        internal string strFtpUpdateServer
        {
            get
            {
                return _strFtpUpdateServer;
            }

            set
            {
                _strFtpUpdateServer = value;
            }
        }

        internal string strFtpUpdateUser
        {
            get
            {
                return _strFtpUpdateUser;
            }

            set
            {
                _strFtpUpdateUser = value;
            }
        }

        private ArquivoXml arqXmlConfig
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_arqXmlConfig != null)
                    {
                        return _arqXmlConfig;
                    }

                    _arqXmlConfig = new ArquivoXml();

                    _arqXmlConfig.dirCompleto = this.getDirCompleto();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _arqXmlConfig;
            }
        }

        #endregion Atributos

        #region Construtores

        protected ConfigMain()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                ConfigMain.i = this;

                this.inicializar();
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

        #region Destrutor

        ~ConfigMain()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.dttAppUltimoAcesso = DateTime.Now;
                this.intAppQtdAcesso++;
                this.intAppVersaoBuild = this.getIntAppVersaoBuild();
                this.salvar();
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

        #endregion Destrutor

        #region Métodos

        private void carregarDados()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (PropertyInfo objPropertyInfo in this.GetType().GetProperties())
                {
                    this.carregarDados(objPropertyInfo);
                }
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

        private void carregarDados(PropertyInfo objPropertyInfo)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objPropertyInfo == null)
                {
                    return;
                }

                if (objPropertyInfo.GetCustomAttributes(typeof(AppConfigInvisivel), true).Length > 0)
                {
                    return;
                }

                if (objPropertyInfo.GetSetMethod() == null)
                {
                    return;
                }

                if (typeof(bool).Equals(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getBooElemento(objPropertyInfo.Name, (bool)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(DateTime).Equals(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getDttElemento(objPropertyInfo.Name, (DateTime)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(decimal).Equals(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getDecElemento(objPropertyInfo.Name, (decimal)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(int).Equals(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getIntElemento(objPropertyInfo.Name, (int)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(long).Equals(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getLngElemento(objPropertyInfo.Name, (long)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(string).Equals(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getStrElemento(objPropertyInfo.Name, (string)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(string[]).Equals(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.carregarDadosArrStr(objPropertyInfo), null);
                    return;
                }
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

        private string[] carregarDadosArrStr(PropertyInfo objPropertyInfo)
        {
            #region Variáveis

            string strElementoValor;
            string[] arrStrResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (objPropertyInfo == null)
                {
                    return null;
                }

                strElementoValor = this.arqXmlConfig.getStrElemento(objPropertyInfo.Name, (string)objPropertyInfo.GetValue(this, null));

                if (string.IsNullOrEmpty(strElementoValor))
                {
                    return null;
                }

                arrStrResultado = strElementoValor.Split(ConfigMain.STR_ARR_SEPARADOR);

                return arrStrResultado;
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

        private string getDirCompleto()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (Aplicativo.i == null)
                {
                    return (Application.StartupPath + "\\AppConfig.xml");
                }

                return Aplicativo.i.dirExecutavel + "\\AppConfig.xml";
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

        private int getIntAppVersaoBuild()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (Aplicativo.i == null)
                {
                    return 0;
                }

                return Aplicativo.i.booDesenvolvimento ? this.intAppVersaoBuild++ : this.intAppVersaoBuild;
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

        private void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.carregarDados();
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

        private void salvar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (PropertyInfo objPropertyInfo in this.GetType().GetProperties())
                {
                    if (objPropertyInfo == null)
                    {
                        continue;
                    }

                    this.salvar(objPropertyInfo);
                }
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

        private void salvar(PropertyInfo objPropertyInfo)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objPropertyInfo == null)
                {
                    return;
                }

                if (objPropertyInfo.GetCustomAttributes(typeof(AppConfigInvisivel), true).Length > 0)
                {
                    return;
                }

                if (typeof(bool).Equals(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setBooElemento(objPropertyInfo.Name, (bool)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(DateTime).Equals(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setDttElemento(objPropertyInfo.Name, (DateTime)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(decimal).Equals(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setDecElemento(objPropertyInfo.Name, (decimal)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(int).Equals(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setIntElemento(objPropertyInfo.Name, (int)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(long).Equals(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setLngElemento(objPropertyInfo.Name, (long)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(string).Equals(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setStrElemento(objPropertyInfo.Name, (string)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(string[]).Equals(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setStrElemento(objPropertyInfo.Name, this.salvarArrStr(objPropertyInfo));
                    return;
                }
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

        private string salvarArrStr(PropertyInfo objPropertyInfo)
        {
            #region Variáveis

            string strResultado;
            string[] arrStr;

            #endregion Variáveis

            #region Ações

            try
            {
                if (objPropertyInfo == null)
                {
                    return null;
                }

                if (typeof(string[]).Equals(objPropertyInfo.PropertyType))
                {
                    return null;
                }

                arrStr = (string[])objPropertyInfo.GetValue(this, null);

                strResultado = string.Join(ConfigMain.STR_ARR_SEPARADOR.ToString(), arrStr);

                return strResultado;
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

        #endregion Eventos
    }
}
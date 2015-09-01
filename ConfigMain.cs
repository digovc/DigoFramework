using DigoFramework.Arquivo;
using System;
using System.Reflection;

namespace DigoFramework
{
    public abstract class ConfigMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static ConfigMain _i;
        private ArquivoXml _arqXmlConfig;
        private DateTime _dttAppUltimoAcesso;
        private int _intAppQtdAcesso;
        private int _intAppVersaoBuid;
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

        internal int intAppVersaoBuid
        {
            get
            {
                return _intAppVersaoBuid;
            }

            set
            {
                _intAppVersaoBuid = value;
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

                    _arqXmlConfig.dirCompleto = Aplicativo.i.dirExecutavel + "\\AppConfig.xml";
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
            ConfigMain.i = this;
        }

        #endregion Construtores

        #region DESTRUTOR

        ~ConfigMain()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.dttAppUltimoAcesso = DateTime.Now;
                this.intAppQtdAcesso++;
                this.intAppVersaoBuid = Aplicativo.i.booDesenvolvimento ? this.intAppVersaoBuid++ : this.intAppVersaoBuid;
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

        #endregion DESTRUTOR

        #region Métodos

        /// <summary>
        /// Inicializa os valores da configuração.
        /// </summary>
        public void inicializar()
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

        private void carregarDados()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.carregarDados(this.GetType());
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

        private void carregarDados(Type cls)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (cls == null)
                {
                    return;
                }

                if (cls.BaseType != null)
                {
                    this.carregarDados(cls.BaseType);
                }

                foreach (PropertyInfo objPropertyInfo in cls.GetProperties())
                {
                    if (objPropertyInfo == null)
                    {
                        continue;
                    }

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

                if (typeof(bool).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getBooElemento(objPropertyInfo.Name, (bool)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(DateTime).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getDttElemento(objPropertyInfo.Name, (DateTime)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(decimal).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getDecElemento(objPropertyInfo.Name, (decimal)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(int).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getIntElemento(objPropertyInfo.Name, (int)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(long).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getLngElemento(objPropertyInfo.Name, (long)objPropertyInfo.GetValue(this, null)), null);
                    return;
                }

                if (typeof(string).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    objPropertyInfo.SetValue(this, this.arqXmlConfig.getStrElemento(objPropertyInfo.Name, (string)objPropertyInfo.GetValue(this, null)), null);
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

        private void salvar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.salvar(this.GetType());
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

        private void salvar(Type cls)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (cls == null)
                {
                    return;
                }

                if (cls.BaseType != null)
                {
                    this.salvar(cls.BaseType);
                }

                foreach (PropertyInfo objPropertyInfo in cls.GetProperties())
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

                if (typeof(bool).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setBooElemento(objPropertyInfo.Name, (bool)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(DateTime).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setDttElemento(objPropertyInfo.Name, (DateTime)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(decimal).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setDecElemento(objPropertyInfo.Name, (decimal)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(int).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setIntElemento(objPropertyInfo.Name, (int)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(long).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setLngElemento(objPropertyInfo.Name, (long)objPropertyInfo.GetValue(this, null));
                    return;
                }

                if (typeof(string).IsAssignableFrom(objPropertyInfo.PropertyType))
                {
                    this.arqXmlConfig.setStrElemento(objPropertyInfo.Name, (string)objPropertyInfo.GetValue(this, null));
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
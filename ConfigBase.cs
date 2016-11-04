using System;
using System.IO;
using System.Reflection;
using DigoFramework.Anotacao;
using DigoFramework.Arquivo;

namespace DigoFramework
{
    /// <summary>
    /// Classe para abstração do arquivo de configuração da aplicação (AppConfig.xml).
    /// </summary>
    public abstract class ConfigBase : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static ConfigBase _i;

        private ArquivoXml _arqXmlConfig;
        private DateTime _dttAppUltimoAcesso;
        private int _intAppQtdAcesso;
        private string _strFtpUpdateSenha;
        private string _strFtpUpdateServer;
        private string _strFtpUpdateUser;

        public static ConfigBase i
        {
            get
            {
                return _i;
            }

            private set
            {
                if (_i != null)
                {
                    return;
                }

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
                if (_arqXmlConfig != null)
                {
                    return _arqXmlConfig;
                }

                _arqXmlConfig = this.getArqXmlConfig();

                return _arqXmlConfig;
            }
        }

        private ArquivoXml getArqXmlConfig()
        {
            ArquivoXml arqResultado = new ArquivoXml();

            arqResultado.dirCompleto = this.getDirCompleto();

            return arqResultado;
        }

        #endregion Atributos

        #region Construtores

        protected ConfigBase()
        {
            i = this;

            this.inicializar();
        }

        #endregion Construtores

        #region Destrutor

        ~ConfigBase()
        {
            this.dttAppUltimoAcesso = DateTime.Now;
            this.intAppQtdAcesso++;

            this.salvar();
        }

        #endregion Destrutor

        #region Métodos

        /// <summary>
        /// Carrega os dados que estão presentes no arquivo AppConfig.xml.
        /// </summary>
        public void carregarDados()
        {
            foreach (PropertyInfo objPropertyInfo in this.GetType().GetProperties())
            {
                this.carregarDados(objPropertyInfo);
            }
        }

        public virtual void salvar()
        {
            foreach (PropertyInfo objPropertyInfo in this.GetType().GetProperties())
            {
                this.salvar(objPropertyInfo);
            }
        }

        private void carregarDados(PropertyInfo objPropertyInfo)
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

            if (typeof(float).Equals(objPropertyInfo.PropertyType))
            {
                objPropertyInfo.SetValue(this, this.arqXmlConfig.getFltElemento(objPropertyInfo.Name, (float)objPropertyInfo.GetValue(this, null)), null);
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

        private string[] carregarDadosArrStr(PropertyInfo objPropertyInfo)
        {
            if (objPropertyInfo == null)
            {
                return null;
            }

            string strValorDefault = null;

            if (objPropertyInfo.GetValue(this, null) != null)
            {
                strValorDefault = string.Join(";", objPropertyInfo.GetValue(this, null) as string[]);
            }

            string strElementoValor = this.arqXmlConfig.getStrElemento(objPropertyInfo.Name, strValorDefault);

            if (string.IsNullOrEmpty(strElementoValor))
            {
                return null;
            }

            return strElementoValor.Split(';');
        }

        private string getDirCompleto()
        {
            return (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\AppConfig.xml");
        }

        private void inicializar()
        {
            this.carregarDados();
        }

        private void salvar(PropertyInfo objPropertyInfo)
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

            if (typeof(float).Equals(objPropertyInfo.PropertyType))
            {
                this.arqXmlConfig.setFltElemento(objPropertyInfo.Name, (float)objPropertyInfo.GetValue(this, null));
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

        private string salvarArrStr(PropertyInfo objPropertyInfo)
        {
            if (objPropertyInfo == null)
            {
                return null;
            }

            if (!typeof(string[]).Equals(objPropertyInfo.PropertyType))
            {
                return null;
            }

            string[] arrStr = (string[])objPropertyInfo.GetValue(this, null);

            if (arrStr == null)
            {
                return null;
            }

            string strResultado = string.Join(";", arrStr);

            return strResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
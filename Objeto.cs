using System;
using DigoFramework.Anotacao;
using Newtonsoft.Json;

namespace DigoFramework
{
    public abstract class Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static int _intObjetoIdStatic;

        private int _intObjetoId;
        private string _strDescricao;
        private string _strNome;
        private string _strNomeExibicao;
        private string _strNomeSimplificado;

        [AppConfigInvisivel]
        public int intObjetoId
        {
            get
            {
                if (_intObjetoId > 0)
                {
                    return _intObjetoId;
                }

                _intObjetoId = intObjetoIdStatic++;

                return _intObjetoId;
            }
        }

        [AppConfigInvisivel]
        public string strDescricao
        {
            get
            {
                return _strDescricao;
            }

            set
            {
                _strDescricao = value;
            }
        }

        [AppConfigInvisivel]
        [JsonProperty("_strNome")]
        public string strNome
        {
            get
            {
                return _strNome;
            }

            set
            {
                _strNome = value;
            }
        }

        [AppConfigInvisivel]
        public string strNomeExibicao
        {
            get
            {
                if (!string.IsNullOrEmpty(_strNomeExibicao))
                {
                    return _strNomeExibicao;
                }

                _strNomeExibicao = Utils.getStrPrimeiraMaiuscula(this.strNome);

                return _strNomeExibicao;
            }

            set
            {
                _strNomeExibicao = value;
            }
        }

        [AppConfigInvisivel]
        public string strNomeSimplificado
        {
            get
            {
                if (!string.IsNullOrEmpty(_strNomeSimplificado))
                {
                    return _strNomeSimplificado;
                }

                _strNomeSimplificado = Utils.simplificar(this.strNome);

                return _strNomeSimplificado;
            }
        }

        private static int intObjetoIdStatic
        {
            get
            {
                return _intObjetoIdStatic;
            }

            set
            {
                _intObjetoIdStatic = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Método vazio que não executa nenhuma ação.
        /// </summary>
        public void fazerNada()
        {
            return;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
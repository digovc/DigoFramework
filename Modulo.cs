using DigoFramework.DataBase;
using System;
using System.Collections.Generic;

namespace DigoFramework
{
    public class Modulo : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booVisivel = true;
        private List<DbTabela> _lstObjTabelas;
        private Modulo _objModuloPai;

        public bool booVisivel
        {
            get
            {
                return _booVisivel;
            }

            set
            {
                _booVisivel = value;
            }
        }

        public List<DbTabela> lstObjTabelas
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstObjTabelas != null)
                    {
                        return _lstObjTabelas;
                    }

                    _lstObjTabelas = new List<DbTabela>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstObjTabelas;
            }

            set
            {
                _lstObjTabelas = value;
            }
        }

        public Modulo objModuloPai
        {
            get
            {
                return _objModuloPai;
            }

            set
            {
                _objModuloPai = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public Modulo(string strNome, Modulo mdlPai)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.strNome = strNome;
                this.objModuloPai = mdlPai;
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

        #region Métodos

        #endregion Métodos

        #region Eventos
        #endregion Eventos
    }
}
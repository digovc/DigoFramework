﻿using DigoFramework.DataBase;
using System;
using System.Collections.Generic;

namespace DigoFramework
{
    public class Modulo : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public Modulo(string strNome, Modulo mdlPai)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS

        #region EVENTOS
        #endregion EVENTOS
    }
}
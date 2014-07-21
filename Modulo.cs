﻿using DigoFramework.database;
using System;
using System.Collections.Generic;

namespace DigoFramework
{
    public class Modulo : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Boolean _booVisivel = true;
        private List<DbTabela> _lstObjTabelas = new List<DbTabela>();

        private Modulo _objModuloPai;

        public Boolean booVisivel
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

        #endregion

        #region CONSTRUTORES

        public Modulo()
        {
            // EXTERNOS VARIÁVEIS AÇÕES
        }

        public Modulo(String strNome)
        {
            // EXTERNOS VARIÁVEIS AÇÕES
            this.strNome = strNome;
        }

        public Modulo(String strNome, Modulo mdlPai)
        {
            // EXTERNOS VARIÁVEIS AÇÕES
            this.strNome = strNome;
            this.objModuloPai = mdlPai;
        }

        #endregion

        #region MÉTODOS

        #endregion
    }
}
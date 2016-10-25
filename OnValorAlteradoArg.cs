using System;

namespace DigoFramework
{
    public class OnValorAlteradoArg : EventArgs
    {
        private string _strValor;
        private string _strValorAnterior;

        public string strValor
        {
            get
            {
                return _strValor;
            }

            set
            {
                _strValor = value;
            }
        }

        public string strValorAnterior
        {
            get
            {
                return _strValorAnterior;
            }

            set
            {
                _strValorAnterior = value;
            }
        }
    }
}
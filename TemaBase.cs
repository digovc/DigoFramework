using System.Drawing;
using System.Drawing.Text;

namespace DigoFramework
{
    public abstract class TemaBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Color _corBorda;
        private Color _corFonte;
        private Color _corFonteTema;
        private Color _corFundo;
        private Color _corFundo1;
        private Color _corFundoBorda;
        private Color _corSombra;
        private Color _corTelaFundo;
        private Color _corTema;
        private Font _fntGrande;
        private Font _fntMedio;
        private Font _fntNormal;
        private Icon _icn;
        private Image _imgLogo;
        private Image _imgTema;

        /// <summary>
        /// Cor das bordas dos componentes por cima da cor do tema.
        /// </summary>
        public Color corBorda
        {
            get
            {
                if (_corBorda != default(Color))
                {
                    return _corBorda;
                }

                _corBorda = this.getCorBorda();

                return _corBorda;
            }
        }

        /// <summary>
        /// Cor da fonte dos componentes que contem texto.
        /// </summary>
        public Color corFonte
        {
            get
            {
                if (_corFonte != default(Color))
                {
                    return _corFonte;
                }

                _corFonte = this.getCorFonte();

                return _corFonte;
            }
        }

        /// <summary>
        /// Cor da fonte dos componentes que contem texto e possuem a cor do tema como background-color.
        /// </summary>
        public Color corFonteTema
        {
            get
            {
                if (_corFonteTema != default(Color))
                {
                    return _corFonteTema;
                }

                _corFonteTema = this.getCorFonteTema();

                return _corFonteTema;
            }
        }

        /// <summary>
        /// Cor do fundo em geral.
        /// </summary>
        public Color corFundo
        {
            get
            {
                if (_corFundo != default(Color))
                {
                    return _corFundo;
                }

                _corFundo = this.getCorFundo();

                return _corFundo;
            }
        }

        /// <summary>
        /// Cor do fundo secundário.
        /// </summary>
        public Color corFundo1
        {
            get
            {
                if (_corFundo1 != default(Color))
                {
                    return _corFundo1;
                }

                _corFundo1 = this.getCorFundo1();

                return _corFundo1;
            }
        }

        /// <summary>
        /// Cor das bordas dos componentes por cima da cor fundo.
        /// </summary>
        public Color corFundoBorda
        {
            get
            {
                if (_corFundoBorda != default(Color))
                {
                    return _corFundoBorda;
                }

                _corFundoBorda = this.getCorFundoBorda();

                return _corFundoBorda;
            }
        }

        /// <summary>
        /// Cor das sombras dos componentes.
        /// </summary>
        public Color corSombra
        {
            get
            {
                if (_corSombra != default(Color))
                {
                    return _corSombra;
                }

                _corSombra = this.getCorSombra();

                return _corSombra;
            }
        }

        /// <summary>
        /// Fundo das telas normais de todos os sistemas.
        /// </summary>
        public Color corTelaFundo
        {
            get
            {
                if (_corTelaFundo != default(Color))
                {
                    return _corTelaFundo;
                }

                _corTelaFundo = this.getCorTelaFundo();

                return _corTelaFundo;
            }
        }

        /// <summary>
        /// Cor do tema que cada uma das aplicações terão.
        /// </summary>
        public Color corTema
        {
            get
            {
                if (_corTema != default(Color))
                {
                    return _corTema;
                }

                _corTema = this.getCorTema();

                return _corTema;
            }
        }

        /// <summary>
        /// Fonte que é utilizada em todos os sistemas. Tamanho Grande.
        /// </summary>
        public Font fntGrande
        {
            get
            {
                if (_fntGrande != null)
                {
                    return _fntGrande;
                }

                _fntGrande = this.getFntGrande();

                return _fntGrande;
            }
        }

        /// <summary>
        /// Fonte que é utilizada em todos os sistemas. Tamanho Medio.
        /// </summary>
        public Font fntMedio
        {
            get
            {
                if (_fntMedio != null)
                {
                    return _fntMedio;
                }

                _fntMedio = this.getFntMedio();

                return _fntMedio;
            }
        }

        /// <summary>
        /// Fonte que é utilizada em todos os sistemas. Tamanho normal.
        /// </summary>
        public Font fntNormal
        {
            get
            {
                if (_fntNormal != null)
                {
                    return _fntNormal;
                }

                _fntNormal = this.getFntNormal();

                return _fntNormal;
            }
        }

        /// <summary>
        /// Ícone do sistema.
        /// </summary>
        public Icon icn
        {
            get
            {
                if (_icn != null)
                {
                    return _icn;
                }

                _icn = this.getIcn();

                return _icn;
            }
        }

        /// <summary>
        /// Imagem que representa a logo da aplicação.
        /// </summary>
        public Image imgLogo
        {
            get
            {
                if (_imgLogo != null)
                {
                    return _imgLogo;
                }

                _imgLogo = this.getImgLogo();

                return _imgLogo;
            }
        }

        /// <summary>
        /// Imagem tematizada para cada sistema. Aparece na tela principal e telas de consultas.
        /// </summary>
        public Image imgTema
        {
            get
            {
                if (_imgTema != null)
                {
                    return _imgTema;
                }

                _imgTema = this.getImgTema();

                return _imgTema;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected virtual Color getCorBorda()
        {
            return ColorTranslator.FromHtml("#d0d0d0");
        }

        protected virtual Color getCorFonte()
        {
            return ColorTranslator.FromHtml("#7d7d7d");
        }

        protected virtual Color getCorFonteTema()
        {
            return Color.White;
        }

        protected virtual Color getCorFundo()
        {
            return ColorTranslator.FromHtml("#e3e3e3");
        }

        protected virtual Color getCorFundo1()
        {
            return ColorTranslator.FromHtml("#f2f2f2");
        }

        protected virtual Color getCorSombra()
        {
            return ColorTranslator.FromHtml("#4c4c4c");
        }

        protected virtual Color getCorTelaFundo()
        {
            return ColorTranslator.FromHtml("#f0f0f0");
        }

        protected virtual Color getCorTema()
        {
            return ColorTranslator.FromHtml("#004562");
        }

        protected virtual Icon getIcn()
        {
            return null;
        }

        protected virtual Image getImgLogo()
        {
            return null;
        }

        protected virtual Image getImgTema()
        {
            return null;
        }

        private Color getCorFundoBorda()
        {
            return ColorTranslator.FromHtml("#aaaaaa");
        }

        private Font getFntGrande()
        {
            return new Font("Tahoma", 16);
        }

        private Font getFntMedio()
        {
            return new Font("Tahoma", 12);
        }

        private Font getFntNormal()
        {
            return new Font("Tahoma", 9);
        }

        private PrivateFontCollection getPfc()
        {
            PrivateFontCollection pfcResultado;

            pfcResultado = new PrivateFontCollection();

            pfcResultado.AddFontFile("relatar_hind_medium.ttf");

            return pfcResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
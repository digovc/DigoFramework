using System;

namespace DigoFramework
{
    public static class SistemaOperacional
    {
        #region Constantes

        public enum Windows
        {
            WIN_ME,
            WINT_NT,
            WIN_95,
            WIN_98,
            WIN_98_SE,
            WIN_2000,
            WIN_XP,
            WIN_SERVER_2003,
            WIN_SERVER_2008,
            WIN_SERVER_2012,
            WIN_VISTA,
            WIN_7,
            WIN_8,
            WIN_8_1_BLUE
        }

        #endregion Constantes

        #region Atributos

        private static Windows _enmWindows = Windows.WINT_NT;

        public static Windows enmWindows
        {
            get
            {
                if (!Windows.WINT_NT.Equals(_enmWindows))
                {
                    return _enmWindows;
                }

                if (PlatformID.Win32Windows.Equals(Environment.OSVersion.Platform))
                {
                    switch (Environment.OSVersion.Version.Minor)
                    {
                        case 0:
                            return Windows.WIN_95;

                        case 10:
                            return "2222A".Equals(Environment.OSVersion.Version.Revision.ToString()) ? Windows.WIN_98_SE : Windows.WIN_98;

                        case 90:
                            return Windows.WIN_ME;

                        default:
                            return Windows.WIN_98_SE;
                    }
                }

                if (PlatformID.Win32NT.Equals(Environment.OSVersion.Platform))
                {
                    switch (Environment.OSVersion.Version.Minor)
                    {
                        case 3:
                            return Windows.WINT_NT;

                        case 4:
                            return Windows.WINT_NT;

                        case 5:
                            return 0.Equals(Environment.OSVersion.Version.Minor) ? Windows.WIN_2000 : Windows.WIN_XP;

                        case 6:
                            return 0.Equals(Environment.OSVersion.Version.Minor) ? Windows.WIN_VISTA : Windows.WIN_7;

                        case 7:
                            return Windows.WIN_8;

                        default:
                            return Windows.WIN_7;
                    }
                }

                return Windows.WIN_7;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}
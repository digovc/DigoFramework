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
            WIN_Xp,
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

        public static Windows objWindows
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    OperatingSystem os = Environment.OSVersion;
                    Version vs = os.Version;
                    if (os.Platform == PlatformID.Win32Windows)
                    {
                        //This is a pre-NT version of Windows
                        switch (vs.Minor)
                        {
                            case 0:
                                return Windows.WIN_95;

                            case 10:
                                if (vs.Revision.ToString() == "2222A")
                                    return Windows.WIN_98_SE;
                                else
                                    return Windows.WIN_98;

                            case 90:
                                return Windows.WIN_ME;

                            default:
                                return Windows.WIN_98_SE;
                        }
                    }
                    else if (os.Platform == PlatformID.Win32NT)
                    {
                        switch (vs.Major)
                        {
                            case 3:
                                return Windows.WINT_NT;

                            case 4:
                                return Windows.WINT_NT;

                            case 5:
                                if (vs.Minor == 0)
                                    return Windows.WIN_2000;
                                else
                                    return Windows.WIN_Xp;

                            case 6:
                                if (vs.Minor == 0)
                                    return Windows.WIN_VISTA;
                                else
                                    return Windows.WIN_7;

                            case 7:
                                return Windows.WIN_8;

                            default:
                                return Windows.WIN_7;
                        }
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
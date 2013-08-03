using System;

namespace DigoFramework
{
    public static class SistemaOperacional
    {
        #region CONSTANTES

        public enum Windows
        {
            WinMe,
            WinNt,
            Win95,
            Win98,
            Win98Se,
            Win2000,
            WinXp,
            WinServer2003,
            WinServer2008,
            WinServer2012,
            WinVista,
            Win7,
            Win8,
            Win8_1Blue
        }

        #endregion

        #region ATRIBUTOS

        public static Windows objWindows
        {
            get
            {
                OperatingSystem os = Environment.OSVersion;
                Version vs = os.Version;
                if (os.Platform == PlatformID.Win32Windows)
                {
                    //This is a pre-NT version of Windows
                    switch (vs.Minor)
                    {
                        case 0:
                            return Windows.Win95;
                        case 10:
                            if (vs.Revision.ToString() == "2222A")
                                return Windows.Win98Se;
                            else
                                return Windows.Win98;
                        case 90:
                                return Windows.WinMe;
                        default:
                            return Windows.Win98Se;
                    }
                }
                else if (os.Platform == PlatformID.Win32NT)
                {
                    switch (vs.Major)
                    {
                        case 3:
                                return Windows.WinNt;
                        case 4:
                                return Windows.WinNt;
                        case 5:
                            if (vs.Minor == 0)
                                return Windows.Win2000;
                            else
                                return Windows.WinXp;
                        case 6:
                            if (vs.Minor == 0)
                                return Windows.WinVista;
                            else
                                return Windows.Win7;
                        case 7:
                                return Windows.Win8;
                        default:
                            return Windows.Win7;
                    }
                }
                return Windows.Win7;
            }
        }

        #endregion

        #region CONSTRUTORES
        #endregion

        #region MÉTODOS
        #endregion

        #region EVENTOS
        #endregion
    }
}

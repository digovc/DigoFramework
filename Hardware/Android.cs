using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace DigoFramework.Hardware
{
    public class Android : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Boolean _booConectado = false;
        public Boolean booConectado { get { return _booConectado; } set { _booConectado = value; } }

        private Int32 _intPorta;
        public Int32 intPorta { get { return _intPorta; } set { _intPorta = value; } }

        private String _strServer = String.Empty;
        public String strServer { get { return _strServer; } set { _strServer = value; } }

        private String _strMarca = String.Empty;
        public String strMarca { get { return _strMarca; } set { _strMarca = value; } }

        private String _strModelo = String.Empty;
        public String strModelo { get { return _strModelo; } set { _strModelo = value; } }

        private IPHostEntry _objIpHostEntry = null;
        public IPHostEntry objIpHostEntry { get { return _objIpHostEntry; } set { _objIpHostEntry = value; } }

        private Socket _objSocket = null;
        public Socket objSocket { get { return _objSocket; } set { _objSocket = value; } }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        private Socket conectaSocket()
        {
            // Get host related information.
            this.objIpHostEntry = Dns.GetHostEntry(this.strServer);

            // Loop through the AddressList to obtain the supthis.intPortaed AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (IPAddress address in this.objIpHostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, this.intPorta);
                Socket tempSocket =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    this.objSocket = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return this.objSocket;
        }

        // This method requests the home page content for the specified server.
        public String enviaRecebeString(String strMensagemEnvio)
        {
            strMensagemEnvio = "GET / HTTP/1.1\r\nHost: " + this.strServer +
                "\r\nConnection: Close\r\n\r\n";
            Byte[] bytesSent = Encoding.ASCII.GetBytes(strMensagemEnvio);
            Byte[] bytesReceived = new Byte[256];

            // Create a socket connection with the specified server and port.
            this.objSocket = conectaSocket();

            if (this.objSocket == null)
                return ("Connection failed");

            // Send request to the server.
            this.objSocket.Send(bytesSent, bytesSent.Length, 0);

            // Receive the server home page content.
            int bytes = 0;
            String strPage = "Default HTML page on " + this.strServer + ":\r\n";

            // The following will block until te page is transmitted.
            do
            {
                bytes = this.objSocket.Receive(bytesReceived, bytesReceived.Length, 0);
                strPage = strPage + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            }
            while (bytes > 0);

            return strPage;
        }

        #endregion
    }
}

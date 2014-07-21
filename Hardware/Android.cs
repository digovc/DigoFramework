using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DigoFramework.hardware
{
    public class Android : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Boolean _booConectado = false;
        private Int32 _intPorta;

        private IPHostEntry _objIpHostEntry = null;

        private Socket _objSocket = null;

        private String _strMarca = String.Empty;

        private String _strModelo = String.Empty;

        private String _strServer = String.Empty;

        public Boolean booConectado
        {
            get
            {
                return _booConectado;
            }

            set
            {
                _booConectado = value;
            }
        }

        public Int32 intPorta
        {
            get
            {
                return _intPorta;
            }

            set
            {
                _intPorta = value;
            }
        }

        public IPHostEntry objIpHostEntry
        {
            get
            {
                return _objIpHostEntry;
            }

            set
            {
                _objIpHostEntry = value;
            }
        }

        public Socket objSocket
        {
            get
            {
                return _objSocket;
            }

            set
            {
                _objSocket = value;
            }
        }

        public String strMarca
        {
            get
            {
                return _strMarca;
            }

            set
            {
                _strMarca = value;
            }
        }

        public String strModelo
        {
            get
            {
                return _strModelo;
            }

            set
            {
                _strModelo = value;
            }
        }

        public String strServer
        {
            get
            {
                return _strServer;
            }

            set
            {
                _strServer = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        public String enviaRecebeString(String strMensagemEnvio)
        {
            #region VARIÁVEIS

            Byte[] bytEnvio = Encoding.ASCII.GetBytes(strMensagemEnvio);
            Byte[] bytRecebido = new Byte[256];
            String strMensagem = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            this.objSocket = conectaSocket();
            if (this.objSocket == null)
                return ("Conexão com o Server falhou.");
            this.objSocket.Send(bytEnvio, bytEnvio.Length, 0);
            int intBytes = 0;
            do
            {
                intBytes = this.objSocket.Receive(bytRecebido, bytRecebido.Length, 0);
                strMensagem = strMensagem + Encoding.ASCII.GetString(bytRecebido, 0, intBytes);
            }
            while (intBytes > 0);
            return strMensagem;

            #endregion
        }

        private Socket conectaSocket()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            this.objIpHostEntry = Dns.GetHostEntry(this.strServer);
            foreach (IPAddress objIPAddress in this.objIpHostEntry.AddressList)
            {
                IPEndPoint objIPEndPoint = new IPEndPoint(objIPAddress, this.intPorta);
                this.objSocket = new Socket(objIPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                this.objSocket.Connect(objIPEndPoint);
                if (this.objSocket.Connected)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            return this.objSocket;

            #endregion
        }

        #endregion
    }
}
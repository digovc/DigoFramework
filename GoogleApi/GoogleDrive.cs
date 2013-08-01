using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Services;
using DigoFramework.Arquivos;
using Google.Apis.Authentication;
using System.Net;

namespace DigoFramework.GoogleApi
{
    public class GoogleDrive : Google
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private DriveService _objDriveService;
        public DriveService objDriveService
        {
            get
            {
                if (_objDriveService == null)
                {
                    _objDriveService = this.getService();
                    return _objDriveService;
                }
                else
                {
                    return _objDriveService;
                }
            }
        }

        #endregion

        #region CONSTRUTORES
        #endregion

        #region MÉTODOS

        public File criarPasta(String strPastaNome, String strPastaDescricao)
        {
            #region VARIÁVEIS

            File objGooglePasta = this.getPasta(strPastaNome);

            #endregion

            #region AÇÕES

            if (objGooglePasta == null)
            {
                objGooglePasta.Title = strPastaNome;
                objGooglePasta.Description = strPastaDescricao;
                objGooglePasta.MimeType = Arquivo.getMimeTipo(Arquivo.MimeTipo.APPLICATION_VND_GOOGLE_APPS_FOLDER);
                return this.objDriveService.Files.Insert(objGooglePasta).Execute();
            }
            else
            {
                return objGooglePasta;
            }

            #endregion
        }

        public void deletarArquivo(File objGoogleArquivo)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            try
            {
                this.objDriveService.Files.Delete(objGoogleArquivo.Id).Execute();
            }
            catch (Exception ex)
            {
                new Erro("Erro ao tentar excluir o Arquivo no Gooogle Drive.", ex, Erro.ErroTipo.GoogleApi);
            }

            #endregion
        }

        private System.IO.Stream download(File objGoogleFile)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            if (!String.IsNullOrEmpty(objGoogleFile.DownloadUrl))
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                        new Uri(objGoogleFile.DownloadUrl));
                    //this.objDriveService.Authenticator.ApplyAuthenticationToRequest(request);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return response.GetResponseStream();
                    }
                    else
                    {
                        new Erro("Erro ao fazer download de Arquivo do Google Drive.", new Exception(response.StatusDescription), Erro.ErroTipo.GoogleApi);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    new Erro("Erro ao fazer download de Arquivo do Google Drive.", ex, Erro.ErroTipo.GoogleApi);
                    return null;
                }
            }
            else
            {
                return null;
            }
            #endregion
        }

        public List<File> getListaArquivos(String strPesquisa = Utils.STRING_VAZIA)
        {
            List<File> result = new List<File>();
            FilesResource.ListRequest request = this.objDriveService.Files.List();
            if (!strPesquisa.Equals(Utils.STRING_VAZIA))
            {
                request.Q = "title contains '" + strPesquisa + "'";
            }

            do
            {
                try
                {
                    FileList files = request.Execute();
                    result.AddRange(files.Items);
                    request.PageToken = files.NextPageToken;
                }
                catch (Exception)
                {
                    request.PageToken = null;
                }
            }
            while (!String.IsNullOrEmpty(request.PageToken));
            return result;
        }

        public List<File> getListaPastas()
        {
            #region VARIÁVEIS

            List<File> lstObjGoogleFile = this.getListaArquivos();
            List<File> lstObjGooglePasta = new List<File>();

            #endregion

            #region AÇÕES

            foreach (File objGoogleFile in lstObjGoogleFile)
            {
                if (objGoogleFile.MimeType == Arquivo.getMimeTipo(Arquivo.MimeTipo.APPLICATION_VND_GOOGLE_APPS_FOLDER))
                {
                    lstObjGooglePasta.Add(objGoogleFile);
                }
            }
            return lstObjGooglePasta;

            #endregion
        }

        private DriveService getService()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            X509Certificate2 certificate = new X509Certificate2(this.objContaServico.arqPkcs12.dirDiretorioCompleto, "notasecret", X509KeyStorageFlags.Exportable);
            var provider = new AssertionFlowClient(GoogleAuthenticationServer.Description, certificate)
            {
                ServiceAccountId = this.objContaServico.objEmailConta.strEmailEndereco,
                Scope = "https://www.googleapis.com/auth/drive",
            };
            var auth = new OAuth2Authenticator<AssertionFlowClient>(provider, AssertionFlowClient.GetState);
            return new DriveService((new BaseClientService.Initializer()
                    {
                        Authenticator = auth,
                        ApplicationName = "Drive API Sample",
                    }));

            #endregion
        }

        public void upload(Arquivo objArquivo, File objGooglePastaPai)
        {
            #region VARIÁVEIS

            File objGoogleFile = new File();

            #endregion

            #region AÇÕES

            objGoogleFile.Title = objArquivo.strNome;
            objGoogleFile.Description = objArquivo.strDescricao;
            objGoogleFile.MimeType = objArquivo.strMimeTipo;
            if (!objGooglePastaPai.Equals(null))
            {
                objGoogleFile.Parents = new List<ParentReference>() { new ParentReference() { Id = objGooglePastaPai.Id } };
            }
            byte[] byteArray = System.IO.File.ReadAllBytes(objArquivo.dirDiretorioCompleto);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
            try
            {
                FilesResource.InsertMediaUpload request = this.objDriveService.Files.Insert(objGoogleFile, stream, objArquivo.strMimeTipo);
                request.Upload();
            }
            catch (Exception ex)
            {
                new Erro("Erro ao enviar arquivo para Google Drive.", ex, Erro.ErroTipo.GoogleApi);
            }

            #endregion
        }

        public File getArquivo(String strArquivoNome)
        {
            #region VARIÁVEIS

            List<File> lstObjGooglePasta = this.getListaPastas();

            #endregion

            #region AÇÕES

            foreach (File objGooglePasta in lstObjGooglePasta)
            {
                if (objGooglePasta.Title == strArquivoNome)
                {
                    return objGooglePasta;
                }
            }
            return null;

            #endregion
        }

        public File getPasta(String strPastaNome)
        {
            #region VARIÁVEIS

            List<File> lstObjGooglePasta = this.getListaPastas();

            #endregion

            #region AÇÕES

            foreach (File objGooglePasta in lstObjGooglePasta)
            {
                if (objGooglePasta.Title == strPastaNome)
                {
                    return objGooglePasta;
                }
            }
            return null;

            #endregion
        }

        #endregion

        #region EVENTOS
        #endregion
    }
}

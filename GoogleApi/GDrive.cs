using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using DotNetOpenAuth.OAuth2;

namespace DigoFramework.GoogleApi
{
    public class GoogleDrive
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS
        #endregion

        #region CONSTRUTORES
        #endregion

        #region MÉTODOS

        public void enviarArquivo()
        {
            // Register the authenticator and create the service

            // Register the authenticator.
            FullClientCredentials credentials = ClientCredentials.EnsureFullClientCredentials();
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description)
            {
                ClientIdentifier = credentials.ClientId,
                ClientSecret = credentials.ClientSecret
            };
            var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);

            // Create the service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                Authenticator = auth,
                ApplicationName = "Drive API Sample",
            });

            File body = new File();
            body.Title = "Novo documento";
            body.Description = "Um teste de envio.";
            body.MimeType = "text/plain";

            byte[] byteArray = System.IO.File.ReadAllBytes("document.txt");
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

            FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "text/plain");
            request.Upload();

            File file = request.ResponseBody;
            //Console.WriteLine("File id: " + file.Id);
            //Console.WriteLine("Press Enter to end this process.");
            //Console.ReadLine();
        }

        private IAuthorizationState GetAuthorization(NativeApplicationClient client)
        {
            // novo
            // You should use a more secure way of storing the key here as
            // .NET applications can be disassembled using a reflection tool.
            const string STORAGE = "google.samples.dotnet.drive";
            const string KEY = "y},drdzf11x9;87";

            // Check if there is a cached refresh token available.
            IAuthorizationState state = AuthorizationMgr.GetCachedRefreshToken(STORAGE, KEY);
            if (state != null)
            {
                try
                {
                    client.RefreshToken(state);
                    return state; // Yes - we are done.
                }
                catch (DotNetOpenAuth.Messaging.ProtocolException ex)
                {
                    
                }
            }
            return state; // Yes - we are done.
        }

        #endregion
    }
}
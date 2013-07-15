
namespace DigoFramework.GoogleApi
{
    public class GDrive
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS
        #endregion

        #region CONSTRUTORES
        #endregion

        #region MÉTODOS

        //public void enviarArquivo()
        //{
        //    String CLIENT_ID = "95989392916.apps.googleusercontent.com";
        //    String CLIENT_SECRET = "_xesI03AI9XEN3mjlmkLsvbm";

        //    // Register the authenticator and create the service
        //    var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description, CLIENT_ID, CLIENT_SECRET);
        //    //var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
        //    //var service = new DriveService(new BaseClientService.Initializer()
        //    //{
        //    //    Authenticator = auth
        //    //});
        //    //var service = this.BuildService();

        //    File body = new File();
        //    body.Title = "Novo documento";
        //    body.Description = "Um teste de envio.";
        //    body.MimeType = "text/plain";

        //    byte[] byteArray = System.IO.File.ReadAllBytes("document.txt");
        //    System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

        //    FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "text/plain");
        //    request.Upload();

        //    File file = request.ResponseBody;
        //    //Console.WriteLine("File id: " + file.Id);
        //    //Console.WriteLine("Press Enter to end this process.");
        //    //Console.ReadLine();
        //}

        //private IAuthorizationState GetAuthorization(NativeApplicationClient arg)
        //{
        //    // Get the auth URL:
        //    IAuthorizationState state = new AuthorizationState(new[] { DriveService.Scopes.Drive.GetStringValue() });
        //    state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
        //    Uri authUri = arg.RequestUserAuthorization(state);

        //    // Request authorization from the user (by opening a browser window):
        //    Process.Start(authUri.ToString());
        //    string authCode = "4/rlFdBd6g9YsN8ko46yLOLRJvY7iD.okUDS1DEG4ASshQV0ieZDAq2SaTFfwI";

        //    // Retrieve the access token by using the authorization code:
        //    return arg.ProcessUserAuthorization(authCode, state);
        //}

        //private const string SERVICE_ACCOUNT_EMAIL = "95989392916-92lb83t0f5qj7c4g7jrabvnrecd1ephl@developer.gserviceaccount.com";
        //private const string SERVICE_ACCOUNT_PKCS12_FILE_PATH = @"C:\Google Private Key\8aa820ee869614f4bbfbf1d2accf10362a53b292-privatekey.p12";

        ///// <summary>
        ///// Build a Drive service object authorized with the service account.
        ///// </summary>
        ///// <returns>Drive service object.</returns>
        //public DriveService BuildService()
        //{
        //    X509Certificate2 certificate = new X509Certificate2(SERVICE_ACCOUNT_PKCS12_FILE_PATH, "notasecret",
        //        X509KeyStorageFlags.Exportable);

        //    var provider = new AssertionFlowClient(GoogleAuthenticationServer.Description, certificate)
        //    {
        //        ServiceAccountId = SERVICE_ACCOUNT_EMAIL,
        //        Scope = DriveService.Scopes.Drive.GetStringValue(),
        //    };
        //    var auth = new OAuth2Authenticator<AssertionFlowClient>(provider, AssertionFlowClient.GetState);

        //    return new DriveService((new BaseClientService.Initializer()
        //                    {
        //                        Authenticator = auth,
        //                        ApplicationName = "Drive API Sample",
        //                    }));
        //}

        #endregion
    }
}
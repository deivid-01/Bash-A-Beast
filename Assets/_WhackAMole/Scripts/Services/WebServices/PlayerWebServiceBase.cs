public abstract class PlayerWebServiceBase
{
    protected string URI;
    protected WebServiceHelper _webServiceHelper;

    protected PlayerWebServiceBase(string uri, WebServiceHelper webServiceHelper)
    {
        URI = uri;
        _webServiceHelper = webServiceHelper;
    }
}

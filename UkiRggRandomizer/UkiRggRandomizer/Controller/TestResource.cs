using System.Diagnostics;
using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;

namespace UkiRggRandomizer.Controller;

public class TestResource
{
    [ResourceMethod(RequestMethod.GET, "hello")]
    public string Hello()
    {
        return "Hello!";
    }
}
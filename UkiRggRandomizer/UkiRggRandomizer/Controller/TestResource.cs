using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using UkiRggRandomizer.Service;

namespace UkiRggRandomizer.Controller;

public class TestResource : IResource
{
    private readonly IHelloService _helloService;

    public TestResource(IHelloService helloService)
    {
        _helloService = helloService;
    }

    [ResourceMethod(RequestMethod.GET, "hello")]
    public string Hello()
    {
        return _helloService.Hello();
    }
}
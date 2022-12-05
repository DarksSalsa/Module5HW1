using System;
using System.Threading.Tasks;
using ALevelSample.Services.Abstractions;

namespace ALevelSample;

public class App
{
    private readonly IUserService _userService;
    private readonly IResourceService _resourceService;
    private readonly IAuthentificationService _authentificationService;

    public App(IUserService userService, IResourceService resourceService, IAuthentificationService authentificationService)
    {
        _userService = userService;
        _resourceService = resourceService;
        _authentificationService = authentificationService;
    }

    public async Task Start()
    {
        var user = await _userService.GetUserById(23);
        var userInfo = await _userService.CreateUser("morpheus", "leader");
        var pageOfUsers = await _userService.GetListOfUsersById(23);
        var resultWithDelay = await _userService.GetListOfUsersByIdWithDelay(2, 5);

        var resource = await _resourceService.GetResourceById(2);
        var resourcePage = await _resourceService.GetResourcePage();

        var userPut = await _userService.PutUser(2, "morpheus", "zion resident");
        var userPatch = await _userService.PatchUser(2, "morpheus", "zion leader");

        await _userService.DeleteUser(2);

        var resultRegister = await _authentificationService.Register("eve.holt@reqres.in", "pistol");
        var resultLogin = await _authentificationService.Login("eve.holt@reqres.in", "cityslicka");

        var resultRegisterFailure = await _authentificationService.Register("sydney@fife");
        var resultLoginFailure = await _authentificationService.Login("peter@klaven");
    }
}
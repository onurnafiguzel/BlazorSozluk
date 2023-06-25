using BlazorSozluk.Common.Models.Queries;
using MediatR;

namespace BlazorSozluk.Common.ViewModels.RequestModels;

public class LoginUserCommand : IRequest<LoginUserViewModel>
{
    public string EmailAddress { get; private set; }
    public string Password { get; private set; }

    public LoginUserCommand(string emailAddress, string password)
    {
        EmailAddress = emailAddress;
        Password = password;
    }

    public LoginUserCommand()
    {

    }
}

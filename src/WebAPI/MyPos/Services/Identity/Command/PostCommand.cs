using Identity.API.Model;
using MediatR;

namespace Identity.API.Command
{
    public class PostCommand
    {
        public record PostUserCommand(User User) : IRequest<UserResponse>;
        public record UserResponse(bool isFailure, string ErrorMessage);
    }
}
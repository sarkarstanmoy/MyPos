using Identity.API.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Command
{
    public class PostCommand
    {
        public record PostUserCommand(User User) : IRequest<UserResponse>;
        public record UserResponse(bool isFailure, string ErrorMessage);
    }
}
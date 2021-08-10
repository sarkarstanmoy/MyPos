using Identity.API.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Identity.API.Command.PostCommand;
using static Identity.API.Queries.GetValuesQuery;

namespace Identity.API.Handlers
{
    public class PostUserHandler : IRequestHandler<PostUserCommand, UserResponse>
    {
        private readonly IIdentityRepository _identityRepository;

        public PostUserHandler(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<UserResponse> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _identityRepository.PersistUserAsync(new Model.Credentials()
                {
                    Password = request.User.Password,
                    UserName = request.User.UserName
                });
                return new UserResponse(isFailure: false, ErrorMessage: string.Empty);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                return new UserResponse(isFailure: true, ErrorMessage: dbUpdateConcurrencyException.InnerException.Message);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbUpdateException)
            {
                return new UserResponse(isFailure: true, ErrorMessage: dbUpdateException.InnerException.Message);
            }
        }
    }
}
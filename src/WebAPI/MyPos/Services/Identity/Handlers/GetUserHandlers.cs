using Identity.API.Infrastructure.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using static Identity.API.Queries.GetValuesQuery;

namespace Identity.API.Handlers
{
    public class GetUserHandlers : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        private readonly IIdentityRepository _identityRepository;

        public GetUserHandlers(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var record = await _identityRepository.GetUserAsync(request.User.UserName);
            if (record?.Password == request?.User.Password)
                return new GetUserResponse(isFailure: false, ErrorMessage: string.Empty);
            else
                return new GetUserResponse(isFailure: true, ErrorMessage: "Login Failure");
        }
    }
}
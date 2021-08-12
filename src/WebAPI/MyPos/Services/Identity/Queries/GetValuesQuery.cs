using Identity.API.Model;
using MediatR;

namespace Identity.API.Queries
{
    public class GetValuesQuery
    {
        public record GetUserQuery(User User) : IRequest<GetUserResponse>;
        public record GetUserResponse(bool isFailure, string ErrorMessage);
    }
}
using Microsoft.AspNetCore.Components;
using MyPOS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyPOS.UI.BaseRemoteService.Http
{
    public class UserRepository : BaseHttpRepository, IUserRepository
    {
        public UserRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<LoginResponse> TryLoginAsync(LoginModel loginModel)
        {
            var client = GetClient("LoginAPI");
            var response = await client.PostAsJsonAsync("login", loginModel);
            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }
    }

    public interface IUserRepository
    {
        Task<LoginResponse> TryLoginAsync(LoginModel loginModel);
    }
}
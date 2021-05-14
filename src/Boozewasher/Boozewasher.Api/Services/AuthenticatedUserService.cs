﻿using Boozewasher.Application.Interfaces.Shared;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Boozewasher.Api.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        }

        public string UserId { get; }
        public string Username { get; }
    }
}
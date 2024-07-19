﻿using Facebook.Application.Common.Interfaces.Admin.IService;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Facebook.Infrastructure.Services.Admin;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public string GetCurrentUserRole()
    {
        var roleClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role);
        return roleClaim?.Value ?? string.Empty;
    }

    public string GetCurrentUserId()
    {
        var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
        return userIdClaim?.Value ?? string.Empty;
    }
}

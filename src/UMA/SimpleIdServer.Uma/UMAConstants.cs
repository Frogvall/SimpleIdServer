﻿using SimpleIdServer.OAuth.Domains;
using System;

namespace SimpleIdServer.Uma
{
    public static class UMAConstants
    {
        public const string AuthenticationScheme = "SimpleIdServerUMA";

        public static class EndPoints
        {
            public const string ResourcesAPI = "rreguri";
            public const string PermissionsAPI = "perm";
            public const string RequestsAPI = "reqs";
        }

        public static class StandardUMAScopes
        {
            public static OAuthScope UmaProtection = new OAuthScope
            {
                CreateDateTime = DateTime.UtcNow,
                IsExposedInConfigurationEdp = true,
                Name = "uma_protection",
                UpdateDateTime = DateTime.UtcNow
            };
        }
    }
}
﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Mvc;
using SimpleIdServer.OAuth.Api.Token.Handlers;
using SimpleIdServer.OAuth.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SimpleIdServer.OAuth.Api.Token
{
    public interface ITokenRequestHandler
    {
        Task<IActionResult> Handle(HandlerContext context);
    }

    public class TokenRequestHandler : ITokenRequestHandler
    {
        private readonly IEnumerable<IGrantTypeHandler> _handlers;

        public TokenRequestHandler(IEnumerable<IGrantTypeHandler> handlers)
        {
            _handlers = handlers;
        }

        public Task<IActionResult> Handle(HandlerContext context)
        {
            var handler = _handlers.FirstOrDefault(h => h.GrantType == context.Request.Data.GetGrantType());
            if (handler == null)
            {
                return Task.FromResult(BaseCredentialsHandler.BuildError(HttpStatusCode.BadRequest, ErrorCodes.INVALID_GRANT, ErrorMessages.BAD_GRANT_TYPE));
            }

            return handler.Handle(context);
        }
    }
}
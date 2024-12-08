/**
 * The Request Handler Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Request Handler Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Autofac;
using Common.Contract;

namespace Core.LIB
{
    public class RequestHandlerFactory : IRequestHandlerFactory
    {
        private readonly ILifetimeScope _lifetimeScope;

        public RequestHandlerFactory(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public RequestHandler<TReq, TResp> Create<TReq, TResp>() where TReq : Req, new() where TResp : Resp, new()
        {
            // Hafij: Ninject had this factory feature but not in autofac
            return _lifetimeScope.Resolve<RequestHandler<TReq, TResp>>();
        }

    }
}

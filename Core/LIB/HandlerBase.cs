/**
 * The Request Handler Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Request Handler Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */


using Common.Contract;

namespace Core.LIB
{
    public abstract class HandlerBase
    {
        private readonly IHandlerCaller _handlerCaller;

        protected HandlerBase(IHandlerCaller handlerCaller)
        {
            _handlerCaller = handlerCaller;
        }

        protected TResp Process<TReq, TResp>(TReq req) where TResp : Resp, new() where TReq : Req, new()
        {
            return _handlerCaller.Process<TReq, TResp>(req);
        }

    }
}

/**
 * The Request Handler Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Request Handler Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Common.Contract;

namespace Core.LIB
{
    public abstract class RequestHandler<TReq, TResp> where TReq : Req, new() where TResp : Resp, new()
    {
        private readonly IResponseFactory _responseFactory;

        public RequestHandler(IResponseFactory responseFactory)
        {
            _responseFactory = responseFactory;
        }

        public abstract TResp Process(TReq req);

        public TResp GetFailureResp(string text = "")
        {
            return _responseFactory.GetFailureResp<TResp>(text);
        }

        public TResp GetErrorResp(Exception ex, string text = "")
        {
            return _responseFactory.GetErrorResp<TResp>(ex, text);
        }
    }
}

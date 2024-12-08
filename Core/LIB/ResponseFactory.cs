/**
 * The Request Handler Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Request Handler Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Common.Contract;

namespace Core.LIB
{
    public class ResponseFactory : IResponseFactory
    {
        public TResp GetSuccessResp<TResp>() where TResp : Resp, new()
        {
            return new TResp()
            {
                Success = true
            };
        }

        public TResp GetFailureResp<TResp>(string text = "") where TResp : Resp, new()
        {
            return new TResp()
            {
                Success = false,
                Error = new Error()
                {
                    Text = text
                }
            };
        }

        public TResp GetErrorResp<TResp>(Exception exception, string text = "") where TResp : Resp, new()
        {
            return new TResp()
            {
                Success = false,
                Error = new Error()
                {
                    StackTrace = exception.Message,
                    Text = text == "" ? exception.Message : text
                }
            };
        }

    }
}
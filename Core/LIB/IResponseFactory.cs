/**
 * The Request Handler Library is developed by Mohammad Hafijur Rahman
 * This code is part of the Request Handler Library
 * https://github.com/mail4hafij/dotnetcore-startup-with-efcore
 */

using Common.Contract;

namespace Core.LIB
{
    public interface IResponseFactory
    {
        TResp GetSuccessResp<TResp>() where TResp : Resp, new();
        TResp GetFailureResp<TResp>(string text = "") where TResp : Resp, new();
        TResp GetErrorResp<TResp>(Exception exception, string text = "") where TResp : Resp, new();
    }
}
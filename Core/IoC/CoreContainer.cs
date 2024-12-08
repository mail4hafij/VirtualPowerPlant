using Autofac;
using Common;
using Common.Contract.Messaging;
using Core.Handler;
using Core.LIB;

namespace Core.IoC
{
    public class CoreContainer
    {
        public static void Bind(ContainerBuilder builder)
        {
            // LIB (request handler library)
            builder.RegisterType<ResponseFactory>().As<IResponseFactory>();
            builder.RegisterType<HandlerCaller>().As<IHandlerCaller>();
            builder.RegisterType<RequestHandlerFactory>().As<IRequestHandlerFactory>();

            // VPP service
            builder.RegisterType<VPPService>().As<IVPPService>();

            // All handlers
            builder.RegisterType<TryLoadBalanceHandler>().As<RequestHandler<TryLoadBalanceReq, TryLoadBalanceResp>>();
        }
    }
}

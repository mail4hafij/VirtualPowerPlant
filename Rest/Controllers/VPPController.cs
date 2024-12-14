using Common;
using Common.Contract;
using Common.Contract.Forms;
using Common.Contract.Messaging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Rest.Controllers
{
    // Route for URI versioning
    // [Route("api/v{version:apiVersion}/Vpp/[action]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class VPPController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IVPPService _vppService;
        private readonly IConfiguration _configuration;

        public VPPController(IConfiguration configuration, ILogger<VPPController> logger, IVPPService vppService) 
        {
            _configuration = configuration;
            _logger = logger;
            _vppService = vppService;
        }

        [Route("api/TryLoadBalance")]
        [HttpPost]
        public TryLoadBalanceResp TryLoadBalance([FromBody] TryLoadBalanceForm tryLoadBalanceForm)
        {
            var resp = _vppService.TryLoadBalance(new TryLoadBalanceReq()
            {
                BatteryPoolId = tryLoadBalanceForm.BatteryPoolId,
                Magnitude = tryLoadBalanceForm.Magnitude,
                Method = tryLoadBalanceForm.Method,
            });
            return resp;
        }

        // Example endpoints - 
        // AddBattery to VPP
        // RemoveBattery from VPP
        // GetCurrentPower
    }
}

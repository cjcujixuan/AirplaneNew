using Airplanes.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrossController : ControllerBase
    {
        private readonly ILogger<CrossController> _logger;
        private readonly ICross _cross;
        public CrossController(ILogger<CrossController> logger, ICross cross)
        {
            _logger = logger;
            _cross = cross;
        }
        [HttpGet("AirportForAirplane/{aid}")]
        public async Task<IActionResult> GetAirplaneByAirportId(Guid aid)
        {
            try
            {
                var airplane = await _cross.GetAirportByAirplaneId(aid);
                return Ok(new
                {
                    Success = true,
                    Message = "輸出Airplane的id,name且對應Airport",
                    airplane
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("AirplaneDetailsForAirport/{aid}")]
        public async Task<IActionResult> GetAirplaneDetailsByAirportId(Guid id)
        {
            try
            {
                var airplaneDetails = await _cross.GetAirplaneDetailsByAirportId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定 id 詳細資料成功",
                    Data = airplaneDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("AirportDetailsForAirplane/{pid}")]
        public async Task<IActionResult> GetAirportDetailsByAirplaneId(Guid id)
        {
            try
            {
                var airportDetails = await _cross.GetAirportDetailsByAirplaneId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定 id 詳細資料成功",
                    Data = airportDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}


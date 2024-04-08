using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]

    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IConfiguration _configuration;

        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration/*IHttpClientFactory clientFactory*/ )
        {


            _logger = logger;
            _configuration = configuration;
            /* _httpClientFactory = clientFactory;*/

        }

        /*
                [HttpGet("/mc2")]

                public async Task<ActionResult<string>> sendtToMS2()
                {

                    var HttpClient = _httpClientFactory.CreateClient();

                    HttpClient.BaseAddress = new Uri(_configuration.GetSection("Urls")["MS2"]);

                    var a= await HttpClient.GetAsync("/from1");





                    return await a.Content.ReadAsStringAsync();
                }*/

        [HttpGet("")]

        public Dictionary<string,string> hello()
        {

            var dictionary = new Dictionary<string, string>() {
                {"1 ","first value" },
                {"1", "first value without spaces" },
                {"2 ", "second value with spaces" },
                {"3", "third value without spaces" }
            };

            return dictionary.Where(kvp => !(kvp.Key.EndsWith(' ') && dictionary.ContainsKey(kvp.Key.Trim()))).ToDictionary(kvp => kvp.Key.Trim(),kvp=>kvp.Value);
        }




        [HttpGet("/ok")]

        public string helloo()
        {
            _logger.LogDebug("from ms2");
            return "from ms2 revision";
        }

    }

}
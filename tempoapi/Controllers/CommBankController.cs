using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tempo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommBankController : ControllerBase
{
    private readonly HttpClient _httpClient;
   

    public CommBankController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }
    
    [Route("Recipients")]
    [HttpGet]
    public async Task<IActionResult> GetRecipients()
    {
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("x-v", "1");
        _httpClient.DefaultRequestHeaders.Add("x-min-v", "1");

        var response =
            await _httpClient.GetAsync("https://api.cdr.gov.au/cdr-register/v1/all/data-holders/brands/summary");
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var formattedJson = JToken.Parse(responseBody).ToString(Formatting.Indented);

        return Ok(formattedJson);
    }

    [Route("productdetails")]
    [HttpGet]
    public async Task<IActionResult> GetProductDetails()
    {
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("x-v", "4");
        _httpClient.DefaultRequestHeaders.Add("x-min-v", "1");

        var response =
            await _httpClient.GetAsync(
                "https://api.up.com.au/cds-au/v1/banking/products/up-home");

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var formattedJson = JToken.Parse(responseBody).ToString(Formatting.Indented);

        return Ok(formattedJson);
    }

    [Route("UPBank")]
    [HttpGet]
    public async Task<IActionResult> GetUpBankProducts()
    {
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("x-v", "3");
        _httpClient.DefaultRequestHeaders.Add("x-min-v", "1");

        var response = await _httpClient.GetAsync("https://api.up.com.au/cds-au/v1/banking/products");

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var formattedJson = JToken.Parse(responseBody).ToString(Formatting.Indented);

        return Ok(formattedJson);
    }

    [Route("CBAProducts")]
    [HttpGet]
    public async Task<IActionResult> GetCbaProducts()
    {
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("x-v", "3");
        _httpClient.DefaultRequestHeaders.Add("x-min-v", "1");

        var response = await _httpClient.GetAsync("https://api.commbank.com.au/public/cds-au/v1/banking/products");

        // MjQyNWNkOTYtNDlkMi00YTQwLTliZWEtMTUzOGU0NGNkMzliOmEwMGQwYjEwLTQzMWMtNDBlZS1iNmI4LTNhOTMyMTJmYTYwYw==
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var formattedJson = JToken.Parse(responseBody).ToString(Formatting.Indented);

        return Ok(formattedJson);
    }

    [HttpGet]
    [Route("uris")]
    public async Task<IActionResult> GetUris()
    {
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("x-v", "1");
        _httpClient.DefaultRequestHeaders.Add("x-min-v", "1");

        var response =
            await _httpClient.GetAsync("https://api.cdr.gov.au/cdr-register/v1/banking/data-holders/brands/summary");

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();

        return Ok(responseBody);
    }
}
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Grotem.Box.Exceptions;

namespace Vspt.Box.RefitApiClient;

internal static class ApiClientExceptionFactory
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task<Exception?> MakeException(HttpResponseMessage responseMessage)
    {
        if (responseMessage.IsSuccessStatusCode)
        {
            return null;
        }

        var contentText = await responseMessage.Content.ReadAsStringAsync();
        object? content;
        try
        {
            content = JsonSerializer.Deserialize<object>(contentText, _jsonSerializerOptions);
        }
        catch (JsonException)
        {
            content = contentText;
        }

        return new ApiClientException(content, responseMessage.StatusCode);
    }
}

using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Refit;

namespace Vspt.Box.RefitApiClient;

internal sealed class DefaultHttpContentSerializer : IHttpContentSerializer
{
    // TODO: Add and use common default `JsonSerializerOptions` instance
    private static readonly JsonSerializerOptions _jsonSerializerOptions = MakeDefaultJsonSerializerOptions();

    public DefaultHttpContentSerializer()
    {
    }

    private static JsonSerializerOptions MakeDefaultJsonSerializerOptions()
    {
        // Keeping close to default `SystemTextJsonContentSerializer` as much as possible to minimize regressions
        var jsonSerializerOptions = SystemTextJsonContentSerializer.GetDefaultJsonSerializerOptions();
        jsonSerializerOptions.Converters.RemoveAt(jsonSerializerOptions.Converters
            .Select((converter, index) => new { Converter = converter, Index = index })
            .Single(x => x.Converter is JsonStringEnumConverter)
            .Index
        );
        // TODO: Use https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.makereadonly?view=net-8.0 here
        return jsonSerializerOptions;
    }

    public HttpContent ToHttpContent<T>(T item)
    {
        var content = JsonContent.Create(item, options: _jsonSerializerOptions);
        return content;
    }

    public async Task<T?> FromHttpContentAsync<T>(HttpContent content, CancellationToken cancellationToken = default)
    {
        if (typeof(T) == typeof(FileResult))
        {
            var fileName = TryGetFileName(content);
            var contentStream = await content.ReadAsStreamAsync(cancellationToken);
            var contentType = content.Headers.ContentType?.ToString() ?? MediaTypeNames.Application.Octet;
            var result = new FileStreamResult(contentStream, contentType)
            {
                FileDownloadName = fileName,
            };
            return (T?)(object)result;
        }

        return await content.ReadFromJsonAsync<T>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false);
    }

    private static string? TryGetFileName(HttpContent content)
    {
        // Converting to `Microsoft.Net.Http.Headers.ContentDispositionHeaderValue` from buggier `System.Net.Http.Headers.ContentDispositionHeaderValue`
        var rawContentDisposition = content.Headers.ContentDisposition;
        if (!(rawContentDisposition != null && ContentDispositionHeaderValue.TryParse(rawContentDisposition.ToString(), out var contentDisposition)))
        {
            return null;
        }

        var fileNameStar = contentDisposition.FileNameStar.Value;
        if (fileNameStar != null)
        {
            return fileNameStar;
        }

        var fileName = contentDisposition.FileName.Value;
        if (fileName != null)
        {
            return fileName;
        }

        return null;
    }

    public string? GetFieldNameForProperty(PropertyInfo propertyInfo)
    {
        ArgumentNullException.ThrowIfNull(propertyInfo);

        return propertyInfo.GetCustomAttributes<JsonPropertyNameAttribute>(true).Select(a => a.Name).FirstOrDefault();
    }
}

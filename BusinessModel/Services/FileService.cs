using BusinessModel.Contracts;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace BusinessModel.Services
{
    public class FileServiceOptions
    {
        public string BaseUrl { get; set; }

        public string ApiKey { get; set; }
    }

    public class RemoteFileService : IFileService
    {
        private readonly HttpClient httpClient;

        public RemoteFileService(IOptions<FileServiceOptions> options, HttpClient httpClient)
        {
            if (string.IsNullOrWhiteSpace(options.Value.BaseUrl))
            {
                throw new ArgumentException("No valid BaseUrl configured.");
            }

            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
            this.httpClient.DefaultRequestHeaders.Add("X-API-Key", options.Value.ApiKey);
        }

        public async Task<string> UploadFile(string fileName, Stream stream)
        {
            var content = new StreamContent(stream);
            content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Octet);

            var formContent = new MultipartFormDataContent
            {
                { content, "file", fileName }
            };

            var response = await httpClient.PostAsync("upload", formContent);
            if (response.IsSuccessStatusCode)
            {
                var resourceUrl = await response.Content.ReadAsStringAsync();
                return resourceUrl;
            }
            else
            {
                throw new InvalidOperationException(response.ReasonPhrase);
            }
        }
    }
}

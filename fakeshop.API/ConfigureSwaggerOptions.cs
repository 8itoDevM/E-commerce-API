using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace fakeshop.API {
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions> {
        private readonly IApiVersionDescriptionProvider apiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider) {
            this.apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        public void Configure(string? name, SwaggerGenOptions options) {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options) {
            foreach(var descriptions in apiVersionDescriptionProvider.ApiVersionDescriptions) {
                options.SwaggerDoc(descriptions.GroupName, CreateVersionInfo(descriptions));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription descriptions) {
            var info = new OpenApiInfo {
                Title = "Versioned API",
                Version = descriptions.ApiVersion.ToString()
            };

            return info;
        }
    }
}

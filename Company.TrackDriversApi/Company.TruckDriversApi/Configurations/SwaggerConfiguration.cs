using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Company.TruckDriversApi.Configurations;

public static class SwaggerConfiguration
{
    public static void ConfigureSwagger(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {Title = "Drivers API"});
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
           
            // Enabled OAuth security in Swagger
            c.AddSecurityRequirement(new OpenApiSecurityRequirement() {  
                {  
                    new OpenApiSecurityScheme {  
                        Reference = new OpenApiReference {  
                            Type = ReferenceType.SecurityScheme,  
                            Id = "oauth2"  
                        },  
                        Scheme = "oauth2",  
                        Name = "oauth2",  
                        In = ParameterLocation.Header  
                    },  
                    new List <string> ()  
                }  
            });   
            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Implicit = new OpenApiOAuthFlow()
                    {
                        AuthorizationUrl = new Uri("https://login.microsoftonline.com/common/oauth2/v2.0/authorize"),
                        TokenUrl = new Uri("https://login.microsoftonline.com/common/common/v2.0/token"),
                        Scopes = new Dictionary<string, string>{{"api://772de014-3076-4e6a-a0a3-48d9f0c976f7/Drivers.Read","Drivers.Read"} }
                    }
                }
            });
            
        });
    }
}
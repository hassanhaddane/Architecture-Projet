using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GestionHotel.Apis.Filters
{
	public class SecurityRequirementsOperationFilter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			var hasAuthorizeAttribute = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
				.Union(context.MethodInfo.GetCustomAttributes(true))
				.OfType<AuthorizeAttribute>().Any();

			if (hasAuthorizeAttribute)
			{
				operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
				operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

				operation.Security = new List<OpenApiSecurityRequirement>
			{
				new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							},
							Scheme = "oauth2",
							Name = "Bearer",
							In = ParameterLocation.Header
						},
						new List<string>()
					}
				}
			};
			}
		}
	}
}

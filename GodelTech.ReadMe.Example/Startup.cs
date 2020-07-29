using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using GodelTech.Microservices.Core;
using GodelTech.Microservices.Core.HealthChecks;
using GodelTech.Microservices.Core.Mvc;
using GodelTech.Microservices.EntityFrameworkCore;
using GodelTech.Microservices.Swagger;
using GodelTech.ReadMe.Example.Data;

namespace GodelTech.ReadMe.Example
{
    public class Startup : MicroserviceStartup
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
        }

        protected override IEnumerable<IMicroserviceInitializer> CreateInitializers()
        {
            yield return new DeveloperExceptionPageInitializer(Configuration);
            yield return new HttpsInitializer(Configuration);

            yield return new GenericInitializer((app, env) => app.UseRouting());

            yield return new HealthCheckInitializer(Configuration);
            yield return new ApiInitializer(Configuration);

            yield return new SwaggerInitializer(Configuration);

            yield return new EntityFrameworkInitializer<WeatherForecastDbContext>(Configuration);
        }
    }
}

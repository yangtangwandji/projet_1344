using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Projet.ExtensionMethods
{
    public class SecurityMethods
    {

        #region Public Methods

        public static void AddJwtAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false,
                };
            });
        }

        //public static void AddCore(IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddScoped<ISelfiesRepository, DefaultSelfieRepository>();
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("DEFAULT_POLICY", builder =>
        //        {
        //            builder.AllowAnyOrigin()
        //                   .AllowAnyHeader()
        //                   .AllowAnyMethod();
        //        });
        //    });

        //}

        #endregion


    }
}

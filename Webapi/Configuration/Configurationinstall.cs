using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Webapi.Authenticate;
using WebDataModel.ViewModel;
using WebEntryModel;
using WebHelper;
using WebRepository.Implement;
using WebRepository.Interface;
using WebService.Implement;
using WebService.Interface;

namespace Webapi.Configuration
{
    public static class Configurationinstall
    {
        public static IServiceCollection GetDbContext(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<AppDatabase>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("QLBHDatabase"));
            });

            services.AddTransient<IAuthenticate, Authenticates>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            return services;
        }
        public static IServiceCollection GetRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILoaiSachRepository, LoaiSachRepository>();
            services.AddTransient<INhaXuatBanRepository, NhaXuatBanRepository>();
            services.AddTransient<IDocGiaRepository, DocGiaRepository>();
            services.AddTransient<ISachRepository, SachRepository>();

            return services;
        }
        public static IServiceCollection GetServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFileServer, FileServer>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<ILoaiSachService, LoaiSachService>();
            services.AddTransient<INhaXuatBanService, NhaXuatBanService>();
            services.AddTransient<IDocGiaService, DocGiaService>();
            services.AddTransient<ISachService, SachService>();

            return services;
        }
        public static IServiceCollection Authentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });
            services.AddAuthorization();

            return services;
        }
    }
}
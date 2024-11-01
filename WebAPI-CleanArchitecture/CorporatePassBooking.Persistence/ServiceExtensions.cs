using CorporatePassBooking.Application.Repository;
using CorporatePassBooking.Persistence.Context;
using CorporatePassBooking.Persistence.Repository;
using CorporatePassBooking.Persistence.Repository.Visitor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CorporatePassBooking.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("CorporatePassBookingContext");
            services.AddDbContext<CorporatePassBookingContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IVisitorRepository, VisitorRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
        }
    }
}

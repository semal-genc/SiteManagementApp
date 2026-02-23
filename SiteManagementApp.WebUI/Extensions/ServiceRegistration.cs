using SiteManagementApp.Business.Abstract;
using SiteManagementApp.Business.Concrete;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.DataAccess.Concrete;

namespace SiteManagementApp.WebUI.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IApartmentService, ApartmentManager>();
            services.AddScoped<IInvoiceService, InvoiceManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IUserService, UserManager>();

            return services;
        }

        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

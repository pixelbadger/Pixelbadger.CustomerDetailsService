using AutoMapper;
using CustomerDetailsService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pixelbadger.CustomerDetailsService.Core.Commands;
using Pixelbadger.CustomerDetailsService.Core.Dtos;
using Pixelbadger.CustomerDetailsService.Core.Model;
using Pixelbadger.CustomerDetailsService.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixelbadger.CustomerDetailsService.Core.Util
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomerDetailsService(this IServiceCollection services, CustomerDetailsServiceConfiguration config)
        {
            services.AddDbContext<CustomerDetailsContext>(options => options.UseSqlServer(config.DbConnectionString));
            services.AddScoped<ICustomerDetailsCommandHandler, CustomerDetailsCommandHandler>();
            services.AddScoped<ICustomerDetailsRepository, EfCoreCustomerDetailsRepository>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CustomerDetails, CustomerDetailsResponseDto>();
                c.CreateMap<CreateOrUpdateCustomerDetailsDto, CustomerDetails>();
                c.CreateMap<CreateOrUpdateCustomerAddressDto, Address>();
                c.CreateMap<Address, AddressResponseDto>();
            });

            services.AddSingleton(s => mapperConfig.CreateMapper());
            return services;
        }
    }
}

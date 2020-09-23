using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PerfumeSale.BLL.Abstract;
using PerfumeSale.BLL.Concrete.EntityFrameworkCore;
using PerfumeSale.BLL.ValidationRules.FluentValidation;
using PerfumeSale.Core.Abstract;
using PerfumeSale.Core.Concrete.EntityFrameworkCore.Repositories;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.BLL.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));
            services.AddTransient<IBrandRepository, EfBrandRepository>();
            services.AddTransient<IOrderRepository, EfOrderRepository>();
            services.AddTransient<IOrderDetailRepository, EfOrderDetailRepository>();
            services.AddTransient<IPerfumeRepository, EfPerfumeRepository>();
            services.AddTransient<IUserDetailRepository, EfUserDetailRepository>();

            services.AddTransient<IBrandService, EfBrandService>();
            services.AddTransient<IOrderService, EfOrderService>();
            services.AddTransient<IOrderDetailService, EfOrderDetailService>();
            services.AddTransient<IPerfumeService, EfPerfumeService>();
            services.AddTransient<IUserDetailService, EfUserDetailService>();
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<Brand>, BrandValidator>();
            services.AddTransient<IValidator<Order>, OrderValidator>();
            services.AddTransient<IValidator<Perfume>, PerfumeValidator>();
            services.AddTransient<IValidator<OrderDetail>, OrderDetailValidator>();
            services.AddTransient<IValidator<UserDetail>, UserDetailValidator>();
        }
    }
}

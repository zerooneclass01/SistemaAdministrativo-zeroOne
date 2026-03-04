using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Data;
using Repositorio.IRepository.IRepositoryBase;
using Repositorio.Repository;
using Services.Services;

namespace Infra.Ioc
{
    public static class DependencyInjection
    {
        public static void BancoDados(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<Contexto>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DataBase"),
                    x => x.MigrationsAssembly(typeof(Contexto).Assembly.GetName().Name)));
        }
        public static void InjeicaoDeIdependenciaRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var asemblyRepository = typeof(UsuarioRepository).Assembly;

            var repositorios = asemblyRepository.GetTypes()
                .Where(r => r.IsClass && !r.IsAbstract && r.Name.EndsWith("Repository"));

            foreach (var repository in repositorios)
            {

                var interfaceType = repository.GetInterfaces()
                    .FirstOrDefault(i => i.Name == $"I{repository.Name}");

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, repository);
                }
            }

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void InjeicaoDeIdependenciaServices(this IServiceCollection services, IConfiguration configuration)
        {
            var asemblyRepository = typeof(UsuarioServices).Assembly;

            var servicos = asemblyRepository.GetTypes().
                Where(s => s.IsClass && !s.IsAbstract && s.Name.EndsWith("Services"));

            foreach (var servico in servicos)
            {
                var interfaceType = servico.GetInterfaces().FirstOrDefault(i => i.Name == $"I{servico.Name}");

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, servico);
                }
            }

            services.AddScoped<Services.Services.Auth.AuthService>();
            services.AddScoped<Services.Services.Auth.GerarToken>();
        }
    }
}

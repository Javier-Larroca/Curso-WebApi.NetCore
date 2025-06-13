using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Api.Servicios
{
    public interface IServicioScoped
    {
        void DoWork();
    }

    public class ServicioScoped : IServicioScoped
    {
        private readonly ILogger<ServicioScoped> logger;

        public Guid Id { get; set; }

        public ServicioScoped(ILogger<ServicioScoped> logger)
        {
            this.logger = logger;
            Id = Guid.NewGuid();
            logger.LogInformation($"Iniciando el servicio scoped {Id}");
        }

        public void DoWork()
        {
            logger.LogInformation($"Escribiendo desde el Scoped {Id}");
        }
    }
}

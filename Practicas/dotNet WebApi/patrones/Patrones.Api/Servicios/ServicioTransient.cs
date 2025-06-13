using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Api.Servicios
{
    public interface IServicioTransient
    {
        void DoWork();
    }

    public class ServicioTransient : IServicioTransient
    {
        private readonly ILogger<ServicioTransient> logger;

        public Guid Id { get; set; }

        public ServicioTransient(ILogger<ServicioTransient> logger, IServicioSingleton singleton)
        {
            this.logger = logger;
            Id = Guid.NewGuid();
            logger.LogInformation($"Iniciando el servicio transient {Id}");
        }

        public void DoWork()
        {
            logger.LogInformation($"Escribiendo desde el Transient {Id}");
        }
    }
}

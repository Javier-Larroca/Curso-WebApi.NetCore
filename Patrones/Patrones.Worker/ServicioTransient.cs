using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Worker
{
    public interface IServicioTransient
    {
        void DoWork();
    }

    public class ServicioTransient : IServicioTransient
    {
        private readonly ILogger<ServicioTransient> logger;

        public Guid Id { get; set; }

        public ServicioTransient(ILogger<ServicioTransient> logger)
        {
            this.logger = logger;
            Id = Guid.NewGuid();
        }

        public void DoWork()
        {
            logger.LogInformation($"Escribiendo desde el Transient {Id}");
        }
    }
}

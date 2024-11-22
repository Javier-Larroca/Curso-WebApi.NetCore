using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Worker
{
    public interface IServicioSingleton
    {
        void DoWork();
    }

    public class ServicioSingleton : IServicioSingleton
    {
        private readonly ILogger<ServicioSingleton> logger;
        public Guid Id { get; set; }

        public ServicioSingleton(ILogger<ServicioSingleton> logger)
        {
            this.logger = logger;
            Id = Guid.NewGuid();
        }

        public void DoWork()
        {
            logger.LogInformation($"Escribiendo desde el Singleton {Id}");
        }
    }
}

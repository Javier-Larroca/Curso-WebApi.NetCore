﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones.Api.Services
{
    public interface IServicioTransient
    {
        void DoWork();
    }

    public class ServicioTransient : IServicioTransient
    {
        private readonly ILogger<ServicioTransient> logger;

        public Guid Id { get; set; }

        public ServicioTransient(ILogger<ServicioTransient> logger, IServicioScoped scoped)
        {
            this.logger = logger;
            Id = Guid.NewGuid();
            logger.LogInformation($"Iniciando el servicio Transient {Id}");

        }

        public void DoWork()
        {
            logger.LogInformation($"Escribiendo desde el Transient {Id}");
        }
    }
}

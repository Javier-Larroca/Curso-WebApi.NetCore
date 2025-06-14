﻿using System.Runtime.CompilerServices;
using Patrones.Consola;

// var x = Singleton.GetInstance();

// var y = Singleton.GetInstance();

// Console.WriteLine(x == y);

// var pcGamer = new Computadora(
//     new CPUI7(),
//     [new MouseG5(), new TecladoKorsair()],
//     new PlacaDeVideo4080());

// var pcOficina = new Computadora(
//     new CPUI5(),
//     [new MouseOficina(), new TecladoOficina(), new AuricularesOficina()]);

var PCgARMER = new Builder()
    .AddCpu(new CPUI7())
    .AddPlacaDeVideo(new PlacaDeVideo4080())
    .AddPeriferico(new MouseG5())
    .AddPeriferico(new TecladoKorsair())
    .Build();

var miPCBuilder = new Builder();

Console.WriteLine("¿Que CPU queres?");
var respuesta = Console.ReadLine();
switch (respuesta)
{
    case "I7":
        miPCBuilder.AddCpu(new CPUI7());
        break;
    case "I5":
        miPCBuilder.AddCpu(new CPUI5());
        break;
    default:
        throw new Exception(respuesta);
}
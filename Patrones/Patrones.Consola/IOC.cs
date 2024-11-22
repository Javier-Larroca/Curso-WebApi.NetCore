using System;

namespace Patrones.Consola;

public class Computadora
{
    public ICPU CPU {get;set;}
    public List<IPeriferico> Perifericos {get;set;}
    public IPlacaDeVideo? PDV {get;set;}
    
    public Computadora(ICPU cpu, List<IPeriferico> perifericos, IPlacaDeVideo? placaDeVideo)
    {
        CPU = cpu;
        CPU.Encender();
        Console.WriteLine("Detectando placa de video");
        if(placaDeVideo!=null)
        {
            PDV = placaDeVideo;
            PDV.Iniciar();
        }
        Console.WriteLine("Detectando perifericos");
        Perifericos = [];
        foreach(var periferico in perifericos)
        {
            Perifericos.Add(periferico);
            periferico.Conectar();
        }
    }

        public Computadora(ICPU cpu, List<IPeriferico> perifericos)
    {
        CPU = cpu;
        CPU.Encender();
        Console.WriteLine("Detectando perifericos");
        Perifericos = [];
        foreach(var periferico in perifericos)
        {
            Perifericos.Add(periferico);
            periferico.Conectar();
        }
    }
}

public interface ICPU 
{
    public void Encender();
}

public class CPUI7 : ICPU
{
    public void Encender()
    {
        Console.WriteLine("Iniciando CPU Intel I7");
    }
}

public class CPUI5 : ICPU
{
    public void Encender()
    {
        Console.WriteLine("Iniciando CPU Intel I5");
    }
}

public interface IPlacaDeVideo
{
   public void Iniciar(); 
}

public class PlacaDeVideo4080 : IPlacaDeVideo
{
    public void Iniciar()
    {
        Console.WriteLine("Iniciando Placa de video Nvidia 480");
    }
}

public interface IPeriferico
{
    public void Conectar();
}

public class MouseG5 : IPeriferico
{
    public void Conectar()
    {
        Console.WriteLine("Iniciando mouse Logitech G5");
    }
}

public class MouseOficina : IPeriferico
{
    public void Conectar()
    {
        Console.WriteLine("Iniciando mouse Logitech Oficina");
    }
}

public class TecladoKumara : IPeriferico
{
    public void Conectar()
    {
        Console.WriteLine("Iniciando teclado Kumara K522");
    }
}

public class TecladoOficina : IPeriferico
{
    public void Conectar()
    {
        Console.WriteLine("Iniciando teclado de Oficina");
    }
}

public class AuricularesOficina : IPeriferico
{
    public void Conectar()
    {
        Console.WriteLine("Iniciando auriculares de Oficina");
    }
}
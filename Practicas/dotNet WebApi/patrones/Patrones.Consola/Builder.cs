using System;

namespace Patrones.Consola;

public class Builder
{
    private ICPU cPU;
    private IPlacaDeVideo placaDeVideo;
    private List<IPeriferico> perifericos;
    public Builder()
    {
        perifericos = [];
    }

    public Builder AddCpu(ICPU cpu)
    {
        cPU = cpu;
        return this;
    }

    public Builder AddPlacaDeVideo(IPlacaDeVideo video)
    {
        placaDeVideo = video;
        return this;
    }

    public Builder AddPeriferico(IPeriferico periferico)
    {
        perifericos.Add(periferico);
        return this;
    }

    public Computadora Build()
    {
        if (cPU == null)
        {
            throw new Exception("No puedo construir una pc sin CPU");
        }
        return new Computadora(cPU, perifericos, placaDeVideo);
    }
}
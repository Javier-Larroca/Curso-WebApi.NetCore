using System;

namespace Patrones.Consola;

public class Singleton
{
    private static Singleton _instance;// = new Singletone();
    private Singleton()
    {

    }

    public static Singleton GetInstance()
    {
        if(_instance == null)
        {
            _instance = new Singleton();
        }

        return _instance;
    }
}

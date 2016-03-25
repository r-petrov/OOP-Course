namespace FarmersCreed
{
    using System;
    using Simulator;

    class FarmersCreedMain
    {
        static void Main()
        {
            FarmSimulator simulator = new ExtendedFarmSimulator();
            simulator.Run();
        }
    }
}

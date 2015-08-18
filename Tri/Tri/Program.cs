using System;

namespace Tri
{
    class Program
    {
        static void Main(string[] args)
        {
            KattisSolver kattisSolver = new KattisSolver(Console.OpenStandardInput(), Console.OpenStandardOutput());
            kattisSolver.SolveOnStreams();
        }
    }
}

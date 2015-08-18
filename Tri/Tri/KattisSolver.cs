using System.IO;
using Kattis.IO;

namespace Tri
{
    public class KattisSolver
    {
        private readonly Scanner _scanner;
        private readonly StreamWriter _writer;
        private readonly Solver _solver;

        public KattisSolver(Stream inStream, Stream outStream)
        {
            _scanner = new Scanner(inStream);
            _writer = new StreamWriter(outStream);
            _solver = new Solver();
        }

        public void SolveOnStreams()
        {
            while (_scanner.HasNext())
            {
                var a = _scanner.NextInt();
                var b = _scanner.NextInt();
                var c = _scanner.NextInt();

                var solution = _solver.Solve(a, b, c);

                _writer.WriteLine(solution);
            }
            _writer.Flush();
        }
    }
}
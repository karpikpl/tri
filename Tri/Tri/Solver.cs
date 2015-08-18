using System;
using System.Collections.Generic;

namespace Tri
{
    public class Solver
    {
        private readonly Dictionary<string, Func<int, int, int, bool>> _operationsDictionary = new Dictionary
            <string, Func<int, int, int, bool>>
        {
            {"*", (a, b, c) => a*b==c},
            {"+", (a, b, c) => a+b==c},
            {"-", (a, b, c) => a-b==c},
            {"/", (a, b, c) => a/b==c}
        };

        public string Solve(int a, int b, int c)
        {
            // first front to back -> a (op) b = c
            foreach (var operation in _operationsDictionary)
            {
                if (operation.Value(a, b, c))
                    return string.Format("{0}{1}{2}={3}", a, operation.Key, b, c);
            }

            // second back to front -> a = b (op) c
            foreach (var operation in _operationsDictionary)
            {
                if (operation.Value(b, c, a))
                    return string.Format("{0}={1}{2}{3}", a, b, operation.Key, c);
            }

            throw new InvalidOperationException("Solution not found!");
        }

    }
}
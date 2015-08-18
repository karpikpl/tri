using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace Tri
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Solver_Should_ReturnASolution()
        {
            // Arrange
            var solver = new Solver();

            // Act
            string result = solver.Solve(5, 3, 8);

            // Assert
            Assert.That(result, Is.EqualTo("5+3=8"));
        }

        [Test]
        public void Solver_Should_ReturnASolution2()
        {
            // Arrange
            var solver = new Solver();

            // Act
            string result = solver.Solve(5, 15, 3);

            // Assert
            Assert.That(result, Is.EqualTo("5=15/3"));
        }

        [Test]
        public void KattisSolver_Should_WorkOnStreams()
        {
            // Arrange
            const string data = "5 3 8";
            string result;

            using (var helper = new StreamHelper(data))
            {
                // Act
                var kattisSolver = new KattisSolver(helper.InStream, helper.OutStream);
                kattisSolver.SolveOnStreams();
                result = helper.ReadOut();
            }

            // Assert
            Assert.That(result, Is.EqualTo("5+3=8\r\n"));
        }

        [Test]
        public void KattisSolver_Should_WorkOnMultipleLinesOfInput()
        {
            // Arrange
            string result;

            using (var helper = new StreamHelper("5 3 8", "10 5 2", "5 15 3"))
            {
                // Act
                var kattisSolver = new KattisSolver(helper.InStream, helper.OutStream);
                kattisSolver.SolveOnStreams();
                result = helper.ReadOut();
            }

            // Assert
            Assert.That(result, Is.EqualTo("5+3=8\r\n10/5=2\r\n5=15/3\r\n"));
        }

        public class StreamHelper : IDisposable
        {
            public MemoryStream OutStream { get; private set; }
            public MemoryStream InStream { get; private set; }

            public StreamHelper(params string[] testData)
            {
                InStream = new MemoryStream();
                OutStream = new MemoryStream();
                var writer = new StreamWriter(InStream);

                foreach (var test in testData)
                {
                    writer.WriteLine(test);
                }
                writer.Flush();
                writer.BaseStream.Seek(0, SeekOrigin.Begin);
            }

            public string ReadOut()
            {
                StreamReader reader = new StreamReader(OutStream);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                return reader.ReadToEnd();
            }

            public void Dispose()
            {
                InStream.Dispose();
                OutStream.Dispose();
            }
        }
    }
}

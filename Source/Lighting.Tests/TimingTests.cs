using Lighting.Timings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Lighting.Tests
{
    [TestClass]
    public class TimingTests
    {
        [TestMethod]
        public void Constant()
        {
            var subject = new TimingConstant();
            subject.Milliseconds = 50;

            var totalTime = 0L;
            var measurements = 10;
            subject.Reset(measurements);

            var stopwatch = new Stopwatch();

            for (int i = 0; i < measurements; i++)
            {
                stopwatch.Restart();
                subject.Delay();
                stopwatch.Stop();
                totalTime += stopwatch.ElapsedMilliseconds;
            }

            var average = (double)totalTime / measurements;
            Assert.AreEqual(50, average, 15);
        }

        [TestMethod]
        public void None()
        {
            var subject = new TimingNone();

            var totalTime = 0L;
            var measurements = 10;
            subject.Reset(measurements);

            var stopwatch = new Stopwatch();

            for (int i = 0; i < measurements; i++)
            {
                stopwatch.Restart();
                subject.Delay();
                stopwatch.Stop();
                totalTime += stopwatch.ElapsedMilliseconds;
            }

            var average = (double)totalTime / measurements;
            Assert.AreEqual(0, average, 5);
        }

        [TestMethod]
        public void SlowDown()
        {
            var subject = new TimingSlowDown();
            subject.StartDelay = 30;
            subject.EndDelay = 300;

            var lastDelay = 0L;
            var measurements = 10;
            subject.Reset(measurements);

            var stopwatch = new Stopwatch();

            for (int i = 0; i < measurements; i++)
            {
                stopwatch.Start();
                subject.Delay();
                stopwatch.Stop();

                Assert.IsTrue(stopwatch.ElapsedMilliseconds > lastDelay, $"i={i}");
                Assert.AreEqual(30, stopwatch.ElapsedMilliseconds - lastDelay, 15, $"i={i}");
                lastDelay = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }
        }

        [TestMethod]
        public void SpeedUp()
        {
            var subject = new TimingSpeedUp();
            subject.StartDelay = 300;
            subject.EndDelay = 30;

            var lastDelay = 330L;
            var measurements = 10;
            subject.Reset(measurements);

            var stopwatch = new Stopwatch();

            for (int i = 0; i < measurements; i++)
            {
                stopwatch.Start();
                subject.Delay();
                stopwatch.Stop();
                
                Assert.IsTrue(stopwatch.ElapsedMilliseconds < lastDelay, $"i={i}");
                Assert.AreEqual(30, lastDelay - stopwatch.ElapsedMilliseconds, 15, $"i={i}");
                lastDelay = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }
        }
    }
}

using Lighting.Timings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Lighting.Tests
{
    [TestClass]
    public class TimingTests
    {
        enum TimingAssert
        {
            Pass,
            Inconclusive,
            Fail
        }

        private static TimingAssert AssertTimingResult(double expected, double actual, double passDelta, int inconclusiveDelta)
        {
            var difference = Math.Abs(actual - expected);
            if (difference < passDelta)
                return TimingAssert.Pass;

            if (difference < inconclusiveDelta)
                return TimingAssert.Inconclusive;

            return TimingAssert.Fail;
        }

        private static void RaiseAssert(TimingAssert result, string message)
        {
            switch (result)
            {
                case TimingAssert.Pass:
                    Assert.IsTrue(true, message);
                    break;
                case TimingAssert.Inconclusive:
                    Assert.Inconclusive(message);
                    break;
                case TimingAssert.Fail:
                    Assert.Fail(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }
        }

        private static void AssertTiming(double expected, double actual, double passDelta, int inconclusiveDelta, string additionalText = null)
        {
            var message = $"Expected difference of <{passDelta}> - <{inconclusiveDelta}> time between <{expected}>, actual <{actual}>. ";
            if (additionalText != null)
                message += additionalText;

            var result = AssertTimingResult(expected, actual, passDelta, inconclusiveDelta);
            RaiseAssert(result, message);
        }

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

            AssertTiming(50, average, 10, 20);
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
            AssertTiming(0, average, 5, 10);
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

            var inconclusive = false;
            var totalDifference = 0L;
            var minDifference = long.MaxValue;
            var maxDifference = 0L;

            for (int i = 0; i < measurements; i++)
            {
                stopwatch.Start();
                subject.Delay();
                stopwatch.Stop();

                Assert.IsTrue(stopwatch.ElapsedMilliseconds > lastDelay, $"i={i}");
                var difference = stopwatch.ElapsedMilliseconds - lastDelay;
                var thisResult = AssertTimingResult(30, difference, 15, 20);
                totalDifference += difference;
                minDifference = Math.Min(minDifference, difference);
                maxDifference = Math.Max(maxDifference, difference);
                if (thisResult == TimingAssert.Fail)
                    RaiseAssert(thisResult, $"i={i}, this difference <{difference}>, Min difference <{minDifference}>, Max difference <{maxDifference}>, Average difference <{(double)totalDifference / i + 1}>, expected <30>");
                inconclusive = inconclusive || thisResult == TimingAssert.Inconclusive;

                lastDelay = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            RaiseAssert(inconclusive ? TimingAssert.Inconclusive : TimingAssert.Pass, $"Min difference <{minDifference}>, Max difference <{maxDifference}>, Average difference <{(double)totalDifference / measurements}>, expected <30>");
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
            var inconclusive = false;
            var totalDifference = 0L;
            var minDifference = long.MaxValue;
            var maxDifference = 0L;

            for (int i = 0; i < measurements; i++)
            {
                stopwatch.Start();
                subject.Delay();
                stopwatch.Stop();
                
                Assert.IsTrue(stopwatch.ElapsedMilliseconds < lastDelay, $"i={i}");
                var difference = lastDelay - stopwatch.ElapsedMilliseconds;
                var thisResult = AssertTimingResult(30, difference, 15, 20);
                totalDifference += difference;
                minDifference = Math.Min(minDifference, difference);
                maxDifference = Math.Max(maxDifference, difference);
                if (thisResult == TimingAssert.Fail)
                    RaiseAssert(thisResult, $"i={i}, this difference <{difference}>, Min difference <{minDifference}>, Max difference <{maxDifference}>, Average difference <{(double)totalDifference / i + 1}>, expected <30>");
                inconclusive = inconclusive || thisResult == TimingAssert.Inconclusive;

                lastDelay = stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }
            
            RaiseAssert(inconclusive ? TimingAssert.Inconclusive : TimingAssert.Pass, $"Min difference <{minDifference}>, Max difference <{maxDifference}>, Average difference <{(double)totalDifference / measurements}>, expected <30>");
        }
    }
}

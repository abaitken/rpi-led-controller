using Lighting.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lighting.Tests
{
    [TestClass]
    public class PatternTests
    {
        [TestMethod]
        public void SolidColor()
        {
            var subject = new PatternSolidColor();
            subject.Color = Color.Blue;

            var info = new MockLightingInformation
            {
                LightCount = 10
            };

            var random = new Random(0);
            subject.Reset(info, random);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(Color.Blue, subject[i]);
            }
            
            subject.NextState(random);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(Color.Blue, subject[i]);
            }
        }

        [TestMethod]
        public void Clear()
        {
            var subject = new PatternClear();

            var info = new MockLightingInformation
            {
                LightCount = 10
            };

            var random = new Random(0);
            subject.Reset(info, random);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(Color.Black, subject[i]);
            }

            subject.NextState(random);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(Color.Black, subject[i]);
            }
        }

        [TestMethod]
        public void Random()
        {
            var subject = new PatternRandom();

            var info = new MockLightingInformation
            {
                LightCount = 10
            };

            var random = new Random(0);
            subject.Reset(info, random);


            Assert.AreEqual(new Color(45, 0, 210), subject[0]);
            Assert.AreEqual(new Color(117, 0, 138), subject[1]);
            Assert.AreEqual(new Color(78, 0, 177), subject[2]);
            Assert.AreEqual(new Color(0, 84, 171), subject[3]);
            Assert.AreEqual(new Color(99, 156, 0), subject[4]);
            Assert.AreEqual(new Color(0, 81, 174), subject[5]);
            Assert.AreEqual(new Color(183, 0, 72), subject[6]);
            Assert.AreEqual(new Color(0, 171, 84), subject[7]);
            Assert.AreEqual(new Color(240, 0, 15), subject[8]);
            Assert.AreEqual(new Color(45, 210, 0), subject[9]);

            subject.NextState(random);

            Assert.AreEqual(new Color(45, 0, 210), subject[0]);
            Assert.AreEqual(new Color(117, 0, 138), subject[1]);
            Assert.AreEqual(new Color(78, 0, 177), subject[2]);
            Assert.AreEqual(new Color(0, 84, 171), subject[3]);
            Assert.AreEqual(new Color(99, 156, 0), subject[4]);
            Assert.AreEqual(new Color(0, 81, 174), subject[5]);
            Assert.AreEqual(new Color(183, 0, 72), subject[6]);
            Assert.AreEqual(new Color(0, 171, 84), subject[7]);
            Assert.AreEqual(new Color(240, 0, 15), subject[8]);
            Assert.AreEqual(new Color(45, 210, 0), subject[9]);
        }

        [TestMethod]
        public void RandomSolidColor()
        {
            var subject = new PatternRandomSolidColor();

            var info = new MockLightingInformation
            {
                LightCount = 10
            };

            var random = new Random(0);
            subject.Reset(info, random);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(new Color(45, 0, 210), subject[i]);
            }

            subject.NextState(random);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(new Color(45, 0, 210), subject[i]);
            }
        }

        private class MockLightingInformation : ILightingInformation
        {
            public int LightCount { get; set; }

            public byte DefaultBrightness => throw new NotImplementedException();

            public byte Brightness => throw new NotImplementedException();
        }
    }
}

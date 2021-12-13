using Lighting.Animations;
using Lighting.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Lighting.Tests
{
    [TestClass]
    public class AnimationTests
    {
        Random random;
        IPattern pattern;

        [TestInitialize]
        public void Init()
        {
            random = new Random(1);
            pattern = new FixedPattern();
        }
        class FixedPattern : Pattern
        {
            private List<Color> _colors;

            public FixedPattern()
            {
                _colors = new List<Color>
                {
                    /*0*/ Color.Red,
                    /*1*/ Color.Green,
                    /*2*/ Color.Blue,
                    /*3*/ Color.White,
                    /*4*/ Color.Purple,
                    /*5*/ Color.Silver,
                    /*6*/ Color.Gold,
                    /*7*/ Color.Orange,
                    /*8*/ Color.Yellow,
                    /*9*/ Color.Pink
                };
            }
            public override Color this[int index] => _colors[index];

            public override void NextState(Random random)
            {
            }

            public override void Reset(ILightingInformation information, Random random)
            {
            }
        }
        class AssertColor : ILight
        {
            private readonly Color _requiredColor;
            private Color _color;

            public AssertColor(Color requiredColor)
            {
                _requiredColor = requiredColor;
            }
            public Color Color 
            { 
                get => _color;
                set 
                {
                    if (value != _requiredColor)
                        throw new InvalidOperationException();

                    _color = value;
                }
            }
        }

        [TestMethod]
        public void CenterOut()
        {
            var subject = new AnimationCenterOut();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(10, subject.Begin(controllerMock.Object, pattern, random));
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        [TestMethod]
        public void EdgeIn()
        {
            var subject = new AnimationEdgeIn();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(10, subject.Begin(controllerMock.Object, pattern, random));
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        private class MockLightingController : ILightingController
        {
            public ILight this[int index]
            {
                get
                {
                    return new MockLight();
                }
            }

            ILightInformation ILightingInformation.this[int index] => throw new NotImplementedException();

            public int LightCount { get; set; }

            public byte DefaultBrightness { get; set; }

            public byte Brightness { get; set; }

            public void Update()
            {

            }

            private class MockLight : ILight
            {
                public Color Color 
                { 
                    get => throw new NotImplementedException(); 
                    set
                    {
                        /* Do nothing */
                    }
                }
            }
        }

        [TestMethod]
        public void FadeIn()
        {
            var subject = new AnimationFadeIn
            {
                BrightnessStart = 10,
                BrightnessEnd = 150,
                BrightnessAdjust = 28
            };

            var controllerMock = new MockLightingController
            {
                Brightness = 200,
                LightCount = 10,
                DefaultBrightness = 150
            };

            Assert.AreEqual(5, subject.Begin(controllerMock, pattern, random));
            Assert.AreEqual(10, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(38, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(66, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(94, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(122, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(150, controllerMock.Brightness);
        }

        [TestMethod]
        public void FadeOut()
        {
            var subject = new AnimationFadeOut
            {
                BrightnessStart = 150,
                BrightnessEnd = 10,
                BrightnessAdjust = 28
            };

            var controllerMock = new MockLightingController
            {
                Brightness = 200,
                LightCount = 10,
                DefaultBrightness = 150
            };

            Assert.AreEqual(5, subject.Begin(controllerMock, pattern, random));
            Assert.AreEqual(150, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(122, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(94, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(66, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(38, controllerMock.Brightness);

            Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock, pattern, random));
            Assert.AreEqual(10, controllerMock.Brightness);
        }

        [TestMethod]
        public void FillLeft()
        {
            var subject = new AnimationFillLeft();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(10, subject.Begin(controllerMock.Object, pattern, random));
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        [TestMethod]
        public void FillRight()
        {
            var subject = new AnimationFillRight();


            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(10, subject.Begin(controllerMock.Object, pattern, random));
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }


        }

        [TestMethod]
        public void Flashing()
        {
            var subject = new AnimationFlashing();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(4, subject.Begin(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }


            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);

                controllerMock.SetupSet(i => i.Brightness = It.Is<byte>(v => v == 0)).Verifiable();

                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }


            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);

                controllerMock.SetupSet(i => i.Brightness = It.Is<byte>(v => v == 150)).Verifiable();

                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }


            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);

                controllerMock.SetupSet(i => i.Brightness = It.Is<byte>(v => v == 0)).Verifiable();

                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }


            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);

                controllerMock.SetupSet(i => i.Brightness = It.Is<byte>(v => v == 150)).Verifiable();

                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }


            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);

                controllerMock.SetupSet(i => i.Brightness = It.Is<byte>(v => v == 0)).Verifiable();

                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }


            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);

                controllerMock.SetupSet(i => i.Brightness = It.Is<byte>(v => v == 150)).Verifiable();

                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }


            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);

                controllerMock.SetupSet(i => i.Brightness = It.Is<byte>(v => v == 0)).Verifiable();

                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }


            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);

                controllerMock.SetupSet(i => i.Brightness = It.Is<byte>(v => v == 150)).Verifiable();

                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        [TestMethod]
        public void Instant()
        {
            var subject = new AnimationInstant();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(1, subject.Begin(controllerMock.Object, pattern, random));
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        [TestMethod]
        public void Random()
        {
            var subject = new AnimationRandom();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(249, subject.Begin(controllerMock.Object, pattern, random));
            }

            for (int i = 0; i < 248; i++)
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red));
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green));
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue));
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White));
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple));
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver));
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold));
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange));
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow));
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink));
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red));
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green));
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue));
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White));
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple));
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver));
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold));
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange));
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow));
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink));
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        [TestMethod]
        public void SectionSlideLeft()
        {
            var subject = new AnimationSectionSlideLeft()
            {
                SectionLength = 3
            };

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(13, subject.Begin(controllerMock.Object, pattern, random));
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

        }

        [TestMethod]
        public void SectionSlideRight()
        {
            var subject = new AnimationSectionSlideRight()
            {
                SectionLength = 3
            };

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(13, subject.Begin(controllerMock.Object, pattern, random));
            }


            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }

            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Black)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        [TestMethod]
        public void ShiftLeft()
        {
            var subject = new AnimationShiftLeft();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(10, subject.Begin(controllerMock.Object, pattern, random));
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        [TestMethod]
        public void ShiftRight()
        {
            var subject = new AnimationShiftRight();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(10, subject.Begin(controllerMock.Object, pattern, random));
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        [TestMethod]
        public void SlideLeft()
        {
            var subject = new AnimationSlideLeft();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(10, subject.Begin(controllerMock.Object, pattern, random));
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }

        [TestMethod]
        public void SlideRight()
        {
            var subject = new AnimationSlideRight();

            {
                var controllerMock = new Mock<ILightingController>();
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                Assert.AreEqual(10, subject.Begin(controllerMock.Object, pattern, random));
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.InProgress, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
            {
                var controllerMock = new Mock<ILightingController>(MockBehavior.Strict);
                controllerMock.Setup(i => i.LightCount).Returns(10);
                controllerMock.Setup(i => i.Brightness).Returns(150);
                controllerMock.Setup(i => i.DefaultBrightness).Returns(150);
                controllerMock.Setup(i => i[0]).Returns(new AssertColor(Color.Red)).Verifiable();
                controllerMock.Setup(i => i[1]).Returns(new AssertColor(Color.Green)).Verifiable();
                controllerMock.Setup(i => i[2]).Returns(new AssertColor(Color.Blue)).Verifiable();
                controllerMock.Setup(i => i[3]).Returns(new AssertColor(Color.White)).Verifiable();
                controllerMock.Setup(i => i[4]).Returns(new AssertColor(Color.Purple)).Verifiable();
                controllerMock.Setup(i => i[5]).Returns(new AssertColor(Color.Silver)).Verifiable();
                controllerMock.Setup(i => i[6]).Returns(new AssertColor(Color.Gold)).Verifiable();
                controllerMock.Setup(i => i[7]).Returns(new AssertColor(Color.Orange)).Verifiable();
                controllerMock.Setup(i => i[8]).Returns(new AssertColor(Color.Yellow)).Verifiable();
                controllerMock.Setup(i => i[9]).Returns(new AssertColor(Color.Pink)).Verifiable();
                controllerMock.Setup(i => i.Update()).Verifiable();
                Assert.AreEqual(AnimationState.Complete, subject.Step(controllerMock.Object, pattern, random));
                controllerMock.Verify();
            }
        }



    }
}

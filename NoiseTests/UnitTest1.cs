using NUnit.Framework;
using Zen.Noise;

namespace Zen.NoiseTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var noise = Noise.Noise.GetNoise(4, 1, 0.5f, 1336, NoiseType.Value, InterpolationMethod.Linear);

            Assert.AreEqual(0.98251605f, noise[0]);
            Assert.AreEqual(0.0890615582f, noise[1]);
            Assert.AreEqual(-0.804392934f, noise[2]);
            Assert.AreEqual(-0.681281447f, noise[3]);
        }
    }
}
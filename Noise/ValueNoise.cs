using System;

namespace Zen.Noise
{
    public static class ValueNoise
    {
        private const int X_PRIME = 1619;
        private const int Y_PRIME = 31337;
        private const int PRIME = 60493;

        public static float GetSingleValue(int x, int y, float frequency, int seed, InterpolationMethod interpolationMethod)
        {
            var x0 = x * frequency;
            var y0 = y * frequency;
            var x1 = Floor(x0);
            var y1 = Floor(y0);
            var x2 = x1 + 1;
            var y2 = y1 + 1;

            float xFraction;
            float yFraction;
            switch (interpolationMethod)
            {
                case InterpolationMethod.Linear:
                    xFraction = x0 - x1;
                    yFraction = y0 - y1;
                    break;
                case InterpolationMethod.Hermite:
                    xFraction = HermiteInterpolationFunc(x0 - x1);
                    yFraction = HermiteInterpolationFunc(y0 - y1);
                    break;
                case InterpolationMethod.Quintic:
                    xFraction = QuinticInterpolationFunc(x0 - x1);
                    yFraction = QuinticInterpolationFunc(y0 - y1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(interpolationMethod), interpolationMethod, $"InterpolationMethod [{interpolationMethod}] is not supported.");
            }

            var xf0 = Lerp(ValueCoordinate2D(x1, y1, seed), ValueCoordinate2D(x2, y1, seed), xFraction);
            var xf1 = Lerp(ValueCoordinate2D(x1, y2, seed), ValueCoordinate2D(x2, y2, seed), xFraction);

            var noiseValue = Lerp(xf0, xf1, yFraction);

            return noiseValue;
        }

        private static int Floor(float f) { return f >= 0 ? (int)f : (int)f - 1; }

        private static float HermiteInterpolationFunc(float t) { return t * t * (3 - 2 * t); }

        private static float QuinticInterpolationFunc(float t) { return t * t * t * (t * (t * 6 - 15) + 10); }

        private static float Lerp(float a, float b, float t) { return a + t * (b - a); }

        private static float ValueCoordinate2D(int x, int y, int seed)
        {
            var n = seed;
            n ^= X_PRIME * x;
            n ^= Y_PRIME * y;

            var ret = (n * n * n) * PRIME / 2147483648.0f; // (float)int.MaxValue + 1.0f; // 2147483648.0;

            return ret;
        }
    }
}
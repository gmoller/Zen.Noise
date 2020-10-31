using System;

namespace Zen.Noise
{
    public static class Noise
    {
        //fastNoise.SetNoiseType(FastNoise.NoiseType.Value);
        //fastNoise.SetInterp(FastNoise.Interp.Linear);
        //fastNoise.SetSeed(1336);
        //fastNoise.SetFrequency(0.5f);
        public static float[] GetNoise(int columns, int rows, float frequency, int seed, NoiseType noiseType, InterpolationMethod interpolationMethod)
        {
            var noise = new float[columns * rows];

            var i = 0;
            for (var y = 0; y < rows; y++)
            {
                for (var x = 0; x < columns; x++)
                {
                    switch (noiseType)
                    {
                        case NoiseType.Value:
                            noise[i] = ValueNoise.GetSingleValue(x, y, frequency, seed, interpolationMethod);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(noiseType), noiseType, $"NoiseType [{noiseType}] is not supported.");
                    }
                    i++;
                }
            }

            return noise;
        }
    }
}
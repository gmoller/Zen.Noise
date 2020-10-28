namespace Zen.Noise
{ 
    public enum NoiseType
    {
        Value,
        ValueFractal,
        Perlin,
        PerlinFractal,
        Simplex,
        SimplexFractal,
        Cellular,
        WhiteNoise,
        Cubic,
        CubicFractal
    }

    public enum InterpolationMethod
    {
        Linear,
        Hermite,
        Quintic
    }
}
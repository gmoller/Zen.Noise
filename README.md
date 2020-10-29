# Zen.Noise

Simple routines to create Noise for use with procedurally generated artifacts.
Currently very incomplete, only does Value noise for now.

# Example
To use:

    var noise = Zen.Noise.Noise.GetNoise(4, 1, 0.5f, 1336, Zen.Noise.NoiseType.Value, Zen.Noise.InterpolationMethod.Linear);

    Assert.AreEqual(0.98251605f, noise[0]);
    Assert.AreEqual(0.0890615582f, noise[1]);
    Assert.AreEqual(-0.804392934f, noise[2]);
    Assert.AreEqual(-0.681281447f, noise[3]);
    
# Developer
Written by Greg Moller (greg.moller@gmail.com)

# License
Licensed under the MIT License. See the LICENCE file for more information.

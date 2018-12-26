using System;
using NAudio.Dsp;
using NAudio.Wave;

namespace BrownNoise
{
    public class NoiseProvider32 : WaveProvider32
    {
        Random rand;
        BiQuadFilter filter;

        public NoiseProvider32(float filterFreq)
        {
            rand = new Random((int)DateTime.Now.Ticks);
            Amplitude = 0.25f; // let's not hurt our ears
            filter = BiQuadFilter.LowPassFilter(WaveFormat.SampleRate, filterFreq, 1f);
        }

        public float Amplitude { get; set; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                float sample = (float) ((rand.NextDouble() - Amplitude) % Amplitude);
                sample = filter.Transform(sample);
                buffer[n + offset] = sample;
            }
            return sampleCount;
        }
    }
}

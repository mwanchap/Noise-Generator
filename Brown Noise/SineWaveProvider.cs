using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BrownNoise
{
    class SineWaveProvider:  WaveProvider32
    {
        private SignalGenerator SigGen { get; set; }

        public SineWaveProvider(int frequency)
        {
            SigGen = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = frequency,
                Type = SignalGeneratorType.Sin
            };

            SigGen.ToWaveProvider();
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            return SigGen.Read(buffer, offset, sampleCount);
        }
    }
}

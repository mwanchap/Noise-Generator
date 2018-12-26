using System;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace BrownNoise
{
    public class SoundController
    {
        public WaveOut waveOut;
        public NoiseProvider32 noiseProvider;
        public NoiseType SelectedNoiseType { get; set; }

        public SoundController()
        {
            waveOut = new WaveOut();
            noiseProvider = new NoiseProvider32(3000);
        }

        public void Start()
        {
            WaveProvider32 noiseProvider;

            switch (SelectedNoiseType)
            {
                case NoiseType.BrownNoise:
                    var brownNoise = new NoiseProvider32(3000);
                    noiseProvider = brownNoise;
                    break;
                case NoiseType.SineWave:
                    var sineWave = new SineWaveProvider(150);
                    noiseProvider = sineWave;
                    break;
                default:
                    throw new InvalidOperationException("Invalid noise type");
            }

            if (waveOut.PlaybackState != PlaybackState.Playing)
            {
                waveOut = new WaveOut();
                waveOut.Init(noiseProvider);
                waveOut.Play();
            }
        }

        public void Stop()
        {
            waveOut.Stop();
        }

        public float Volume
        {
            get { return waveOut.Volume; }
            set { waveOut.Volume = value; }
        }

        public void SwitchSoundType(NoiseType noiseType)
        {
            Stop();
            SelectedNoiseType = noiseType;
            Start();
        }
    }
}

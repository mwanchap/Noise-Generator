using NAudio.Wave;

namespace BrownNoise
{
    public static class SoundController
    {
        public static WaveOut waveOut;
        public static NoiseProvider32 noiseProvider;

        static SoundController()
        {
            waveOut = new WaveOut();
            noiseProvider = new NoiseProvider32(3000);
        }

        public static void Start()
        {
            if (waveOut.PlaybackState != PlaybackState.Playing)
            {
                waveOut = new WaveOut();
                noiseProvider = new NoiseProvider32(3000);
                noiseProvider.SetWaveFormat(16000, 1); // 16kHz mono
                waveOut.Init(noiseProvider);
                waveOut.Play();
            }
        }

        public static void Stop()
        {
            /*for (int i = (int)(waveOut.Volume * 100); i > 0; i--)
            {
                waveOut.Volume = i / 100f;
            }*/

            waveOut.Stop();
        }

        public static float Volume
        {
            get { return waveOut.Volume; }
            set { waveOut.Volume = value; }
        }
    }
}

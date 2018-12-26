# Brown Noise

Brown noise is the lower-frequency component of white noise (the random static you can hear between radio and TV channels). Research shows that brown noise can aid in concentration (http://skeptics.stackexchange.com/a/8066).  I have a brown noise mp3 that I have looping, but every 10 minutes when it loops it pauses for a split second, which can be jarring when it happens just as I'm getting lulled into the noise.  So I decided to make this program, which spits out unlimited brown noise forever.

## How it works:
* Uses the free and excellent NAudio library for the actual playback (http://naudio.codeplex.com)
* Prepare a buffer of samples to play by filling the buffer with random noise (NoiseProvider32.Read)
* Pass it through a low-pass filter at 3kHz (in the Read method, filter.Transform)
* Play that
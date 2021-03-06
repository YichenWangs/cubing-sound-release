/***

THE DISUNITY SYNTHESIZER TOOLKIT

Copyright 2020 Andrew Sorensen

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

***/

using UnityEngine;

namespace DST {

    [RequireComponent(typeof(AudioSource))]
    public class AudioSink : MonoBehaviour {

        public AudioUnit input;
        [Range(0.0F, 1.0F)]
        public float gain = 0.5F;
        private long _sampleNum = 0;
    
        public long sampleNum {
            get {
                return _sampleNum;
            }    
        }

        private void OnAudioFilterRead(float[] data, int channels)
        {
            if (input != null)
            {
                input.ProcessAudio(data, null, _sampleNum, channels);
                for (int i=0; i < data.Length; i++) {
                    data[i] *= gain;
                }
            }
            
            _sampleNum += (data.Length / channels);
        }
    }
}
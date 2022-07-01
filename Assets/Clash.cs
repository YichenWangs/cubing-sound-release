using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
//using Microsoft.MixedReality.Toolkit.UI;

public class Clash : MonoBehaviour
{
    public GameObject carrier;
    public GameObject modulation;
    public GameObject chord;
    public int tag;

    //public string pitch;

    //private DST.AudioSink audiosink;
    private DST.VCA vca;
    private DST.Constant notes;

    private DST.Oscillator osc_1;
    private DST.Oscillator osc_2;

    private DST.Constant m_notes;

    private DST.Constant chord_notes_1;

    private DST.Oscillator chord_osc_1;
    private DST.Oscillator chord_osc_2;

    private DST.Constant chord_notes_2;


    List<DST.Oscillator> oscs = new List<DST.Oscillator>();
    List<DST.Constant> constants = new List<DST.Constant>();




    private int octave =4;

    private bool musicFadeOutEnabled = false;
    private bool musicFadeInEnabled = false;

    private double[] pitches = new double[] {
    65.406,
    69.296,
    73.416,
    77.782,
    82.407,
    87.307,
    92.499,
    97.999,
    103.826,
    110.000,
    116.541,
    123.471,
    130.813,
    138.591,
    146.832,
    155.564,
    164.814,
    174.614,
    184.997,
    195.998,
    207.652,
    220.000,
    233.082,
    246.942,
    261.63,
    277.18,
    293.66,
    311.13,
    329.63,
    349.23,
    369.99,
    392.00,
    415.30,
    440.00,
    466.16,
    493.88,
    523.25,
    554.37,
    587.33,
    622.25,
    659.25,
    698.46,
    739.99,
    783.99,
    830.61,
    880.00,
    932.33,
    987.77,
    1046.50,
    1108.73,
    1174.66,
    1244.51,
    1318.51,
    1396.91,
    1479.98,
    1567.98,
    1661.22,
    1760.00,
    1864.66,
    1975.53,
    2093.00
    };



    // Start is called before the first frame update
    void Start()
    {

        //audiosink = carrier.GetComponent<DST.AudioSink>();
        vca = carrier.GetComponent<DST.VCA>();

        notes = carrier.GetComponent<DST.Constant>();
        m_notes = modulation.GetComponent<DST.Constant>();

        osc_1 = carrier.GetComponent<DST.Oscillator>();
        osc_2 = modulation.GetComponent<DST.Oscillator>();



        chord.GetComponents(oscs);
        chord.GetComponents(constants);

        for (int i = 0; i < oscs.Count; i++)
        {
            if (oscs[i].AUID.Equals("1"))
            {

                chord_osc_1 = oscs[i];
            }
            else if (oscs[i].AUID.Equals("2"))
            {
                chord_osc_2 = oscs[i];

            }
        }

        for (int i = 0; i < constants.Count; i++)
        {
            if (constants[i].AUID.Equals("1"))
            {

                chord_notes_1 = constants[i];
            }
            else if (constants[i].AUID.Equals("2"))
            {
                chord_notes_2 = constants[i];

            }
        }







        //audiosink.gain = 0f;
        vca.amp = 0f;

        musicFadeOutEnabled = false;
        musicFadeInEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //print(audiosink.gain);
        if (musicFadeOutEnabled)
        {
            //print(musicFadeOutEnabled);

            //if (audiosink.gain < 0.9f)
            //{
            //    //print(Time.deltaTime);
            //    float newVolume = audiosink.gain + (0.1f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
            //    //print(newVolume);
            //    if (newVolume == 0.9f)
            //    {
            //        newVolume = 0.9f;
            //        musicFadeOutEnabled = false;
            //        musicFadeInEnabled = false;


            //    }
            //    audiosink.gain
            //    = newVolume;


            if (vca.amp < 3.0f)
            {
                //print(Time.deltaTime);
                float newVolume = vca.amp + (0.1f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
                //print(newVolume);
                if (newVolume == 3.0f)
                {
                    newVolume = 3.0f;
                    musicFadeOutEnabled = false;
                    musicFadeInEnabled = false;


                }
                vca.amp
                = newVolume;
            }
            //Debug.Log("FadeOut");
            //print("musicFadeOutEnabled" + musicFadeOutEnabled);
            //musicFadeInEnabled = false;


        }


        //if (musicFadeInEnabled)
        //{


        //    if (audiosink.gain > 0f)
        //    {

        //        //print("greater than zero");
        //        float volume = audiosink.gain - (0.1f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
        //        //print(Time.deltaTime);

        //        //print(volume);
        //        if (volume < 0.005f)
        //        {
        //            volume = 0f;
        //            musicFadeInEnabled = false;
        //            musicFadeOutEnabled = false;
        //        }
        //        audiosink.gain
        //        = volume;
        //    }

        //}

        if (musicFadeInEnabled)
        {


            if (vca.amp > 0f)
            {

                //print("greater than zero");
                float volume = vca.amp - (0.1f * Time.deltaTime);  //change 0.01f to something else to adjust the rate of the volume dropping
                //print(Time.deltaTime);

                //print(volume);
                if (volume < 0.005f)
                {
                    volume = 0f;
                    musicFadeInEnabled = false;
                    musicFadeOutEnabled = false;
                }
                vca.amp = volume;
            }

        }

        //Debug.Log(this.gameObject.GetComponent<Renderer>().material );

        chord.GetComponents(oscs);
        chord.GetComponents(constants);

        for (int i = 0; i < oscs.Count; i++)
        {
            if (oscs[i].AUID.Equals("1"))
            {

                chord_osc_1 = oscs[i];
            }
            else if (oscs[i].AUID.Equals("2"))
            {
                chord_osc_2 = oscs[i];

            }
        }

        for (int i = 0; i < constants.Count; i++)
        {
            if (constants[i].AUID.Equals("1"))
            {

                chord_notes_1 = constants[i];
            }
            else if (constants[i].AUID.Equals("2"))
            {
                chord_notes_2 = constants[i];

            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {

        if (tag == 1)
        {

            musicFadeOutEnabled = true;
            musicFadeInEnabled = false;
        }
        else {

            musicFadeInEnabled = true;
            musicFadeOutEnabled = false;
        }

        //Debug.Log("Collide!");

        //audiosink.gain = 0.5f;
        string note = this.gameObject.name.Replace("(Clone)", "").Trim();
        //Debug.Log(note);


        string rightt = other.gameObject.name.Replace("(Clone)", "").Trim();
        Debug.Log(other.gameObject);

  

        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);


        int i = (octave-4)*12;
        //Debug.Log(i);

        //Debug.Log(octave);

        if (note.Equals("C"))
        {
            notes.value = pitches[24+i];
        }
        else if (note.Equals("C#"))
        {
            notes.value = pitches[25+i];
        }
        else if (note.Equals("D"))
        {
            notes.value = pitches[26+i];
        }
        else if (note.Equals("D#"))
        {
            notes.value = pitches[27+i];
        }
        else if (note.Equals("E"))
        {
            notes.value = pitches[28+i];
        }
        else if (note.Equals("F"))
        {
            notes.value = pitches[29+i];
        }
        else if (note.Equals("F#"))
        {
            notes.value = pitches[30+i];
        }
        else if (note.Equals("G"))
        {
            notes.value = pitches[31+i];
        }
        else if (note.Equals("G#"))
        {
            notes.value = pitches[32+i];
        }
        else if (note.Equals("A"))
        {
            notes.value = pitches[33+i];
        }
        else if (note.Equals("A#"))
        {
            notes.value = pitches[34+i];
        }
        else if (note.Equals("B"))
        {
            notes.value = pitches[35+i];
        }
        else if (note.Equals("B#"))
        {
            notes.value = pitches[36 + i];
        }
        else if (note.Equals("C5"))
        {
            notes.value = pitches[37 + i];
        }
        else if (note.Equals("osc_1__sin")) {
            osc_1.waveForm = DST.WAVEFORM.SINE;
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else if (note.Equals("osc_1__saw"))
        {
            osc_1.waveForm = DST.WAVEFORM.SAW;
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        else if (note.Equals("osc_1__pulse"))
        {
            osc_1.waveForm = DST.WAVEFORM.PULSE;
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
        else if (note.Equals("osc_2__sin")) {
            osc_2.waveForm = DST.WAVEFORM.SINE;
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else if (note.Equals("osc_2__saw"))
        {
            osc_2.waveForm = DST.WAVEFORM.SAW;
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        else if (note.Equals("osc_2__pulse"))
        {
            osc_2.waveForm = DST.WAVEFORM.PULSE;
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }

        if (tag== 2) {
            if (note.Equals("80"))
            {
                m_notes.value = 80;
                this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }
            else if (note.Equals("400")) 
            {
                m_notes.value = 400;
                this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            } else if (note.Equals("800")) 
            {
                m_notes.value = 800;
                this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }


        }


        if (rightt.Equals("RightIndex"))
        {

            chord_osc_1.waveForm = osc_1.waveForm;
            chord_osc_2.waveForm = osc_2.waveForm;

            //chord_osc_1.gain = osc_1.gain;
            //chord_osc_2.gain = osc_2.gain;

            chord_notes_1.value = notes.value;
            chord_notes_2.value = m_notes.value;




        }
    }

    

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit!");
        //audiosink.gain = 0f;
        musicFadeInEnabled = true;
        musicFadeOutEnabled = false;

        //this.gameObject.GetComponent<Renderer>().material = StandardShaderUtility.MrtkStandardShader.get;

        if (tag == 2)
        {
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.clear);
        }

        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.clear);

        if (tag == 1) {
            chord_notes_1.value = 0f;
            chord_notes_2.value = 0f;
            notes.value = 0f;
        }

    }


    public void ChangeOctaveFive() {
        octave = 5;           
    }
    public void ChangeOctaveSix()
    {
        octave = 6;
    }
    public void ChangeOctaveTwo()
    {
        octave = 2;
    }
    public void ChangeOctaveThree()
    {
        octave = 3;
    }
    public void ChangeOctaveFour()
    {
        octave = 4;
    }
}

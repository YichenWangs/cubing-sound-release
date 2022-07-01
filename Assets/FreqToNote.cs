using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreqToNote : MonoBehaviour
{

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

    private string[] notes = new string[] {
    "C",
    "C#",
    "D",
    "D#",
    "E",
    "F",
    "F#",
    "G",
    "G#",
    "A",
    "A#",
    "B"


    };

    List<GameObject> childObjects = new List<GameObject>();
    public GameObject sound_source;
    public GameObject control_interface;

    DST.Constant sound_freq;
    private bool musicFadeOutEnabled = false;
    private bool musicFadeInEnabled = false;
    private DST.VCA vca;

    string map_note = "";

    string prev_note = "";
    GameObject prev_cube;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] allChildren = control_interface.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            childObjects.Add(child.gameObject);

        }

        musicFadeInEnabled = true;
        musicFadeOutEnabled = false;
        vca = sound_source.GetComponent<DST.VCA>();
        vca.amp = 0f;
        sound_freq = sound_source.GetComponent<DST.Constant>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<extOSC.OSCReceiver>().IsStarted)
        {

        if (musicFadeOutEnabled)
        {

            if (vca.amp < 2.0f)
            {
                float newVolume = vca.amp + (2f * Time.deltaTime);  //change 0.01f to something else to adjust the
                if (newVolume == 2.0f)
                {
                    newVolume = 2.0f;
                    musicFadeOutEnabled = false;
                    musicFadeInEnabled = false;


                }
                vca.amp
                = newVolume;
            }


        }

        if (musicFadeInEnabled)
        {


            if (vca.amp > 0f)
            {
                float volume = vca.amp - (1f * Time.deltaTime);  //change 0.01f to something else to adjust the 
                if (volume < 0.005f)
                {
                    volume = 0f;
                    musicFadeInEnabled = false;
                    musicFadeOutEnabled = false;
                }
                vca.amp = volume;
            }

        }


        }


    }

    public void lightUpNote(float frequency) {
        //Debug.Log("frequency" + frequency);
        int remainder =0;
        int quotient = 0;

        for (int i = 0; i < pitches.Length; i++) {

            if (System.Math.Abs(frequency - pitches[i]) < 1D)
            {

                //Debug.Log("frequency" + frequency);
                remainder = i % 12;
                quotient = (int) Mathf.Floor( (i+24) / 12);
                //Debug.Log(i);
                //Debug.Log("remainder" + remainder);
                map_note = notes[remainder];
                //Debug.Log("map_note " + map_note);

                //fixme
                sound_freq.value = pitches[i];



            }
            //else {

            //    sound_freq.value = 300f;

            //}


        }


        if (!prev_note.Equals(map_note) && !prev_note.Equals("")) {

            prev_cube = childObjects.Find(x => (x.name.Equals(prev_note)) && (x.tag.Equals(quotient.ToString())));
            //Debug.Log(quotient);
            //Debug.Log(prev_cube.tag);
            if (prev_cube != null) { 
                Renderer p_midi = prev_cube.GetComponent<Renderer>();
                Material p_midi_mat = p_midi.material;
                p_midi_mat.SetFloat("_RimPower", 5f);
                //Debug.Log(prev_cube);
            }




        }

        GameObject temp = childObjects.Find(x => (x.name.Equals(map_note)) && (x.tag.Equals(quotient.ToString())));



        if (temp != null)
        {
            Renderer midi = temp.GetComponent<Renderer>();
            //Debug.Log(temp);

            if (midi != null)
            {
                Material midi_mat = midi.material;
                midi_mat.SetFloat("_RimPower", 0f);


                //if (prev_cube != null)
                //{
                //    Renderer p_midi = prev_cube.GetComponent<Renderer>();
                //    Material p_midi_mat = p_midi.material;
                //    p_midi_mat.SetFloat("_RimPower", 8f);

                //}
            }




        //    prev_cube = temp;
        }
        prev_note = map_note;


    }
    
    public void soundOnOff(float var)
    {
        //Debug.Log("incoming");
        //Debug.Log(var);
        GameObject temp = childObjects.Find(x => x.name == map_note);

        if (var == 1f)
        {
            musicFadeOutEnabled = true;
            musicFadeInEnabled = false;

            if (temp != null)
            {
                Renderer midi = temp.GetComponent<Renderer>();

                if (midi != null)
                {
                    //Material midi_mat = midi.material;
                    //midi_mat.SetFloat("_RimPower", 0f);

                }

            }
        }
        else {
            musicFadeOutEnabled = false;
            musicFadeInEnabled = true;
            if (temp != null)
            {
                Renderer midi = temp.GetComponent<Renderer>();

                if (midi != null)
                {
                    //Material midi_mat = midi.material;
                    //midi_mat.SetFloat("_RimPower", 8f);

                }
            
            }
        }
    }

    public void freqOffset(float value) {

        DST.Oscillator osc = sound_source.GetComponent<DST.Oscillator>();

        osc.frqOffset = value;
    
    
    }


}

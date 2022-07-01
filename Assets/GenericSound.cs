using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSound : MonoBehaviour
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


    public GameObject note_source;
    public string note;
    private DST.VCA vca;
    private bool musicFadeOutEnabled = false;
    private bool musicFadeInEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        vca = note_source.GetComponent<DST.VCA>();
        vca.amp = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        vca = note_source.GetComponent<DST.VCA>();

        if (musicFadeOutEnabled)
        {

            if (vca.amp < 3.0f)
            {
                float newVolume = vca.amp + (2f * Time.deltaTime);  //change 0.01f to something else to adjust the
                if (newVolume == 3.0f)
                {
                    newVolume = 3.0f;
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

        Set_Note(note);
    }

    private void Set_Note(string note) {
        musicFadeOutEnabled = true;
        musicFadeInEnabled = false;

        note_source.GetComponent<DST.Constant>().value = pitches[28];

    }
}

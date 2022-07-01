using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using System;

public class ClashFinger : MonoBehaviour
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

    public GameObject soundcompt;
    public GameObject seq_soundcompt;
    public GameObject sequencer;
    public float soundOn;
    public double[] seq_pitches;



    private GameObject modulation;

    private DST.VCA vca;
    public DST.Constant notes;
    private DST.Constant seq_notes;

    private DST.Sequencer seq;
    private SequencerControl sc;

    private int seq_trigger;
    private long seq_step;



    public int tag_mal;

    private int octave = 4;

    private bool musicFadeOutEnabled = false;
    private bool musicFadeInEnabled = false;
    private bool lowcutoffEnabled = false;
    private bool lowcutoffLimit = false;


    // Start is called before the first frame update
    void Start()
    {
        
        vca = soundcompt.GetComponent<DST.VCA>();
        vca.amp = 0f;
        notes = soundcompt.GetComponent<DST.Constant>();
        notes.value = 0f;

        //seq_notes = seq_soundcompt.GetComponent<DST.Constant>();
        //seq_notes.value = 0f;


        musicFadeOutEnabled = false;
        musicFadeInEnabled = false;

        if (sequencer != null)
        {
            seq = sequencer.GetComponent<DST.Sequencer>();
            sc = seq.GetComponent<SequencerControl>();
            seq_trigger = sc.seq_trigger;
            seq_pitches = seq.pitches;

        }
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("###################");
        //Debug.Log(this.gameObject.name);
        //Debug.Log(this.gameObject.transform.position);
        //Debug.Log(soundOn);
        //Debug.Log("###################");
        if (sequencer != null)
        {

            sc = seq.GetComponent<SequencerControl>();
            seq_trigger = sc.seq_trigger;
            seq_step = sc.seq_step;
            seq_pitches = seq.pitches;


            //print(seq_step);

        }

        if (musicFadeOutEnabled)
        {


            if (vca.amp < 1.0f)
            {
                float newVolume = vca.amp + (2f * Time.deltaTime);  //change 0.01f to something else to adjust the
                if (newVolume == 1.0f)
                {
                    newVolume = 1.0f;
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
                float volume = vca.amp - (0.5f * Time.deltaTime);  //change 0.01f to something else to adjust the 
                if (volume < 0.005f)
                {
                    volume = 0f;
                    musicFadeInEnabled = false;
                    musicFadeOutEnabled = false;
                }
                vca.amp = volume;
            }

        }
        //Debug.Log(seq_trigger);

        


    }

    private void OnCollisionEnter(Collision other)
    {



        string temp_tag = other.gameObject.tag;
        

        modulation = soundcompt.transform.GetChild(0).gameObject;


        List<ContactPoint> contacts = new List<ContactPoint>();
        other.GetContacts(contacts);
        //print(other.contactCount);

        //print(midi.sharedMaterials);
        
        //for (int i = 0; i < other.contactCount; i++) {
        //    print(contacts[i].normal);
        //}


        List<string> notelist = new List<string> { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", "C5" };
        List<string> frqlist = new List<string> { "1", "25", "40", "60", "80", "100", "200", "250", "350", "400", "500", "600", "700" };


        string note = other.gameObject.name.Replace("(Clone)", "").Trim();

        Renderer midi = other.gameObject.GetComponent<Renderer>();

        if (midi != null)
        {
            //Debug.Log("lights");
            Material midi_mat = midi.material;
            midi_mat.SetFloat("_rimpower", 5f);

        }


        //Debug.Log(note);
        if (note.Equals("Seq")) {


            sc.seq_trigger = 1 - sc.seq_trigger;
            seq_trigger = 1- seq_trigger;
            Debug.Log ("SEQ");



            

        }
        else if (note.Equals("SIN")) {

            ChangeSoundWave(temp_tag, DST.WAVEFORM.SINE, modulation);

        }
        else if (note.Equals("SAW"))
        {
            ChangeSoundWave(temp_tag, DST.WAVEFORM.SAW, modulation);


        }
        else if (note.Equals("PULSE"))
        {

            ChangeSoundWave(temp_tag, DST.WAVEFORM.PULSE, modulation);

        }
        else {

            if (notelist.Contains(note))
            {
                musicFadeOutEnabled = true;
                musicFadeInEnabled = false;

                int temp_oct = System.Int32.Parse(temp_tag);
                soundOn = 1f;



                this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                int i = (temp_oct - 4) * 12;
                //midi_mat.SetFloat("_RimPower", 0f);

                if (note.Equals("C"))
                {

                    SeqTrigger(seq_trigger, 24, i);
                    //if (seq_trigger == 1)
                    //{
                    //    notes.value = pitches[24 + i];
                    //}
                    //else {

                    //    notes.value = pitches[24 + i];

                    //}
                }
                else if (note.Equals("C#"))
                {
                    //notes.value = pitches[25 + i];

                    SeqTrigger(seq_trigger, 25, i);
                }
                else if (note.Equals("D"))
                {
                    //notes.value = pitches[26 + i];

                    SeqTrigger(seq_trigger, 26, i);
                }
                else if (note.Equals("D#"))
                {
                    //notes.value = pitches[27 + i];

                    SeqTrigger(seq_trigger, 27, i);
                }
                else if (note.Equals("E"))
                {
                    //notes.value = pitches[28 + i];

                    SeqTrigger(seq_trigger, 28, i);
                }
                else if (note.Equals("F"))
                {
                    //notes.value = pitches[29 + i];

                    SeqTrigger(seq_trigger, 29, i);
                }
                else if (note.Equals("F#"))
                {
                    //notes.value = pitches[30 + i];

                    SeqTrigger(seq_trigger, 30, i);
                }
                else if (note.Equals("G"))
                {
                    //notes.value = pitches[31 + i];

                    SeqTrigger(seq_trigger, 31, i);
                }
                else if (note.Equals("G#"))
                {
                    //notes.value = pitches[32 + i];


                    SeqTrigger(seq_trigger, 32, i);
                }
                else if (note.Equals("A"))
                {
                    //notes.value = pitches[33 + i];

                    SeqTrigger(seq_trigger, 33, i);
                }
                else if (note.Equals("A#"))
                {
                    //notes.value = pitches[34 + i];

                    SeqTrigger(seq_trigger, 34, i);
                }
                else if (note.Equals("B"))
                {
                    //notes.value = pitches[35 + i];

                    SeqTrigger(seq_trigger, 35, i);
                }
                else if (note.Equals("B#"))
                {
                    //notes.value = pitches[36 + i];

                    SeqTrigger(seq_trigger, 36, i);
                }
                else if (note.Equals("C5"))
                {
                    //notes.value = pitches[37 + i];

                    SeqTrigger(seq_trigger, 37, i);
                }

                if (contacts[0].normal.x != 0)
                {
                    //lowcutoffEnabled = true;
                }


            }
            else if (frqlist.Contains(note))
            {
                if (modulation != null)
                {

                    float frq_val = float.Parse(note);

                    modulation.GetComponent<DST.Constant>().value = frq_val;
                    //midi_mat.SetFloat("_RimPower", 0f);
                }


            }
            else
            {

                if (notes != null){ 
                notes.value = 0.1f;                
                }


            }




        }


    }

    private void SeqTrigger(int seq_trigger, int notes_offset, int i) {
        if (seq_trigger == 1)
        {
            //seq_notes.value = pitches[notes_offset + i];

            //seq_notes.value = 440;



            seq.pitches[seq_step] = notes_offset + 24;
            sc.current_note_offset = notes_offset+i-24;

            //Debug.Log(notes_offset + 24);



        }
        else
        {
            if (notes != null) {

                notes.value = pitches[notes_offset + i];

            }



            //if (sender != null) {

            //    sender.GetComponent<TextMesh>().text =  notes_offset.ToString();
            //    //Debug.Log(notes_offset);

            //}


        }



    }


    private void OnCollisionExit(Collision other)
    {

        soundOn = 0f;
        lowcutoffEnabled = false;
        lowcutoffLimit = false;
        Renderer midi = other.gameObject.GetComponent<Renderer>();
        if (midi != null)
        {
            Material midi_mat = midi.material;
            midi_mat.SetFloat("_RimPower", 10f);
        }



        musicFadeInEnabled = true;
        musicFadeOutEnabled = false;

        //if (notes.value >= 0.1f)
        //{
        //    notes.value -= 1f;

        //}
        //else { 
        //notes.value = 0.1f;        
        //}

        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.clear);


    }

    private void ChangeSoundWave(string tag, DST.WAVEFORM wav, GameObject carrier) {

        if (tag.Equals("osc1"))
        {
            soundcompt.GetComponent<DST.Oscillator>().waveForm = wav;


        }
        else if (tag.Equals("osc2"))
        {
            carrier.GetComponent<DST.Oscillator>().waveForm = wav;

        }


    }

}

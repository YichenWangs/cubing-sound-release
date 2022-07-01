using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;

public class SeqVisual : MonoBehaviour
{

    public GameObject sequencer;
    private DST.Sequencer seq;
    private SequencerControl old_sc;
    private SequencerControl sc;
    private int seq_step;
    private int current_note_offset = 0;


    double[] prev_seq_pitches = new double[] { };
    double[] current_seq_pitches = new double[] { };


    List<GameObject> childObjects = new List<GameObject>();
    private Color32[] color_map = new Color32[] {
    Color.magenta,
    Color.clear,
    Color.blue,
    Color.clear,
    Color.yellow,
    new Color32(152, 235, 110, 255),
    Color.clear,
    Color.red,
    Color.clear,
    new Color32(245, 66, 188, 255),
    Color.clear,
    Color.cyan,
    Color.green,





    };
    // Start is called before the first frame update
    void Start()
    {
        if (sequencer != null)
        {
            seq = sequencer.GetComponent<DST.Sequencer>();
            sc = seq.GetComponent<SequencerControl>();
            seq_step = (int) sc.seq_step;
            prev_seq_pitches = sequencer.GetComponent<DST.Sequencer>().pitches;
            //PrintAll(prev_seq_pitches);
            //print("%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            ColourAllCubes(childObjects, seq.pitches);

        }
       

        Transform[] allChildren = GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            childObjects.Add(child.gameObject);
           
        }

        childObjects.RemoveAt(0);


    }
    // Update is called once per frame
    void Update()
    {
        if (sequencer != null)
        {
            sc = seq.GetComponent<SequencerControl>();
            seq_step = (int) sc.seq_step;
            current_seq_pitches = seq.pitches;

            //Debug.Log(seq_step);
            if (sc.seq_trigger == 1) {

            GameObject prev_cube = childObjects[ seq_step == 0 ? 15 : (seq_step -1)];
            GameObject current_cube = childObjects[seq_step];

            Renderer c_cube = current_cube.gameObject.GetComponent<Renderer>();
            Material ccube_mat = c_cube.material;
            ccube_mat.SetFloat("_RimPower", 0f);
            //current_cube.GetComponent<Renderer>().material.SetColor("_Color", Color.w);

            Renderer p_cube = prev_cube.gameObject.GetComponent<Renderer>();
            Material pcube_mat = p_cube.material;

            pcube_mat.SetFloat("_RimPower", 8f);
                //prev_cube.GetComponent<Renderer>().material.SetColor("_Color", Color.clear);


                ColourAllCubes(childObjects, seq.pitches);
                //PrintAll(prev_seq_pitches);
                //Debug.Log("########################");
                //PrintAll(current_seq_pitches);

                //current_note_offset = sc.current_note_offset;


                //current_cube.GetComponent<Renderer>().material.SetColor("_Color", color_map[current_note_offset]);
                //Debug.Log(current_note_offset);
                //prev_cube.GetComponent<Renderer>().material.SetColor("_Color", Color.clear);
                //prev_cube.GetComponent<Renderer>().material = MRTK

                //print(prev_cube);
                //print(current_cube);
                //for (int i = 0; i < childObjects.Count; i++)
                //{
                //    pr
                //}
            }
        }

    }

    void PrintAll(double[] an_array) {

        string sequence = "";
        //if (an_array != null) {
            for (int i = 0; i < an_array.Length; i++) {
            sequence += an_array[i];
            sequence += ", ";
            
            
            }
        print(sequence);
        
        //}
    
    
    
    
    }

    void ColourAllCubes(List<GameObject> allchildren, double[] seq_pitches) {

        for (int i = 0; i < allchildren.Count; i++) {

            GameObject current_cube = allchildren[i];

            Renderer c_cube = current_cube.gameObject.GetComponent<Renderer>();
            //Material ccube_mat = c_cube.material;
            //ccube_mat.SetFloat("_RimPower", 0f);

            if (c_cube != null) {

                double seq_pitch = seq_pitches[i];
                double temp_pitch = 0;
                //Debug.Log(temp_pitch);
                if (seq_pitch - 48 >= 0 && seq_pitch - 48 < 13)
                {

                    temp_pitch = seq_pitch - 48;
                }
                else if (seq_pitch - 48 < 0 && seq_pitch - 48 >= -13)
                {

                    temp_pitch = 13 - Math.Abs(seq_pitch - 48);

                }
                else if (seq_pitch - 48 > 13 && seq_pitch - 48 <= 26)
                {

                    temp_pitch = seq_pitch - 61;


                }
                else if (seq_pitch - 48 == 13) {

                    temp_pitch =12;
                }



            c_cube.GetComponent<Renderer>().material.SetColor("_Color", color_map[(int) ((temp_pitch))]);         
            }

        }




    }
}

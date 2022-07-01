using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFq: MonoBehaviour
{
    private float scale_x;
    private float scale_y;
    private float scale_z;
    private float scale_sum;
    private float[] notes_white = new float[] { 130.81f, 146.83f, 164.81f, 174.61f, 196f, 220f, 246.94f, 261.63f  };



    private double update_y;
    private GameObject currentobj;
    private DST.Constant current_constant;
    private DST.LFO current_LFO;
    private DST.Sequencer current_seq;
    private DST.AudioSink current_sink;


    // Start is called before the first frame update
    void Start()
    {
        currentobj = this.gameObject;
        current_constant = currentobj.GetComponent<DST.Constant>();
        current_LFO = currentobj.GetComponent<DST.LFO>();
        current_seq = currentobj.GetComponent<DST.Sequencer>();
        current_sink = currentobj.GetComponent<DST.AudioSink>();
        //print(current_constant.value);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_pos = transform.position;
        //print(current_pos);

        int idx = (int) (Mathf.Floor(current_pos.y * 10F)) % 8;
        update_y = notes_white[idx];

        print(idx);

        current_constant.value = update_y;
        current_LFO.frequency = current_pos.x;

        scale_x = currentobj.transform.localScale.x;
        scale_y = currentobj.transform.localScale.y;
        scale_z = currentobj.transform.localScale.z;

        float temp_sum = scale_x * scale_x + scale_y * scale_y + scale_z * scale_z;


        scale_sum = Mathf.Sqrt(temp_sum);

        float normalised_sum_vol = scale_sum;
        //current_sink.gain = normalised_sum_vol;

        //print(scale_sum);

        //print(normalised_sum_vol);

        double[] current_seq_durations = current_seq.durations;
        current_seq_durations[0] = currentobj.transform.rotation.x+1.5;
        current_seq_durations[1] = currentobj.transform.rotation.y;
        current_seq_durations[2] = currentobj.transform.rotation.z+1;
        current_seq_durations[3] = (currentobj.transform.rotation.x +currentobj.transform.rotation.y + currentobj.transform.rotation.z)/3;


        //print(currentobj.transform.rotation.x);
        //print(currentobj.transform.rotation.y);
        //print(currentobj.transform.rotation.z);

        //for (int i = 0; i< current_seq_durations.Length; i++)
        //{
        //    current_seq_durations[i] = currentobj.transform.rotation.x; + 
        //}
        //print("constant value is " + current_constant.value);

    }
}

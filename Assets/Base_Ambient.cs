using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Ambient : MonoBehaviour
{

    private float scale_x;
    private float scale_y;
    private float scale_z;
    private float scale_sum;
    private float[] notes_white = new float[] { 130.81f, 146.83f, 164.81f, 174.61f, 196f, 220f, 246.94f, 261.63f };


    private GameObject currentobj;
    private DST.Constant current_constant;
    private DST.LFO current_LFO;
    //private DST.AudioSink current_sink;

    private DST.VCA current_vca;

    // Start is called before the first frame update
    void Start()
    {
        currentobj = this.gameObject;
        current_constant = currentobj.GetComponent<DST.Constant>();
        current_LFO = currentobj.GetComponent<DST.LFO>();
        current_vca = currentobj.GetComponent<DST.VCA>();

    }

    // Update is called once per frame
    void Update()
    {

        if (currentobj != null) { 
        
        Vector3 current_pos = currentobj.transform.position;
        //current_constant.value = current_pos.y * 1000f;
        current_LFO.pulseWidth = Mathf.Abs(current_pos.x);
        //current_LFO.frequency = 1 - Mathf.Abs(current_pos.z);

        scale_x = currentobj.transform.localScale.x;
        scale_y = currentobj.transform.localScale.y;
        scale_z = currentobj.transform.localScale.z;

        int idx = (int)(Mathf.Floor(Mathf.Abs(current_pos.y) * 10F)+1) % 8;

        current_constant.value = notes_white[idx];




        float temp_sum = scale_x * scale_x + scale_y * scale_y + scale_z * scale_z;
        scale_sum = Mathf.Sqrt(temp_sum);

        float normalised_sum_vol = scale_sum ;

        //print(normalised_sum_vol);
        current_vca.amp = normalised_sum_vol;
        
        }


    }
}

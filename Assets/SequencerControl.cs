using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerControl : MonoBehaviour
{
    public DST.Sequencer seq;
    public DST.VCA seq_vca;

    public int seq_trigger;
    public long seq_step;

    public int current_note_offset;

    // Start is called before the first frame update
    void Start()
    {
        seq_trigger = 0;
        
        seq.durations = new double[] { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 };




        seq.pitches = new double[] { 0, 0, 0, 0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 };



    }

    // Update is called once per frame
    void Update()
    {
        TriggerSequencer();
        //Debug.Log(seq.stepNumber);
        //Debug.Log("###################");
        //Debug.Log(seq.countDown);

        seq_step = GetStepNum();
    }

    private void TriggerSequencer() {

        if (seq_trigger == 1)
        {
            seq_vca.amp = 2;

        }
        else {

            seq_vca.amp = 0;
        }
    
    
    
    }

    public long GetStepNum() {
        long step_num = seq.stepNumber % 16;

        //print(step_num);

        return step_num;
    }


}

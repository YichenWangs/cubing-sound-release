using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteToFreq : MonoBehaviour
{
    public GameObject hand;
    private GameObject indexR;
    private GameObject indexL;
    //public GameObject indexL;
    public float indexR_freq ;
    public float indexR_soundOn;
    public float indexL_freq;
    public float indexL_soundOn;
    // Start is called before the first frame update
    void Start()
    {

        indexR = hand.GetComponent<HandTracking>().indexRObject;

        if (indexR != null && indexR.GetComponent<ClashFinger>().notes !=null) {
            indexR_freq = (float) indexR.GetComponent<ClashFinger>().notes.value;


            indexR_soundOn = indexR.GetComponent<ClashFinger>().soundOn;
        }

        indexL = hand.GetComponent<HandTracking>().indexLObject;

        if (indexL != null && indexL.GetComponent<ClashFinger>().notes != null)
        {
            indexL_freq = (float) indexL.GetComponent<ClashFinger>().notes.value;


            indexL_soundOn = indexL.GetComponent<ClashFinger>().soundOn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        indexR = hand.GetComponent<HandTracking>().indexRObject;
        indexR_soundOn = indexR.GetComponent<ClashFinger>().soundOn;

        indexL = hand.GetComponent<HandTracking>().indexLObject;
        indexL_soundOn = indexL.GetComponent<ClashFinger>().soundOn;

        if (indexR_soundOn == 1f)
        {
            indexR_freq = (float) indexR.GetComponent<ClashFinger>().notes.value;

        }

        if (indexL_soundOn == 1f)
        {
            indexL_freq = (float) indexL.GetComponent<ClashFinger>().notes.value;

        }
    }


}

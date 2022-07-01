using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class ChangeValue : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject currentobj;
    private DST.Oscillator current_osc;

    private DST.Constant current_constant;

    private DST.Envelope current_Envelope;

    private DST.Filter current_Filter;

    //Sudio conponents 
    public GameObject osc;
    public GameObject osc2;
    public GameObject osc1_gain;

    public GameObject enve_attack;
    public GameObject enve_decay;
    public GameObject enve_sustain;
    public GameObject enve_release;

    public GameObject filter_CUTTOFF;
    public GameObject filter_Res;


    public GameObject vca_3;
    public GameObject vca_1;
    public GameObject vca_2;


    //Sliders
    private float osc_sliderValue;
    private float osc1_sliderValue;
    private float enve_attack_sliderValue;
    private float enve_decay_sliderValue;
    private float enve_sustain_sliderValue;
    private float enve_release_sliderValue;

    private float filter_cutoff_sliderValue;
    private float filter_res_sliderValue;

    private float vca_3_sliderValue;
    private float vca_1_sliderValue;
    private float vca_2_sliderValue;

    private DST.VCA[] vcas;


    void Start()
    {

        currentobj = this.gameObject;


        current_osc = currentobj.GetComponent<DST.Oscillator>();
        current_constant = currentobj.GetComponent<DST.Constant>();
        current_Envelope = currentobj.GetComponent<DST.Envelope>();
        current_Filter = currentobj.GetComponent<DST.Filter>();

        current_constant.value = 1;

        osc_sliderValue = osc.GetComponent<PinchSlider>().SliderValue;
        osc1_sliderValue = osc1_gain.GetComponent<PinchSlider>().SliderValue;



        enve_attack_sliderValue = enve_attack.GetComponent<PinchSlider>().SliderValue;
        enve_decay_sliderValue = enve_decay.GetComponent<PinchSlider>().SliderValue;
        enve_sustain_sliderValue = enve_sustain.GetComponent<PinchSlider>().SliderValue;
        enve_release_sliderValue = enve_release.GetComponent<PinchSlider>().SliderValue;

        filter_cutoff_sliderValue = filter_CUTTOFF.GetComponent<PinchSlider>().SliderValue;

        filter_res_sliderValue = filter_Res.GetComponent<PinchSlider>().SliderValue;

        vca_1_sliderValue = vca_1.GetComponent<PinchSlider>().SliderValue;
        vca_2_sliderValue = vca_2.GetComponent<PinchSlider>().SliderValue;
        vca_3_sliderValue = vca_3.GetComponent<PinchSlider>().SliderValue;

        if (currentobj.GetComponents<DST.VCA>() != null) {
            vcas = currentobj.GetComponents<DST.VCA>();
            //print(vcas.Length);
        }
    }

    // Update is called once per frame
    void Update()
    {

        osc_sliderValue = osc.GetComponent<PinchSlider>().SliderValue;
        osc1_sliderValue = osc1_gain.GetComponent<PinchSlider>().SliderValue;


        enve_attack_sliderValue = enve_attack.GetComponent<PinchSlider>().SliderValue;
        enve_decay_sliderValue = enve_decay.GetComponent<PinchSlider>().SliderValue;
        enve_sustain_sliderValue = enve_sustain.GetComponent<PinchSlider>().SliderValue;
        enve_release_sliderValue = enve_release.GetComponent<PinchSlider>().SliderValue;
        
        filter_cutoff_sliderValue = filter_CUTTOFF.GetComponent<PinchSlider>().SliderValue;

        filter_res_sliderValue = filter_Res.GetComponent<PinchSlider>().SliderValue;

        vca_1_sliderValue = vca_1.GetComponent<PinchSlider>().SliderValue;
        vca_2_sliderValue = vca_2.GetComponent<PinchSlider>().SliderValue;
        vca_3_sliderValue = vca_3.GetComponent<PinchSlider>().SliderValue;

        if (currentobj.GetComponents<DST.VCA>() != null)
        {
            vcas = currentobj.GetComponents<DST.VCA>();
        }

    }

    public void Change_Frequency()
    {
        double temp = System.Math.Round(osc_sliderValue, 3, System.MidpointRounding.AwayFromZero);

        current_constant.value = temp * 1000f;

        //print(temp);




    }

    public void Change_OSC1()
    {
        current_osc.gain = osc1_sliderValue;

        //print(temp);




    }

    public void Change_Envelope()
    {
        //current_Envelope.attack = enve_a
        current_Envelope.attack = System.Math.Round(enve_attack_sliderValue, 2, System.MidpointRounding.AwayFromZero) * 100f;
        current_Envelope.decay = System.Math.Round(enve_decay_sliderValue, 2, System.MidpointRounding.AwayFromZero) * 100f;
        current_Envelope.sustain = System.Math.Round(enve_sustain_sliderValue, 2, System.MidpointRounding.AwayFromZero) * 10f; 
        current_Envelope.release = System.Math.Round(enve_release_sliderValue, 3, System.MidpointRounding.AwayFromZero) * 1000f;





    }
    public void Change_FilterTypeLOW() {
        current_Filter.filterType = (DST.Filter.FilterType)System.Enum.Parse(typeof(DST.Filter.FilterType), "LOW");
        //print(filter_button.name);
        print(current_Filter.filterType);

    
    }
    public void Change_FilterTypeHIGH()
    {
        current_Filter.filterType = (DST.Filter.FilterType)System.Enum.Parse(typeof(DST.Filter.FilterType), "HIGH");
        //print(filter_button.name);
        print(current_Filter.filterType);
    }
    public void Change_FilterTypeBAND()
    {
        current_Filter.filterType = (DST.Filter.FilterType)System.Enum.Parse(typeof(DST.Filter.FilterType), "BAND");
        //print(filter_button.name);
        print(current_Filter.filterType);
    }
    public void Change_FilterTypeNOTCH()
    {
        current_Filter.filterType = (DST.Filter.FilterType)System.Enum.Parse(typeof(DST.Filter.FilterType), "NOTCH");
        //print(filter_button.name);
        print(current_Filter.filterType);

    }
    public void Change_FilterTypePEAK()
    {
        current_Filter.filterType = (DST.Filter.FilterType)System.Enum.Parse(typeof(DST.Filter.FilterType), "PEAK");
        //print(filter_button.name);
        print(current_Filter.filterType);

    }
    public void Change_FilterTypeALLPASS()
    {
        current_Filter.filterType = (DST.Filter.FilterType)System.Enum.Parse(typeof(DST.Filter.FilterType), "ALLPASS");
        //print(filter_button.name);
        print(current_Filter.filterType);

    }


    public void Change_FilterCUTOFF()
    {
        current_Filter.cutoff = (filter_cutoff_sliderValue) /1 * 20000f;
    }

    public void Change_FilterRes()
    {
        current_Filter.resonance = filter_res_sliderValue;
    }

    public void Change_OSCSIN()
    {
        current_osc.waveForm = DST.WAVEFORM.SINE;
    }
    public void Change_OSCSAW()
    {
        current_osc.waveForm = DST.WAVEFORM.SAW;
    }
    public void Change_OSCPULSE()
    {
        current_osc.waveForm = DST.WAVEFORM.PULSE;
    }

    public void Change_VCA()
    {
        if (vcas.Length != 0)
        {
            //    print(vcas);
            string[] vcaids = new string[vcas.Length];
        for (int i = 0; i < vcas.Length; i++)
        {
            vcaids[i] = vcas[i].AUID;
        }


        for (int i = 0; i < vcaids.Length; i++)
        {
            string temp = vcaids[i];

                //print(temp);
         if (System.String.Equals(temp, "3"))
                {

                    vcas[0].amp = vca_1_sliderValue;
                }
         if (System.String.Equals(temp,"1"))
            {

                vcas[1].amp = vca_2_sliderValue;
            }
            if (System.String.Equals(temp, "2"))
            {


                vcas[2].amp = vca_3_sliderValue;
            }
        }
        }
    }

}

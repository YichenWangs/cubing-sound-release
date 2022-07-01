using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMSyn : MonoBehaviour
{

    public GameObject carrier;
    public GameObject modulation;
    // Start is called before the first frame update

    private DST.Constant c_cons;
    private DST.Constant m_cons;


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
    1975.53
    };

    private int r;

    float interval;
    float nextTime = 0;
    float sec = 1;
    void Start()
    {
        carrier = this.gameObject;

        c_cons = carrier.GetComponent<DST.Constant>();
        m_cons = modulation.GetComponent<DST.Constant>();

        interval = (float)(1 / (2 * carrier.GetComponent<DST.LFO>().frequency));

        sec = (float)carrier.GetComponent<DST.Sequencer>().durations[0];
        interval = sec;






    }

    // Update is called once per frame
    void Update()
    {
        sec = (float)carrier.GetComponent<DST.Sequencer>().durations[0];

        interval = sec;


        if (Time.time >= nextTime)
        {



            //do something here every interval seconds
            r = Random.Range(0, pitches.Length);
            double temp = pitches[r];

            c_cons.value = temp;
            m_cons.value = temp / 10;

            nextTime += interval;

            //print(interval);

        }
    
    
    }



        
    }


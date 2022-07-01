using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waveform : MonoBehaviour
{
    public GameObject the_soundSource;
    AudioSource the_audioSource;
    public GameObject the_pfCube;
    public GameObject[] cubes = new GameObject[1024];

    public float radius;

    public float x_pos;

    public float[] the_waveform = new float[1024];
    float[] wf;

    // Start is called before the first frame update
    void Start()
    {

        the_audioSource = the_soundSource.GetComponent<AudioSource>();
        //print(the_audioSource);


        float x = x_pos, y = 0, z = 0;

        float xIncreament = the_pfCube.transform.localScale.x;
        float anglesIncreament = (Mathf.PI * 2) / 1024;


        for (int i = 0; i < cubes.Length; i++) {
            GameObject go = Instantiate(the_pfCube);

            go.transform.position = new Vector3(x, y, z);
            //x += xIncreament;
            x = radius * Mathf.Sin(anglesIncreament * i);
            z = radius * Mathf.Cos(anglesIncreament * i);
            
            go.name = "cube" + i;
            go.transform.parent = this.transform;
            cubes[i] = go;
        
        }
        the_audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        the_audioSource.GetOutputData(the_waveform, 0);
        wf = the_waveform;

        //print(the_audioSource);
        //print(the_waveform);

        for (int i = 0; i < cubes.Length; i++) {
            cubes[i].transform.localPosition =
                new Vector3(cubes[i].transform.localPosition.x,
                100 * wf[i],
                cubes[i].transform.localPosition.z);

            
        
        
        }

        //if (System.Math.Round(cubes[0].transform.position.y, 3).Equals(0)) {
        //    print(System.Math.Round(cubes[0].transform.position.y, 3));

        //}


        //float temp = wf[wf.Length / 2];
        //if (System.Math.Abs(temp) < 0.00001) {
        //    print("frequenc!");
        //    print(System.Math.Abs(temp));
        //    print(temp);

        //}


    }
}

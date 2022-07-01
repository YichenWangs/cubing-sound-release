using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Rendering;

public class MultiVisual : MonoBehaviour
{
    List<GameObject> childObjects = new List<GameObject>();
    List<GameObject> inCollisionCubes = new List<GameObject>();
    List<GameObject> temp_obj = new List<GameObject>();
    GameObject connection;

    public GameObject the_soundSource;
    AudioSource the_audioSource;
    public float[] the_waveform = new float[1024];
    float[] wf;
    // Start is called before the first frame update
    void Start()
    {
        the_audioSource = the_soundSource.GetComponent<AudioSource>();

        Transform[] allChildren = GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            childObjects.Add(child.gameObject);

        }

        //childObjects.RemoveAt(0);
        //Debug.Log(childObjects.Count);
        //for (int i = 0; i < childObjects.Count; i++)
        //{
        //    //Debug.Log(childObjects[i]);


        //}

        the_audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Transform[] allChildren = GetComponentsInChildren<Transform>();

        //foreach (Transform child in allChildren)
        //{
        //    childObjects.Add(child.gameObject);

        //}

        //childObjects.RemoveAt(0);

        the_audioSource.GetOutputData(the_waveform, 0);
        wf = the_waveform;


        for (int i = 0; i < childObjects.Count; i++)
        {
            //Debug.Log(childObjects[i]);

            ClashedCube temp_collide_compt = childObjects[i].GetComponent<ClashedCube>();
            if (temp_collide_compt != null) {

                if ((temp_collide_compt.collide_state == 1) && !inCollisionCubes.Contains(childObjects[i]))
                {

                    inCollisionCubes.Add(childObjects[i]);

                }
                else if (temp_collide_compt.collide_state == 0 && inCollisionCubes.Contains(childObjects[i])) {


                    Destroy(connection);
                    inCollisionCubes.Remove(childObjects[i]);
                    //temp_obj.Clear();

                }

            }


            


        }
        //Debug.Log(childObjects.Count);
        //Debug.Log("#####################################");
        //Debug.Log(inCollisionCubes.Count);

        //for (int i = 0; i < inCollisionCubes.Count; i++)
        //{
        //    Debug.Log(inCollisionCubes[i]);
        //}



        setVisConnection(inCollisionCubes);

        if (temp_obj != null)
        {
            int range = temp_obj.Count < wf.Length ? temp_obj.Count : wf.Length;

            //Debug.Log("######################");
            //Debug.Log(l.Count);
            //Debug.Log(wf.Length);
            //Debug.Log(range);



            for (int i = 0; i < range; i++)
            {
                if (temp_obj[i] != null)
                {


                    //Debug.Log(temp_obj[i].transform.position.y);
                    //Debug.Log("#######################");
                    //Debug.Log(wf[i]/50);

                    //Vector3 p = temp_obj[i].transform.localPosition;
                    //p.x = temp_obj[i].transform.localPosition.x;
                    //p.y += wf[i] / 50;
                    //p.z = temp_obj[i].transform.localPosition.z;

                    //temp_obj[i].transform.localPosition = p;

                    temp_obj[i].transform.localPosition = new Vector3(temp_obj[i].transform.localPosition.x,
                      temp_obj[i].transform.localPosition.y + wf[i] / 50,
                    temp_obj[i].transform.localPosition.z);

                }


            }
        }

        //else
        //{

        //    for (int i = 0; i < temp_obj.Count; i++)
        //    {
        //        Destroy(temp_obj[i]);
        //    }

        //    //temp_obj.Clear();
        //}




    }

    void setVisConnection(List<GameObject> incollisionCubes) {

        List<Vector3> x_pos = new List<Vector3>();
        Vector3 temp;
        List<double> y_pos = new List<double>();
        List<double> z_pos = new List<double>();
        //for (int i = 0; i < inCollisionCubes.Count; i++) {
        //    x_pos.Add(inCollisionCubes[i].transform.position);

        //}



        //if (incollisionCubes.Count < 2)
        //{
        //    for (int i = 0; i < temp_obj.Count; i++)
        //    {
        //        Destroy(temp_obj[i]);
        //    }

        //    //temp_obj.Clear();


        //}
        //else 

        if (inCollisionCubes.Count == 2)
        {

            Vector3 point_one = inCollisionCubes[0].transform.position;
            Vector3 point_two = inCollisionCubes[1].transform.position;


            float a = 0;
            float b = 0;

            float v_two_x = inCollisionCubes[1].transform.position.x;
            float v_one_x = inCollisionCubes[0].transform.position.x;
            float z = inCollisionCubes[1].transform.position.z;

            float v_two_z = inCollisionCubes[1].transform.position.z;
            float v_one_z = inCollisionCubes[0].transform.position.z;

            float radius = Mathf.Sqrt(Mathf.Abs(v_one_x * v_one_x) + Mathf.Abs(v_one_z * v_one_z));
            Vector3 point_base = new Vector3(0f, point_one.y, -radius);

            float angle = Vector3.Angle(point_one, point_two);
            float angle_one = Vector3.Angle(point_base, point_one);
            float angle_two = Vector3.Angle(point_base, point_two);

            GameObject reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            reference.transform.position = point_base;

            reference.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

            if (v_one_x < v_two_x)
            {
                //Debug.Log("the first if");
                a = (v_two_z - v_one_z) / (v_two_x - v_one_x);
                b = v_one_z - a * v_one_x;


                for (float i = v_one_x; i < v_two_x; i += 0.001f)
                {
                    connection = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    connection.transform.position = new Vector3(i, point_one.y, i * a + b);
                    connection.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
                    Material mat = Resources.Load("Assets / MRTK / Examples / StandardAssets / Materials / StencilPortalFrame.mat", typeof(Material)) as Material;

                    connection.GetComponent<Renderer>().material = mat;

                    connection.GetComponent<Renderer>().material.color = new Color32(152, 235, 110, 255);
                    temp_obj.Add(connection);




                }


            }
            else
            {
                //Debug.Log("the second if");

                a = (v_one_z - v_two_z) / (v_one_x - v_two_x);
                b = v_one_z - a * v_one_x;


                for (float i = v_two_x; i < v_one_x; i += 0.001f)
                {
                    connection = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    connection.transform.position = new Vector3(i, point_one.y, i * a + b);
                    connection.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
                    Material mat = Resources.Load("Assets / MRTK / Examples / StandardAssets / Materials / StencilPortalFrame.mat", typeof(Material)) as Material;

                    connection.GetComponent<Renderer>().material = mat;
                    connection.GetComponent<Renderer>().material.color = new Color32(152, 235, 110, 255);
                    temp_obj.Add(connection);

                }

            }

        }
        //else if(inCollisionCubes.Count <1)
        else
        {

            for (int i = 0; i < temp_obj.Count; i++)
            {
                Destroy(temp_obj[i]);
                temp_obj.RemoveAt(i);

            }

            //temp_obj.Clear();
        }


        //return temp_obj;


    }
    }

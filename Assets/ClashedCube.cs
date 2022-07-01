using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClashedCube : MonoBehaviour
{

    public int collide_state;
    // Start is called before the first frame update
    void Start()
    {
        collide_state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {

        collide_state = 1;



    }

    //private void OnCollisionStay(Collision other)
    //{

    //    collide_state = 1;
    //}

    private void OnCollisionExit(Collision other)
    {

        collide_state = 0;



    }
}

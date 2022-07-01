using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        List<DST.Filter> filters = new List<DST.Filter>();

        GetComponents(filters);

        //print(filters.Count) ;

    }
}

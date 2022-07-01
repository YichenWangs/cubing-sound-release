using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToInt : MonoBehaviour
{
    public TextMesh text;
    public int int_form;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            int_form = System.Int32.Parse(text.text);

        }
    }

}

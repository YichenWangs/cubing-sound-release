using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class checkOnClick : MonoBehaviour
{
    public int id;
    public GameObject osc1;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;

    bool bt1, bt2, bt3, bt4, bt5 = false;
    // Start is called before the first frame update
    void Start()
    {
        bt1 = button1.GetComponent<Interactable>().IsToggled;
        bt2 = button2.GetComponent<Interactable>().IsToggled;
        bt3 = button3.GetComponent<Interactable>().IsToggled;
        bt4 = button4.GetComponent<Interactable>().IsToggled;
        bt5 = button5.GetComponent<Interactable>().IsToggled;

    }

    // Update is called once per frame
    void Update()
    {

        bt1 = button1.GetComponent<Interactable>().IsToggled;
        bt2 = button2.GetComponent<Interactable>().IsToggled;
        bt3 = button3.GetComponent<Interactable>().IsToggled;
        bt4 = button4.GetComponent<Interactable>().IsToggled;
        bt5 = button5.GetComponent<Interactable>().IsToggled;
        //print(bt1 + "button 1");

        //print(this.gameObject.GetComponent<Interactable>().IsToggled);
        //print(button1.GetComponent<Interactable>().IsToggled);
        if (this.gameObject.GetComponent<Interactable>().IsToggled)
        {


            if (bt1)
            {

                button1.GetComponent<Interactable>().TriggerOnClick();
                print(bt1 + "in");

                if (id == 1)
                {
                    print("Low");
                    osc1.GetComponent<ChangeValue>().Change_FilterTypeLOW();

                }
                else if (id == 2)
                {
                    print("high");
                    osc1.GetComponent<ChangeValue>().Change_FilterTypeHIGH();
                }


            }
            else {
                this.gameObject.GetComponent<Interactable>().TriggerOnClick();
                if (id == 1)
                {
                    print("not other Low");
                    osc1.GetComponent<ChangeValue>().Change_FilterTypeLOW();

                }
                else if (id == 2)
                {
                    print("not other high");
                    osc1.GetComponent<ChangeValue>().Change_FilterTypeHIGH();
                }






            }
        }
    }
}

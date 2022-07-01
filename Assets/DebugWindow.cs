using UnityEngine;

public class DebugWindow : MonoBehaviour
{
    TextMesh textMesh;


    // Use this for initialization
    void Start()
    {
        textMesh = gameObject.GetComponentInChildren<TextMesh>();
    }

    void OnEnable()
    {

            Application.logMessageReceived += LogMessage;

            
    }

    void OnDisable()
    {

            Application.logMessageReceived -= LogMessage;
        
    }

    float interval = 3;
    float nextTime = 0;
    public void LogMessage(string message, string stackTrace, LogType type)
    {



        if (textMesh.text.Length > 300)
            {
                textMesh.text = message + "\n";
            }
            else
            {
                textMesh.text += message + "\n";
            }




    }
}
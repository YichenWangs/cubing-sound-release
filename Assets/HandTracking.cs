using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using TMPro;

public class HandTracking : MonoBehaviour
{

    //public GameObject sphereMarker;
    public GameObject thumbL;
    public GameObject indexL;
    public GameObject middleL;
    public GameObject ringL;
    public GameObject pinkyL;

    public GameObject palm;

    public GameObject thumbR;
    public GameObject indexR;
    public GameObject middleR;
    public GameObject ringR;
    public GameObject pinkyR;


    GameObject thumbLObject;
    public GameObject indexLObject;
    GameObject middleLObject;
    GameObject ringLObject;
    GameObject pinkyLObject;
    GameObject palmObject;

    GameObject thumbRObject;
    public GameObject indexRObject;
    GameObject middleRObject;
    GameObject ringRObject;
    GameObject pinkyRObject;


    MixedRealityPose pose;

    void Start()
    {
        thumbLObject = Instantiate(thumbL, this.transform);
        indexLObject = Instantiate(indexL, this.transform);
        middleLObject = Instantiate(middleL, this.transform);
        ringLObject = Instantiate(ringL, this.transform);
        pinkyLObject = Instantiate(pinkyL, this.transform);


        palmObject = Instantiate(palm, this.transform);

        thumbRObject = Instantiate(thumbR, this.transform);
        indexRObject = Instantiate(indexR, this.transform);
        middleRObject = Instantiate(middleR, this.transform);
        ringRObject = Instantiate(ringR, this.transform);
        pinkyRObject = Instantiate(pinkyR, this.transform);


    }

    void Update()
    {

        thumbLObject.GetComponent<Renderer>().enabled = false;
        indexLObject.GetComponent<Renderer>().enabled = false;
        middleLObject.GetComponent<Renderer>().enabled = false;
        ringLObject.GetComponent<Renderer>().enabled = false;
        pinkyLObject.GetComponent<Renderer>().enabled = false;
        palmObject.GetComponent<Renderer>().enabled = false;


        thumbRObject.GetComponent<Renderer>().enabled = false;
        indexRObject.GetComponent<Renderer>().enabled = false;
        middleRObject.GetComponent<Renderer>().enabled = false;
        ringRObject.GetComponent<Renderer>().enabled = false;
        pinkyRObject.GetComponent<Renderer>().enabled = false;


        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Left, out pose))
        {
            thumbLObject.GetComponent<Renderer>().enabled = true;
            thumbLObject.transform.position = pose.Position;
            //Debug.Log("thumbObject" + pose.Position); 
            //Debug.Log("thumbObject Rotation" + pose.Rotation.eulerAngles);
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out pose))
        {
            indexLObject.GetComponent<Renderer>().enabled = true;
            indexLObject.transform.position = pose.Position;
            //Debug.Log("indexObject" + pose.Position);

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Left, out pose))
        {

            middleLObject.GetComponent<Renderer>().enabled = true;
            middleLObject.transform.position = pose.Position;
            //Debug.Log("middleObject" + pose.Position);

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Left, out pose))
        {
            ringLObject.GetComponent<Renderer>().enabled = true;
            ringLObject.transform.position = pose.Position;
            //Debug.Log("ringObject" + pose.Position);

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Left, out pose))
        {
            pinkyLObject.GetComponent<Renderer>().enabled = true;
            pinkyLObject.transform.position = pose.Position;
            //Debug.Log("pinkyObject" + pose.Position);

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            thumbRObject.GetComponent<Renderer>().enabled = true;
            thumbRObject.transform.position = pose.Position;
            //Debug.Log("thumbObject" + pose.Position); 
            //Debug.Log("thumbObject Rotation" + pose.Rotation.eulerAngles);
        }


        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, Handedness.Left, out pose))
        {
            palmObject.GetComponent<Renderer>().enabled = true;
            palmObject.transform.position = pose.Position;
            //Debug.Log("pinkyObject" + pose.Position);

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Right, out pose))
        {
            indexRObject.GetComponent<Renderer>().enabled = true;
            indexRObject.transform.position = pose.Position;
            //Debug.Log("pinkyObject" + pose.Position);

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))

        {
            middleRObject.GetComponent<Renderer>().enabled = true;
            middleRObject.transform.position = pose.Position;
            //Debug.Log("pinkyObject" + pose.Position);

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out pose))
        {
            ringRObject.GetComponent<Renderer>().enabled = true;
            ringRObject.transform.position = pose.Position;
            //Debug.Log("pinkyObject" + pose.Position);

        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out pose))
        {
            pinkyRObject.GetComponent<Renderer>().enabled = true;
            pinkyRObject.transform.position = pose.Position;
            //Debug.Log("pinkyObject" + pose.Position);

        }

    }
}
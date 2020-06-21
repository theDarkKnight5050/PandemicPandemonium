/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.Globalization;

public class VirusBehaviour : MonoBehaviour
{
    private float POS_FACTOR;

    [HideInInspector]
    public Entry entry;

    private Vector3 initialObjectPosition;
    private Vector3 myDisplacement;
    private Collider myCollider;

    // Use this for initialization
    void Start() {
        // Add RemoteTransformations script to object and set its entry
        POS_FACTOR = this.gameObject.transform.parent.transform.localScale.magnitude;
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        try {
            initialObjectPosition = this.gameObject.transform.position;
            myDisplacement = Vector3.zero;
            Debug.Log("Init Position: " + initialObjectPosition);
        } catch (System.Exception e) {
            Debug.Log(e);
        }

        // Get init position from database
        string value = "";
        if (entry.getAdditionalData().TryGetValue("x", out value))
        {
            initialObjectPosition.x = float.Parse(value, CultureInfo.InvariantCulture);
        }
        if (entry.getAdditionalData().TryGetValue("y", out value))
        {
            initialObjectPosition.y = float.Parse(value, CultureInfo.InvariantCulture);
        }
        if (entry.getAdditionalData().TryGetValue("z", out value))
        {
            initialObjectPosition.z = float.Parse(value, CultureInfo.InvariantCulture);
        }
        Debug.Log("Remote Position: " + initialObjectPosition);
    }

    // Update is called once per frame
    void Update() {
        Vector3 positionOffest = Vector3.zero;
        positionOffest.y += 0.001f;
        
        myDisplacement += positionOffest * POS_FACTOR;
        this.gameObject.transform.position = initialObjectPosition + myDisplacement;
    }
}
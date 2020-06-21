﻿/**************************************************************************
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
    private float speed = 0.005f;
    private float POS_FACTOR;
    private const float END = 10f;
    private enum Stage : int {
        l1 = 1000,
        l2 = 500,
        l3 = 100
    }

    [HideInInspector]
    public Entry entry;

    private bool isSpawned;
    private Vector3 initialObjectPosition;
    private Vector3 myDisplacement;
    private Collider myCollider;

    // Use this for initialization
    void Start() {
        // Add RemoteTransformations script to object and set its entry
        POS_FACTOR = this.gameObject.transform.parent.transform.localScale.magnitude;
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;
        isSpawned = (Random.Range(0, 100) < 5);

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
        float level = (float)Stage.l2;
        if (isSpawned) {
            Vector3 positionOffest = Vector3.zero;
            positionOffest.z += speed;
            
            myDisplacement += positionOffest * POS_FACTOR;
            if (myDisplacement.z >= END) {
                myDisplacement = Vector3.zero;
                isSpawned = !isSpawned;
            }
            this.gameObject.transform.position = initialObjectPosition + myDisplacement;
        } else if (Random.Range(0, level) < 1) {
            isSpawned = !isSpawned;
            speed = Random.Range(1 / level, 5 / level);
        }
    }
}
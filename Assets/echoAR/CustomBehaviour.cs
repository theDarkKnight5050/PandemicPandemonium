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

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>
    private Vector3 initialObjectPosition;
    private Quaternion initialWorldSpaceRotation;

    // Use this for initialization
    void Start() {
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value)) {
            // Set name
            this.gameObject.name = value;
            initialWorldSpaceRotation = this.gameObject.transform.rotation;
        }

        try {
            float positionFactor = 1f;
            initialObjectPosition = (this.gameObject.transform.parent) ? this.gameObject.transform.parent.transform.position : this.gameObject.transform.position;
            Debug.Log(initialObjectPosition);
        } catch (System.Exception e) {
            Debug.Log(e);
        }
    }

    // Update is called once per frame
    void Update() {
        float positionFactor = 1f;
        Vector3 positionOffest = Vector3.zero;
        positionOffest.y += 0.0001f;
        
        this.gameObject.transform.position = initialObjectPosition + positionOffest * positionFactor;
        initialObjectPosition = this.gameObject.transform.position;
        
        // // Handle rotation
        // string value = "";
        // float offset = 0;
        // Quaternion targetQuaternion = initialWorldSpaceRotation;
        // float x = 0, y = 0, z = 0;
        
        // if (entry.getAdditionalData().TryGetValue("xAngle", out value))
        // {
        //     x = float.Parse(value, CultureInfo.InvariantCulture);

        // }
        // if (entry.getAdditionalData().TryGetValue("yAngle", out value))
        // {
        //     y = float.Parse(value, CultureInfo.InvariantCulture);
        // }
        // if (entry.getAdditionalData().TryGetValue("zAngle", out value))
        // {
        //     z = float.Parse(value, CultureInfo.InvariantCulture);
        // }
        // this.gameObject.transform.rotation = Quaternion.Euler(x, y + offset, z);
    }
}
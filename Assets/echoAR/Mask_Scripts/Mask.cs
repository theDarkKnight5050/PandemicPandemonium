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

public class Mask : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;
    private Vector3 initialObjectPosition;
    private Vector3 myDisplacement;
    private Collider myCollider;
    private float moveSpeed = 10.0f; 

    // Use this for initialization
    void Start() {
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;
        this.gameObject.AddComponent<BoxCollider>();

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
        var camRight = Camera.main.transform.right;
        camRight.y = 0.0f;
        camRight.Normalize();
 
        var camFor = Camera.main.transform.forward;
        camFor.y = 0.0f;
        camFor.Normalize();
 
        float accelerationX = Input.acceleration.x;
        Vector3 rightLeftMove = Vector3.zero;
        if(accelerationX >= 0.3 || accelerationX <= -0.3)
        {
            rightLeftMove = camRight * accelerationX;
        }
 
        float accelerationY = Input.acceleration.y + 0.45f;
        Vector3 upDownMove = Vector3.zero;
        if(accelerationY >= 0.3 || accelerationY < 0.3)
        {
            upDownMove = camFor * accelerationY;
        }
 
        // Creates movement vector
        Vector3 moveVector = rightLeftMove + upDownMove;
        moveVector.y = 0.0f;
        moveVector.z = 0.0f;
 
        Vector3 translationVector = moveVector * moveSpeed * Time.deltaTime;
        this.gameObject.transform.Translate(translationVector, Space.World);
		
		if (this.gameObject.transform.position.x >= 5) {
			this.gameObject.transform.position.x = 5f;
		}
		
		if (this.gameObject.transform.position.x <= -5) {
			this.gameObject.transform.position.x = -5f;
		}
    }
}
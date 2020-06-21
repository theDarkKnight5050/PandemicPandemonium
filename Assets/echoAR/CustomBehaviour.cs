/*
 *
 * Filename             CustomBehavior.cs 
 * Date                 6/21/2020
 * Author               Mira Jambusaria 
 * Version              def-hacks 2020
 * Copyright            2020, All Rights Reserved 
 *************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
**************************************************************************
 *
 * Description              Edit this script to create any behaviours for echoAR sprites 
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    // Use this for initialization
    void Start()
    {
        // Add RemoteTransformations script to object and set its entry
        //this component is responsible for enabling real-time updates 
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("scale", out value))
        {
            // Set name
            this.gameObject.scale = value * 2;
        }   
    }
}
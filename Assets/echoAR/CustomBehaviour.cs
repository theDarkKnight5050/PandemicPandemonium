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

    private GameObject yellow; 

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

        yellow = GameObject.Find("echoAR");
        string value2 = "1a5a6fb4-9623-4ecf-824e-4e14219782f8";
        string dir = "direction"; 
        string whichdir = "left"; 

        //StartCoroutine(yellow.GetComponent<echoAR>().UpdateEntryData(value2, dir, whichdir));
        //yellow.GetComponent<echoAR>().UpdateEntryData(value2, dir, whichdir); 
    }

    // Update is called once per frame
    void Update()
    {
        
        int counter = 0; 
        //frame rate is 60fps typically
        string value = "1a5a6fb4-9623-4ecf-824e-4e14219782f8";
            string dir = "direction"; 
            string whichdir = "left";  
        StartCoroutine(yellow.GetComponent<echoAR>().UpdateEntryData(value, dir, whichdir));
        if (counter > 600)
        {
            //string value = "1a5a6fb4-9623-4ecf-824e-4e14219782f8";
            //string dir = "direction"; 
            //string whichdir = "left"; 
           /* if (entry.getAdditionalData() != null )
            {
                //yellow.GetComponent<echoAR>().UpdateEntryData(value, dir, whichdir); 
                //echoAR.UpdateEntryData(value, dir, whichdir); 
                //gameObject.Find("echoAR"); 
                //gameObject.Find("echoAR").GetComponent<echoAR>().UpdateEntryData(value, dir, whichdir); 
                //echoAR.UpdateEntryData("1a5a6fb4-9623-4ecf-824e-4e14219782f8", "color", "orange"); 
            }*/
        }   
        
    }
}
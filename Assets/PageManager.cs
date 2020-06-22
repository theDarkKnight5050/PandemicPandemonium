/*
 *
 * Filename             PageManager.cs
 * Date                 6/21/2020
 * Author               Mira Jambusaria 
 * Version              def-hacks 2020
 * Copyright            2020, All Rights Reserved 
 * Description          This is the class that handles the Start Page Button that moves on to the next scene yay
 *
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PageManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SimpleAR"); 
    }
}

/*
 *
 * Filename             PageManager2.cs
 * Date                 6/21/2020
 * Author               Mira Jambusaria 
 * Version              def-hacks 2020
 * Copyright            2020, All Rights Reserved 
 * Description          This is the class that handles the Game Over Button that moves on to the beginning 
 *
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PageManager2 : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("StartMenu"); 
    }
}

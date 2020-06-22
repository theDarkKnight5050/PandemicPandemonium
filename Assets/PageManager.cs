using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManager; 

public class PageManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.loadScene("SimpleAR"); 
    }
}

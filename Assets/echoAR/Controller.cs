using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameObject mask;
    private List<GameObject> viruses = new List<GameObject>{null, null, null};
    private Collider maskCollider;
    private List<Collider> virusColliders = new List<Collider>{null, null, null};

    private int numLives = 3;

    void Start() {

    }

    void Update() {
        if (mask == null) {
            instantiate();
        } else {
            foreach (Collider vC in virusColliders) {
                if (maskCollider.bounds.Intersects(vC.bounds)) {
                    if (--numLives == 0) {
                        gameOver();
                    }
                    Debug.Log("Lives left: " + numLives);
                }
            }
        }   
    }

    void instantiate() {
        int timeout = 0;

        do {
            mask = GameObject.Find("Viruses/N9500");
            timeout++;
        } while (mask == null && timeout < 5000);
        if (timeout == 5000) {
            Debug.Log("Not found: Mask");
        } else {
            maskCollider = mask.GetComponentInChildren<Collider>();
        }
        timeout = 0;

        for (int i = 0; i < viruses.Count; i++) {
            do {
                viruses[i] = GameObject.Find("Viruses/COVID-19" + i);
                timeout++;
            } while (viruses[i] == null && timeout < 5000);
            if (timeout == 5000) {
                Debug.Log("Not found: Viruses/COVID-19" + i);
            } else {
                virusColliders[i] = viruses[i].GetComponent<BoxCollider>();
            }
        }
    }

    void gameOver() {

    }
}

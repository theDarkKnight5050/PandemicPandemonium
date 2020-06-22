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
        //Check that the first GameObject exists in the Inspector and fetch the Collider
        do {
            mask = GameObject.Find("N9500");
        } while (mask == null);
        maskCollider = mask.GetComponent<Collider>();

        //Check that the second GameObject exists in the Inspector and fetch the Collider
        for (int i = 0; i < viruses.Count; i++) {
            do {
                viruses[i] = GameObject.Find("COVID-19");
            } while (viruses[i] == null);
            virusColliders[i] = viruses[i].GetComponent<BoxCollider>();
        }
    }

    void Update() {
        //If the first GameObject's Bounds enters the second GameObject's Bounds, output the message
        foreach (Collider vC in virusColliders) {
            if (maskCollider.bounds.Intersects(vC.bounds)) {
                if (--numLives == 0) {
                    gameOver();
                }
                Debug.Log("");
            }
        }
    }

    void gameOver() {

    }
}

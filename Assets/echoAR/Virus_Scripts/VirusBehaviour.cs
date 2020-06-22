/**
* Pandemic Pandemonium
*
* @Authors Mira Jambusaria, David Sun, Ahmed Abdalla
*/
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
    private Vector3 initialWorldSpacePosition;

    private Vector3 initialObjectPosition;
    private Vector3 myDisplacement;

    // Use this for initialization
    void Start() {
        // Add RemoteTransformations script to object and set its entry
        POS_FACTOR = this.gameObject.transform.parent.transform.localScale.magnitude;
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;
        this.gameObject.AddComponent<BoxCollider>();
        isSpawned = (Random.Range(0, 100) < 5);

        try {
            initialWorldSpacePosition = (this.gameObject.transform.parent) ? this.gameObject.transform.parent.transform.position : this.gameObject.transform.position;
            myDisplacement = Vector3.zero;
            Debug.Log("Init Position: " + initialWorldSpacePosition);
        } catch (System.Exception e) {
            Debug.Log(e);
        }

        // Get init position from database
        pullInit();
    }

    // Update is called once per frame
    void Update() {
        float level = (float)Stage.l2;
        if (isSpawned) {
            Vector3 initPos = pullInit();

            myDisplacement.z += speed * POS_FACTOR;
            if (myDisplacement.z >= END) {
                myDisplacement = Vector3.zero;
                isSpawned = !isSpawned;
            }
            this.gameObject.transform.position = initPos + myDisplacement;
        } else if (Random.Range(0, level) < 1) {
            isSpawned = !isSpawned;
            speed = Random.Range(1 / level, 5 / level);
        }
    }

    Vector3 pullInit() {
        string value = "";
        Vector3 ret = Vector3.zero;
        if (entry.getAdditionalData().TryGetValue("x", out value)) {
            ret.x = float.Parse(value, CultureInfo.InvariantCulture);
        }
        if (entry.getAdditionalData().TryGetValue("y", out value)) {
            ret.y = float.Parse(value, CultureInfo.InvariantCulture);
        }
        if (entry.getAdditionalData().TryGetValue("z", out value)) {
            ret.z = float.Parse(value, CultureInfo.InvariantCulture);
        }
        Debug.Log("Remote Position: " + ret);
        return ret;
    }
}
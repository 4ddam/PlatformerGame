using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDissable : MonoBehaviour
{

    [Tooltip("The thing that is going to have a script dissabled. In this case, Main Camera")]
    public GameObject cam;
    public bool dissable;

    void Update() {
        dissableAndEnableMainCamera(dissable);
    }

    void dissableAndEnableMainCamera(bool dissable)
    {
        if (dissable) {
            cam.GetComponent<CameraFollow>().enabled = false;
        } else {
            cam.GetComponent<CameraFollow>().enabled = true;
        }
    }
}

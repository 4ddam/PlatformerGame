using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeMove : MonoBehaviour {

    [Tooltip("The thing that is going to have a script dissabled. In this case, Main Camera")]
    public GameObject cam;
    public GameObject player;
    bool dissable;

    public float panSpeed = 20f;
    public float panBorder = 10f;
    public Vector2 panLimit;

    public float zoom = 0.5f;
    public float originalSize = 7f;

    void Update() {    
        if (Input.GetKey("x")) {
            dissable = true;
        } 
        if (Input.GetKey(KeyCode.Escape)) {
            dissable = false;
            GetComponent<Camera>().orthographicSize = originalSize;
        }
        DissableAndEnableMainCamera(dissable);        
    }

    void DissableAndEnableMainCamera(bool dissable) {
        if (dissable) {
            cam.GetComponent<CameraFollow>().enabled = false;
            player.GetComponent<Player>().enabled = false;
            Movement();
        }
        else {
            cam.GetComponent<CameraFollow>().enabled = true;
            player.GetComponent<Player>().enabled = true;
           
        }
    }

    void Movement() {

        // Moving

        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder) {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorder) {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder) {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorder) {
            pos.x -= panSpeed * Time.deltaTime;
        }

        // Zooming

        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            GetComponent<Camera>().orthographicSize -= zoom;    
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            GetComponent<Camera>().orthographicSize += zoom;
        }

        // Clamping Positions

        GetComponent<Camera>().orthographicSize = Mathf.Clamp(GetComponent<Camera>().orthographicSize, 3, 10);

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}

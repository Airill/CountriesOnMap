using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipe : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, 0f, -touchDeltaPosition.y * speed);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -20, 20f),
                Mathf.Clamp(transform.position.y, 0, 5f),
                Mathf.Clamp(transform.position.z, -13, 13f));
         //   Debug.Log("swap to " + transform.position);
            /*
            //if(Input.touchCount > 0) { }
            if (Input.GetMouseButton()) { }

            //if (touch.phase == TouchPhase.Began) { }
            if (Input.GetMouseButtonDown()) { }

            //else if (touch.phase == TouchPhase.Ended) { }
            else if (Input.GetMouseButtonUp()) { }

            //touch.position;
            Input.mouseposition;
            */
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipe : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public Camera camera;
    public float minZoom = 0f;
    public float maxZoom = 5f;
    public float minX = -20f;
    public float maxX = 20f;
    public float minY = -13f;
    public float maxY= 13f;


    // Update is called once per frame
    void Update() {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, 0f, -touchDeltaPosition.y * speed);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minX, maxX),
                Mathf.Clamp(transform.position.y, minZoom, maxZoom),
                Mathf.Clamp(transform.position.z, minY, maxY));
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

        if (Input.touchCount == 2) {
            Vector2 _CameraViewsize = new Vector2(camera.pixelWidth, camera.pixelHeight);

            Touch _TouchOne = Input.touches[0];
            Touch _TouchTwo = Input.touches[1];

            Vector2 _TouchOnePrevPos = _TouchOne.position - _TouchOne.deltaPosition;
            Vector2 _TouchTwoPrevPos = _TouchTwo.position - _TouchTwo.deltaPosition;

            float _PrevTouchDeltaMag = (_TouchOnePrevPos - _TouchTwoPrevPos).magnitude;
            float _TouchDeltaMag = (_TouchOne.position - _TouchTwo.position).magnitude;

            float _DeltaMagDiff = _PrevTouchDeltaMag - _TouchDeltaMag;

            transform.Translate(0f, _DeltaMagDiff*perspectiveZoomSpeed, 0f);

            transform.position = new Vector3(
             Mathf.Clamp(transform.position.x, -20, 20f),
             Mathf.Clamp(transform.position.y, minZoom, maxZoom),
             Mathf.Clamp(transform.position.z, -13, 13f));
        }
    }
}

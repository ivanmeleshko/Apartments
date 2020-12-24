using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    Camera cam;
    protected float RotationsSpeed = 2.0f;
    public float SmoothFactor = 0.5f;
    private float speed = 1f;
    public Transform HouseTransform;
    private bool rotateAround = false;
    //private Vector3 firstpoint = new Vector3(0f, 1f, -10f);
    //private Vector3 secondpoint = new Vector3(0f, 1f, -10f);
    //private Vector3 destinationPos = new Vector3(120, 0, -100);
    private Vector3 cameraOffset;


    void Start()
    {
        cam = Camera.main;
        cam.transform.LookAt(HouseTransform.position);

        if (HouseTransform != null)
        {
            cameraOffset = cam.transform.position - HouseTransform.position;
        }
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0)) rotateAround = true;
        if (Input.GetMouseButtonUp(0)) rotateAround = false;

        if (!UI.IsPointerOverUIObject())
        {
            if (rotateAround)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationsSpeed, Vector3.up);

                float posY = cam.transform.position.y - Input.GetAxis("Mouse Y") * RotationsSpeed * 5f;
                cameraOffset = camTurnAngle * cameraOffset;

                Vector3 newPos = HouseTransform.GetComponent<Renderer>().bounds.center + cameraOffset;
                //newPos.y = Mathf.Clamp(posY, -50f, 300f);

                cam.transform.position = Vector3.Lerp(cam.transform.position, newPos, SmoothFactor);
                cam.transform.LookAt(HouseTransform.GetComponent<Renderer>().bounds.center);

            }

                /*if (Input.touchCount == 1)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        firstpoint = Input.GetTouch(0).position;
                    }
                    if (Input.GetTouch(0).phase == TouchPhase.Moved)
                    {
                        secondpoint = Input.GetTouch(0).position;

                        Quaternion camTurnAngle = Quaternion.AngleAxis((secondpoint.x - firstpoint.x) * RotationsSpeed / 500f, Vector3.up);

                        float posY = cam.transform.position.y - (secondpoint.y - firstpoint.y) * RotationsSpeed / 100f;
                        cameraOffset = camTurnAngle * cameraOffset;

                        Vector3 newPos = HouseTransform.position + cameraOffset;
                        //newPos.y = Mathf.Clamp(posY, -50f, 300f);

                        cam.transform.position = Vector3.Lerp(cam.transform.position, newPos, SmoothFactor);
                        //cam.transform.position = newPos;// Vector3.Lerp(cam.transform.position, newPos, SmoothFactor);
                        cam.transform.LookAt(HouseTransform.position);

                    }
                }*/
            
        }
    }
}

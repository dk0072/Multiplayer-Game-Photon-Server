using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;

    [HideInInspector]
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private Touch touch;

    Vector2 touchPosition;

    Quaternion rotationY;

    float rotationSpeedModifier = 0.1f;


    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {

            
            Vector3 desiredPos = target.position + offset;
            Vector3 SmoothPosition = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = SmoothPosition;

        

        
    }

/*    private void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(-touch.deltaPosition.y * rotationSpeedModifier, 0f, 0f);

                transform.rotation = rotationY * transform.rotation;
               
            }
        }
    }*/
}

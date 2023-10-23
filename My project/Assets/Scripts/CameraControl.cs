using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
   
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;

    public float SmoothTurnTime = 0.1f;
    float SmoothTurnVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction =new Vector3(horizontal, 0f,vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z)* Mathf.Rad2Deg+cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref SmoothTurnVelocity,SmoothTurnTime);
            transform.rotation = Quaternion.Euler(0f,angle,0);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized*speed* Time.deltaTime);
        }
    }
}

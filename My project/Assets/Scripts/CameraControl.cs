using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] GameObject povCam;
    public CharacterController controller;
    public float speed = 6f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vectical");
        Vector3 direction =new Vector3(horizontal, 0f,vertical).normalized;

        if
    }
}

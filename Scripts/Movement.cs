using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody PlayerBody;
    public GameObject head;
    public float movementSpeed = 5f;
    public float jumpForce = 50f;
    public GameObject Cam;
    public GameObject CameraRig;
    public GroundCheck groundCheck;

    public bool isMove = false;
    public bool isJump = false;

    void Start()
    {
        Vector3 rigPos = CameraRig.transform.position;
        rigPos = head.transform.position;
        CameraRig.transform.position = rigPos;
    }

    void Update()
    {
      
        if(isMove)
        {
            PlayerBody.transform.position += PlayerBody.transform.forward * Time.deltaTime * movementSpeed;
        }
        // Debug.Log(Cam.transform.rotation.y);
        PlayerBody.transform.rotation = Quaternion.Euler(0f, Cam.transform.eulerAngles.y, 0f);

        // changing camera pos to head

        Vector3 rigPos = CameraRig.transform.position;
        rigPos = head.transform.position;
        CameraRig.transform.position = rigPos;

        
        // jump code 

            // ground check
            if(groundCheck._onGround == true)
            {
                if (isJump)
                {
                    PlayerBody.AddForce(0, 1 * jumpForce, 0);
                    Debug.Log(isJump);
                }
            }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool _onGround = false;
    public Movement movement;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("GroundCheck is true");
            _onGround = true;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Grounded check is false");
            _onGround = false;
        }
    }
}

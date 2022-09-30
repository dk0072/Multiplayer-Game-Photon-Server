using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMotionDetector : MonoBehaviour
{
    public static PlayerMotionDetector instance;

    private void Awake()
    {
        instance = this;
    }

    public bool MotionDetected()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            if (GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
                return false;
  
    }


}

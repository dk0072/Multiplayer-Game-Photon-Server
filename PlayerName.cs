using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerName : MonoBehaviourPun
{

    private Transform cam1;
    private void Start()
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("uname");
        cam1 = Camera.main.transform;
        if (!photonView.IsMine)
        {    
   
            GetComponent<Text>().text = photonView.Owner.NickName;

        }
    }

    private void Update()
    {
        transform.LookAt(transform.position + cam1.rotation * Vector3.forward, cam1.rotation * Vector3.up);
    }
}

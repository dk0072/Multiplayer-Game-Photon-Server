using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnMonstar : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public Vector3 Spawnpos;


    private void Start()
    {
       
        GameObject player = PhotonNetwork.Instantiate(EnemyPrefab.name, Spawnpos, Quaternion.identity);
        //CameraController.instance.target = player.transform;
    }
}

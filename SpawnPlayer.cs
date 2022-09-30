using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public float MinX, MaxX, Y, Z;


    private void Start()
    {
        Vector3 pos = new Vector3(Random.Range(MinX, MaxX), Y, Z);
        GameObject player = PhotonNetwork.Instantiate(PlayerPrefab.name, pos, Quaternion.identity);
        CameraController.instance.target = player.transform;
    }

}

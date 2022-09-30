using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayerAtLobby : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public Vector3 Spawnpos;


    private void Start()
    {

        GameObject player = PhotonNetwork.Instantiate(PlayerPrefab.name, Spawnpos, Quaternion.identity);
        //CameraController.instance.target = player.transform;
    }
}

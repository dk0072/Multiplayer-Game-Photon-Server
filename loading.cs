using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class loading : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text statusText;
    [SerializeField] Slider loadingBar;
    void Start()
    {
        StartCoroutine(loadingBarCRTN());
        statusText.text = "Connecting to server";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        statusText.text = "server connected";

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        StartCoroutine(joinLobby());
    }

    IEnumerator joinLobby()
    {
        loadingBar.value = 100;
        statusText.text = "Joining lobby...";

        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game Lobby");

    }

    IEnumerator loadingBarCRTN()
    {
       
        for(int i = 0; i < 99; i++)
        {
            yield return new WaitForSeconds(0.03f);
            loadingBar.value += 1;


        }

    }

}

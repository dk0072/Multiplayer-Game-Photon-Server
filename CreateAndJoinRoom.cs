using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField CreateRoomName;
    [SerializeField] InputField JoinRoomName;
    [SerializeField] GameObject CreateUI, JoinUI, Lobby, LobbyButtons, Buttons, unameField;
    [SerializeField] TMP_InputField uname;
    [SerializeField] Animator anim;
    [SerializeField] TMP_Text DisplayUname;
    [SerializeField] Camera cam;
    [SerializeField] AudioSource source;
    [SerializeField] GameObject StartButton;
    

    private void Start()
    {
        if(PlayerPrefs.GetString("IsNew") == "false")
        {
            DisplayUname.text = PlayerPrefs.GetString("uname");
            anim.enabled = false;
            Buttons.SetActive(true);
            unameField.SetActive(false);
            cam.transform.position = new Vector3(0.17f, 1, -3.04f);
            cam.transform.rotation = Quaternion.Euler(new Vector3(7.6f, -8.55f, -1.118f));
        }

        StartButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Level1");
    }


    public void CreateRoom()
    {
        if(CreateRoomName.text != "")
        {
            PhotonNetwork.CreateRoom(CreateRoomName.text);

        }
        source.Play();
    }

    public void joinRoom()
    {
        source.Play();

        if (JoinRoomName.text != "")
        {
            PhotonNetwork.JoinRoom(JoinRoomName.text);

        }
    }

    public void ExitGame()
    {
        source.Play();

        Application.Quit();
    }

    public void OnClickCreate()
    {
        source.Play();

        CreateUI.SetActive(true);
        LobbyButtons.SetActive(false);
    }

    public void OnClickJoin()
    {
        source.Play();

        JoinUI.SetActive(true);
        CreateUI.SetActive(false);
        LobbyButtons.SetActive(false);
    }

    public void OnClickBack()
    {
        source.Play();

        JoinUI.SetActive(false);
        CreateUI.SetActive(false);
        Lobby.SetActive(true);
        LobbyButtons.SetActive(true);


    }

    public void OnClickSaveUname()
    {

        if(uname.text == "")
        {
            uname.text = "Player" + Random.Range(1, 1000);
        }

        source.Play();

        anim.enabled = true;
        PhotonNetwork.NickName = uname.text;
        PlayerPrefs.SetString("uname", uname.text);
        PlayerPrefs.SetString("IsNew", "false");
        anim.SetBool("zoomIn", false);

        anim.SetBool("zoomOut", true);
        DisplayUname.text = uname.text;
        Buttons.SetActive(true);
        LobbyButtons.SetActive(true);
        unameField.SetActive(false);

    }

    public void OnClickEditUname()
    {
        anim.enabled = true;
        source.Play();
        anim.SetBool("zoomIn", true);
        anim.SetBool("zoomOut", false);
        unameField.SetActive(true);
        JoinUI.SetActive(false);
        CreateUI.SetActive(false);
        LobbyButtons.SetActive(false);
    }

    public void startGame()
    {
        PhotonNetwork.LoadLevel("Level1");
    }
}

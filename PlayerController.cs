using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
   [HideInInspector] public Joystick joystick;
    [SerializeField] float speed;
    [SerializeField] float Rotatespeed;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody rb;
    [HideInInspector] public bool MotionDetected;
    PhotonView view;
    //public GameObject waitingText;


    private void Start()
    {
        instance = this;
        
        view = GetComponent<PhotonView>();

        joystick = FindObjectOfType<FixedJoystick>();

     //   EnemyController.instance.text = waitingText;
    }
    private void Update()
    {

        if (view.IsMine)
        {
            CameraController.instance.target = gameObject.transform;

            RaycastGun.instance.Mainplayer = this.gameObject.transform;
            RaycastGun.instance.player = this.gameObject.transform;
            Vector3 Dir = new Vector3(joystick.Horizontal * speed * Time.deltaTime, 0, joystick.Vertical * speed * Time.deltaTime);
            rb.velocity = Dir;

            if (Dir != Vector3.zero)
            {

                anim.SetBool("Run", true);
                Quaternion toRotate = Quaternion.LookRotation(Dir, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, Rotatespeed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("Run", false);
            }



             if (GetComponent<Rigidbody>().velocity == Vector3.zero)
              {
                  MotionDetected = false;
              }
              else
              {
                  MotionDetected = true;
              }

            if (EnemyController.instance.CheckMotion && MotionDetected)
            {
                view.RPC("Kill", RpcTarget.All);
            }

        }
      

    }

    [PunRPC]
    public void Kill()
    {
        PhotonNetwork.Destroy(this.gameObject);
    }
  
}

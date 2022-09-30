using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Animator anim;
    public static EnemyController instance;
    public bool CheckMotion;
    bool CanStart;
    bool pressed;
    [SerializeField] GameObject StartButton;
    //public GameObject text;

    private void Start()
    {
        instance = this;
        
    }

    private void Update()
    {
        if (CanStart)
        {
            pressed = true;
            StartButton.SetActive(false);
            StartCoroutine(turn());
            CanStart = !CanStart;
        }

        if (GetComponent<PhotonView>().AmOwner && !pressed)
        {

            StartButton.SetActive(true);

        }
        else
        {
            StartButton.SetActive(false);

        }
    }

    IEnumerator turn()
    {
        for(; ; )
        {
           
                yield return new WaitForSeconds(6f);
                anim.SetBool("turn", true);
                CheckMotion = true;
                yield return new WaitForSeconds(2f);
                yield return new WaitForSeconds(0.4f);
                yield return new WaitForSeconds(3);
                anim.SetBool("turn", false);
                CheckMotion = false;
            

        }
    }

    public void startGame()
    {
        //PhotonNetwork.Destroy(text.gameObject);
       
            //text.SetActive(false);

            CanStart = true;
        
     
    }
}

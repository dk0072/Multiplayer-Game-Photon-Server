using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{

    public static RaycastGun instance;
    public Camera playerCamera;
    public Transform player;
    public Transform Mainplayer;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;
    [SerializeField] AudioSource source;
    [SerializeField] GameObject GameOverUI;
    LineRenderer laserLine;

    void Awake()
    {
        instance = this;
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
      
        
    }

 


    IEnumerator Shoot()
    {
        laserLine.SetPosition(0, laserOrigin.position);
        laserLine.SetPosition(1, player.position);
        yield return null;
    }
}
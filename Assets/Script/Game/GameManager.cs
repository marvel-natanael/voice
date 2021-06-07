using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameManager : MonoBehaviour
{
    public GameObject pPrefab;
    public GameObject startCanvas;
    public GameObject sCamera;
    public GameObject gameCanvas;
    public PhotonView photonView;
    public Transform[] spawnPoint;
    public static int check;
    public static int score;
    bool start = false;
    private bool isTurn;
    public static bool gameOver;
    private void Start()
    {
        Screen.SetResolution(800, 600, false);
        check = 0;
        score = 0;
        gameOver = false;
    }
    private void Awake()
    {
        startCanvas.SetActive(true); 
    }

    public void startGame()
    {
        start = true;
    }

    private void Update()
    {
        if (start)
        {
            if(check >= 1)
            {
                check = 1;
            }
            spawnPlayer(check);
            start = false;
        }
        //photonView.RPC("changePlayer", RpcTarget.AllBuffered);
        if (gameOver)
        {
            StartCoroutine(restart());
        }
    }

    IEnumerator restart()
    {
        Debug.Log("Player " + score + " wins!");
        yield return new WaitForSeconds(3);
        PhotonNetwork.DestroyAll();   
    }

    public void atGameOver()
    {
        gameCanvas.SetActive(true);

    }
    public void spawnPlayer(int t)
    {
        PhotonNetwork.Instantiate(pPrefab.name, spawnPoint[t].position, spawnPoint[t].rotation, 0);
        //startCanvas.SetActive(false);
        
        sCamera.SetActive(false);
    }

   /* [PunRPC]
    private void changePlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (isTurn)
            {
                photonView.RPC("showButton", RpcTarget.AllBuffered, button1.gameObject.GetComponent<PhotonView>().ViewID, true);
            }
            else
            {
                photonView.RPC("showButton", RpcTarget.AllBuffered, button1.gameObject.GetComponent<PhotonView>().ViewID, false);
            }
        }
        else if (!PhotonNetwork.IsMasterClient)
        {
            if (isTurn)
            {
                photonView.RPC("showButton", RpcTarget.AllBuffered, button2.gameObject.GetComponent<PhotonView>().ViewID, true);
            }
            else
            {
                photonView.RPC("showButton", RpcTarget.AllBuffered, button2.gameObject.GetComponent<PhotonView>().ViewID, false);
            }
        }
    }*/
    [PunRPC]
    private void changeTurn()
    {
        if (isTurn)
        {
            isTurn = false;
        }
        else
        {
            isTurn = true;
        }
    }
    [PunRPC]
    private void showButton(int i, bool b)
    {
        PhotonView temp = PhotonView.Find(i);
        temp.transform.gameObject.SetActive(b);
    }
}

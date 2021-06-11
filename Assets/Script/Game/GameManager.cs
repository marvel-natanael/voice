using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject pPrefab;
    public GameObject startCanvas;
    public GameObject sCamera;
    public GameObject gameCanvas;
    public PhotonView photonView;
    public Transform[] spawnPoint;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI respawnText;
    public static int check;
    public static int score;
    public static bool gameOver;

    private bool start = false;
    private float timeRemain = 3f;
    private void Start()
    {
        //Screen.SetResolution(1024, 768, false);
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
        winText.text = "";
        respawnText.text = "";
        if (gameOver)
        {
            restartGame();
        }
    }
    public void spawnPlayer(int t)
    {
        PhotonNetwork.Instantiate(pPrefab.name, spawnPoint[t].position, spawnPoint[t].rotation, 0);
        startCanvas.SetActive(false);
        sCamera.SetActive(false);
    }

    private void restartGame()
    {
        timeRemain -= Time.deltaTime;
        winText.text = "Player " + score + " wins!";
        respawnText.text = "Respawning in... " + timeRemain.ToString("0");
        if(timeRemain <= 0)
        {
            PhotonNetwork.LoadLevel("test");
            PhotonNetwork.RemoveBufferedRPCs(0);
            gameOver = false;
            check = 0;
        }
    } 

}

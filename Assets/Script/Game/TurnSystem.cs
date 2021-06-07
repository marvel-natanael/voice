using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class TurnSystem : MonoBehaviour
{
    public List<TurnClass> players;
    public List<float> highScore;
    public PhotonView pv;
    // Update is called once per frame
    void Update()
    {
        //pv.RPC("updateTurn", RpcTarget.AllBuffered);
        updateTurn();
    }

    public void assignPlayer(int p, TurnClass toAssign)
    {
        toAssign.player.name = "" + p;
        players[p] = toAssign;
        GameManager.check++;
    }

    private void Start()
    {
        //pv.RPC("resetTurn", RpcTarget.AllBuffered);
        resetTurn();
    }

    [PunRPC]
    private void resetTurn()
    {
        for(int i = 0; i<players.Count; i++)
        {
            if(i == 0)
            {
                players[i].isTurn = true;
                players[i].wasPrev = false;
            }
            else
            {
                players[i].isTurn = false;
                players[i].wasPrev = false;
            }
            
        }
    }

    [PunRPC]
    private void updateTurn()
    {
        for (int i=0; i< players.Count; i++)
        {
            if (!players[i].wasPrev)
            {
                players[i].isTurn = true;
                break;
            }

            else if(i == players.Count - 1 &&
                players[i].wasPrev)
            {
                resetTurn();
            }
            highScore[i] = players[i].score;
            compareScore();
        }
    }

    void compareScore()
    {
        if (highScore[0] < highScore[1])
        {
            GameManager.score = 2;
        }
        else if(highScore[0] >= highScore [1])
        {
            GameManager.score = 1;
        }
        GameManager.gameOver = true;
    }

}

[System.Serializable]
public class TurnClass
{
    public GameObject player;
    public bool wasPrev = false;
    public bool isTurn = false;
    public float score;
}

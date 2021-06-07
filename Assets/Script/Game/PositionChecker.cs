using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PositionChecker : MonoBehaviour
{
    public TurnSystem turnSystem;
    public TurnClass turnClass;
    public PhotonView pv;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        turnClass.player = collision.gameObject;
        if (collision.gameObject.tag == "Player"
            && transform.name == "SpawnPoint1")
        {
            //pv.RPC("putPlayer0", RpcTarget.AllBuffered);
            turnSystem.assignPlayer(0, turnClass);
        }
        else if (collision.gameObject.tag == "Player"
            && transform.name == "SpawnPoint2")
        {
            //pv.RPC("putPlayer1", RpcTarget.AllBuffered);
            turnSystem.assignPlayer(1, turnClass);
        }
    }
    [PunRPC]
    private void putPlayer0()
    {
        turnSystem.assignPlayer(0, turnClass);
    }
    [PunRPC]
    private void putPlayer1()
    {
        turnSystem.assignPlayer(1, turnClass);
    }
}

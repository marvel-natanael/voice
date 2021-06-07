using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
public class soundMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivity = 100;
    public float loudness = 5;
    public PhotonView photonView;
    public TextMeshProUGUI score;
    public TextMeshProUGUI uName;
    public GameObject pCamera;
    public Button moveButton;
    public TurnSystem turnSystem;
    public TurnClass turnClass;
    public bool isTurn;
    public Transform ground;

    private AudioSource audioInput;
    private bool canMove;
    private SpriteRenderer sr;
    private void Awake()
    {
        turnClass.player = gameObject;

        if(photonView.IsMine)
        {
            pCamera.SetActive(true);
            uName.text = PhotonNetwork.NickName;
        }
        else
        {
            pCamera.SetActive(false);
            uName.text = photonView.Owner.NickName;
            uName.color = Color.red;
        }
    }

    void Start()
    {
        audioInput = GetComponent<AudioSource>();
        audioInput.clip = Microphone.Start(null, true, 10, 44100);

        sr = GetComponent<SpriteRenderer>();
        turnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();

        audioInput.loop = true;
        audioInput.mute = false;

        while(!(Microphone.GetPosition(null) > 0)){}
        audioInput.Play();

    }

    IEnumerator waitLobby()
    {
        yield return new WaitForSeconds(3.0f);

        foreach (TurnClass tc in turnSystem.players)
        {
            if (tc.player.name == gameObject.name)
            {
                turnClass = tc;
            }
            GameManager.check++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //photonView.RPC("checkTurn", RpcTarget.AllBuffered);
        isTurn = turnClass.isTurn;
        if (GameManager.check == 2)
        {
            //photonView.RPC("startCheck", RpcTarget.AllBuffered);
            StartCoroutine(waitLobby());
        }

        if (photonView.IsMine)
        {
            photonView.RPC("isUp", RpcTarget.AllBuffered);
            //isUp();
        }

    }

    float getVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audioInput.GetOutputData(data, 0);
        foreach(float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

    void movePlayer()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 4);
        
        /*loudness = getVolume() * sensitivity;
        if (loudness > 8)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 4);
        }
        */
    }

    public float getScore()
    {
        float dist = Vector3.Distance(ground.position, transform.position);
        return (dist);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ground = collision.gameObject.transform;
    }

    public void setMove(bool b)
    {
        canMove = b;
    }

    public bool getMove()
    {
        return canMove;
    }
    public void onPress()
    {
        canMove = true;
    }

    public void onRelease()
    {
        photonView.RPC("turnNow", RpcTarget.AllBuffered);
        //turnNow();
    }

    [PunRPC]
    private void turnNow()
    {
        canMove = false;
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasPrev = true;
    }

    [PunRPC]
    private void checkTurn()
    {
        isTurn = turnClass.isTurn;
    }

    [PunRPC]
    private void startCheck()
    {
        StartCoroutine(waitLobby());
    }

    [PunRPC]
    private void isUp()
    {
        if (isTurn)
        {
            moveButton.gameObject.SetActive(true);
            sr.color = new Color(1, 0, 0, 1);

            if (canMove)
            {
                movePlayer();
                //photonView.RPC("turnNow", RpcTarget.AllBuffered);
                sr.color = new Color(1, 1, 0, 1); 
            }
            score.text = "Score\n" + (getScore().ToString("0"));
            turnClass.score = getScore();
        }
        else
        {
            moveButton.gameObject.SetActive(false);
        }
    }
}

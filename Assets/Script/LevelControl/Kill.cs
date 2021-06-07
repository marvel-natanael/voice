using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D player)
    {
        Char stats = player.GetComponent<Char>();
        if (player.CompareTag("Player"))
        {
            SceneManager.LoadScene("Lose");
        }
    }
}

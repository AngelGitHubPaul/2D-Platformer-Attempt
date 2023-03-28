using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool gameOver = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameOver)
        {
            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            gameOver = true;
        }
    }
}

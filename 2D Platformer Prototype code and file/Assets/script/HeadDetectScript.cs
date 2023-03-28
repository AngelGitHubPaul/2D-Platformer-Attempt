using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetectScript : MonoBehaviour
{
    public GameObject enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameOver.gameOver = false;
            Destroy(enemy.gameObject);
        }

    }
}

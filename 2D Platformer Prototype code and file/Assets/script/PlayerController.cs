using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask platfromLayerMask;
    public Rigidbody2D playerrb;
    public BoxCollider2D playerBoxCol;
    private bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Movement mechanic 
        if (Input.GetKey(KeyCode.D))
        {
            playerrb.velocity = new Vector2(5, playerrb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }else 
        if (Input.GetKey(KeyCode.A))
        {
            playerrb.velocity = new Vector2(-5, playerrb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            playerrb.velocity = new Vector2(0, playerrb.velocity.y);
        }

        // JUMP mechanic
        if (IsGrounded())
        {
            canDoubleJump = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (IsGrounded())
            {
                playerrb.velocity = new Vector2(playerrb.velocity.x, 20f);
            }
            else
            {
                //for double jump
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (canDoubleJump)
                    {
                        playerrb.velocity = new Vector2(playerrb.velocity.x, 20f);
                        canDoubleJump = false;
                    }
                }
            }
        }
    }

    // Ground Detector for jumping
    private bool IsGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(playerBoxCol.bounds.center, playerBoxCol.bounds.size, 0f, Vector2.down, .1f, platfromLayerMask);
        return raycast.collider != null;
    }
}

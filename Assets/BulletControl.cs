using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private int wallCollisions;
    public int maxWallCollisions = 3;
    private GameObject playerTank;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerTank = GameObject.FindGameObjectWithTag("Player");
        wallCollisions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            playerTank.SendMessage("playerHit", 0f, SendMessageOptions.RequireReceiver);
            Destroy(gameObject);
        } else if (coll.collider.CompareTag("Wall")) {
            wallCollisions++;
            if (wallCollisions > maxWallCollisions) {
                wallCollisions = 0;
                rb2d.velocity = new Vector2(0, 0);
                transform.position = new Vector2(0, 0);
                Destroy(gameObject);
            }
        }
    }
}

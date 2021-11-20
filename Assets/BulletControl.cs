using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int wallCollisions;
    public int maxWallCollisions = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        wallCollisions = 0;
        
        // Uncomment to test bullet collision
        // testMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void testMove() {
        // This starts the bullet moving, use to test it out
        var velocity = rb2d.velocity;
        velocity.y = 5;
        rb2d.velocity = velocity;
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
           // TODO: Kill the bullet, kill the player, set in motion the score increase and respawn
        } else if (coll.collider.CompareTag("Wall")) {
            wallCollisions++;
            if (wallCollisions > maxWallCollisions) {
                wallCollisions = 0;
                rb2d.velocity = new Vector2(0, 0);
                transform.position = new Vector2(0, 0);
                // TODO: Kill the bullet
            }
        }
    }
}

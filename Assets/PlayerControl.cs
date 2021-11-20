using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode shootBullet = KeyCode.Mouse0;
    public float speed = 7;
    private Rigidbody2D rb2d;
    public BulletControl pubBullet;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && canShoot) {
            BulletControl bullet = (BulletControl)Instantiate(pubBullet);
            bullet.transform.position = new Vector3(1, 1);
            canShoot = false;
            Invoke("setCanShootTrue", 1);
        }

        var velocity = rb2d.velocity;
        if (Input.GetKey(moveUp)) {
            velocity.y = speed;
        } else if (Input.GetKey(moveDown)) {
            velocity.y = -speed;
        } else {
            velocity.y = 0;
        }
        
        if (Input.GetKey(moveLeft)) {
            velocity.x = -speed;
        } else if (Input.GetKey(moveRight)) {
            velocity.x = speed;
        } else {
            velocity.x = 0;
        }
        rb2d.velocity = velocity;

        var pos = transform.position;
        if (pos.y > 2.5f) {
            pos.y = 2.5f;
        } else if (pos.y < -2.5f) {
            pos.y = -2.5f;
        } 
        transform.position = pos;

        if (velocity.x > 0 && velocity.y > 0){ //y is vertical, x is horezontal
            Vector3 newRotation = new Vector3(0, 0, -45);
            transform.eulerAngles = newRotation;
        }else if (velocity.x > 0 && velocity.y == 0){
            Vector3 newRotation = new Vector3(0, 0, 90);
            transform.eulerAngles = newRotation;
        }else if (velocity.x > 0 && velocity.y < 0){
            Vector3 newRotation = new Vector3(0, 0, 45);
            transform.eulerAngles = newRotation;
        }else if (velocity.x == 0 && velocity.y < 0){
            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
        }else if (velocity.x == 0 && velocity.y > 0){
            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
        }else  if (velocity.x < 0 && velocity.y < 0){
            Vector3 newRotation = new Vector3(0, 0, -45);
            transform.eulerAngles = newRotation;
        }else  if (velocity.x < 0 && velocity.y == 0){
            Vector3 newRotation = new Vector3(0, 0, 90);
            transform.eulerAngles = newRotation;
        }else  if (velocity.x < 0 && velocity.y < 0){
            Vector3 newRotation = new Vector3(0, 0, -45);
            transform.eulerAngles = newRotation;
        }
    }

    void setCanShootTrue() {
        canShoot = true;
    }
}

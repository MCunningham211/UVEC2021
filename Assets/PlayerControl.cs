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
    public float speed = 1;
    private Rigidbody2D rb2d;
    public BulletControl pubBullet;
    private bool canShoot = true;
    private Camera cam;
    public bool myAttack = true;
    private GameObject enemyTank;
    private GameObject gameController;
    private int enemyScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyTank = GameObject.FindGameObjectWithTag("Enemy");
        gameController = GameObject.FindGameObjectWithTag("GameController");
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && canShoot && myAttack) {
            BulletControl bullet = (BulletControl)Instantiate(pubBullet);
            Vector2 tankPos = transform.position;
            Vector3 mousePos = getMouseCoords();
            Vector3 diff = (new Vector3((mousePos.x - tankPos.x), (mousePos.y - tankPos.y), 0)).normalized;
            Vector3 vel = diff * 3 * speed;
            bullet.rb2d.velocity = vel;
            bullet.transform.position = new Vector3(tankPos.x + (0.75f * diff.x), tankPos.y + (0.75f * diff.y));
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
        if (pos.y > 4.5f) {
            pos.y = 4.5f;
        } else if (pos.y < -4.5f) {
            pos.y = -4.5f;
        } 
        if (pos.x > 8f) {
            pos.x = 8f;
        } else if (pos.x < -8f) {
            pos.x = -8f;
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
        }else  if (velocity.x < 0 && velocity.y > 0){
            Vector3 newRotation = new Vector3(0, 0, 45);
            transform.eulerAngles = newRotation;
        }else  if (velocity.x < 0 && velocity.y == 0){
            Vector3 newRotation = new Vector3(0, 0, 90);
            transform.eulerAngles = newRotation;
        }else  if (velocity.x < 0 && velocity.y < 0){
            Vector3 newRotation = new Vector3(0, 0, -45);
            transform.eulerAngles = newRotation;
        }
    }

    // This is what gets called when a player gets hit
    void playerHit() {
        print("hit");
        if (myAttack) {
            enemyScore++;
            gameController.SendMessage("Score1", 0f, SendMessageOptions.RequireReceiver);
        } else {
            gameController.SendMessage("Score2", 0f, SendMessageOptions.RequireReceiver);
            enemyTank.SendMessage("playerHit", 0f, SendMessageOptions.RequireReceiver);
        }
    }

    void endTurn() {
        if (myAttack) {
            myAttack = false;
            enemyTank.SendMessage("startAttack", 0f, SendMessageOptions.RequireReceiver);
        } else {
            gameController.SendMessage("gameEnd", 0f, SendMessageOptions.RequireReceiver);
            enemyTank.SendMessage("endGame", 0f, SendMessageOptions.RequireReceiver);
        }
    }

    void setCanShootTrue() {
        canShoot = true;
    }

    Vector2 getMouseCoords() {
        Vector3 mousePosit = Input.mousePosition;
        //This is code adapted directly from here: https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html
        Vector2 mousePos = new Vector2();
        mousePos.x = mousePosit.x;
        mousePos.y = (cam.pixelHeight - mousePosit.y);
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));//Should update to mouse location
        return new Vector3(point.x, -point.y, point.z); 
    }
}

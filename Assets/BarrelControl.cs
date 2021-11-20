using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : MonoBehaviour
{
    private Camera cam;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 7;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosit = Input.mousePosition;
        //This is code adapted directly from here: https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html
        Vector2 mousePos = new Vector2();
        mousePos.x = mousePosit.x;
        mousePos.y = (cam.pixelHeight - mousePosit.y);
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));//Should update to mouse location
        transform.position = new Vector3(point.x, -point.y, point.z); 


        //Vector3 diff = (new Vector3(mousecoord.x - tankcoord.x,mousecoord.y - tankcoord.y,mousecoord.y - tankcoord.y)).normalized;
        //playerTank = GameObject.FindGameObjectWithTag("Player").tansform.position;
   }
}

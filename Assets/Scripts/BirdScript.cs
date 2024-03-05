using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigibody;
    public float flapStrength;
    public float maxHeight;
    public float newGravity = -20f;
    public LogicScript logicScript;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0, newGravity);
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Ngưng di chuyển khi đạt đến chiều cao tối đa
        }

        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
            if (transform.position.y < maxHeight)
                myRigibody.velocity = Vector2.up * flapStrength;


        if (transform.position.y < -10){
            logicScript.GameOver();
            birdIsAlive = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        logicScript.GameOver();
        birdIsAlive = false;
    }
}

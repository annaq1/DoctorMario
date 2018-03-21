using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int speed = 5;
    private Rigidbody2D rb;
    public int jumpAmount = 9;

    public GameObject PillPrefab;
    private int bulletSpeed = 5;

    private float fireRate = 0.25F;
    private float nextFire = 0.0F;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(PillPrefab.GetComponent<Collider2D>(), GetComponent<Collider2D>()); //ignore collision between player and pills
        //rb.constraints = RigidbodyConstraints2D.FreezePositionX;
	}

    // Update is called once per frame
    void Update()
    {  
        
    }

    void FixedUpdate ()
    {
        PlayerControls();
	}

    void PlayerControls()
    {
        HorizontalMovement();
        Jump();
        if (Input.GetKeyDown(KeyCode.C) && Time.time > nextFire) // delay shooting
        {
            nextFire = Time.time + fireRate;
            ShootPills();
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            //rb.AddForce(new Vector2(0, jumpAmount), ForceMode2D.Impulse);
        }
    }

    void HorizontalMovement()
    {
        Vector2 playerVector = rb.velocity;
        playerVector.x = Input.GetAxisRaw("Horizontal")*speed;
        rb.velocity = playerVector;
    }

    void ShootPills()
    {
        Transform shootPos = this.transform;
        GameObject pill = Instantiate(PillPrefab, shootPos.position, PillPrefab.transform.rotation);
        Physics2D.IgnoreCollision(pill.GetComponent<Collider2D>(), GetComponent<Collider2D>()); //ignore collision between player and pills

        //keep pill velocity consistent regardless of player's motion
        if (rb.velocity.x > 0)
            pill.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed + rb.velocity.x, 0);
        if (rb.velocity.x <= 0)
            pill.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
        Destroy(pill, 5.0f); //destroy pill after 5 seconds
    }
}

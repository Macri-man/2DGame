using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

	public float speed;
    	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //rb.MovePosition(new Vector3(moveHorizontal, 0.0f, moveVertical));
        Vector2 dirVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.MovePosition(new Vector2(transform.position.x,transform.position.y) + dirVector * Time.deltaTime);
		
	}


	private void OnTriggerEnter2D(Collider2D other) {
		//other.gameObject.
	}
}

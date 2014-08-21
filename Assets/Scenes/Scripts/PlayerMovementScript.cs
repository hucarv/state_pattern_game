using UnityEngine;
using System.Collections;

public class PlayerMovementScript : SpaceShipScript {

	public float speed = 3.0f;

	public override void Start () {
		base.Start();
		SetHP(30);
	}

    void Update () {
	
		// calculating the new player position
		float moveX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		float moveY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
		
		// avoid movement if it has reached the screen bounds
		float newX = transform.position.x + moveX;
		float newY = transform.position.y + moveY;
		if (newX < -2.5f || newX > 2.5f) {
			moveX = 0;
		}
		if (newY < -4.4f || newY > 4.4f) {
			moveY = 0;
		}
		
		// moving the player
		transform.Translate(moveX, moveY, 0.0f);
	}
}

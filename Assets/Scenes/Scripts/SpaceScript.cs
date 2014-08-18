using UnityEngine;
using System.Collections;

public class SpaceScript : MonoBehaviour {

	private const float REPEAT_POSITION = 12.8f;
	private const float SCROLL_SPEED = 1.4f;
	
	private Vector3 initialPosition;

	void Start () {
		initialPosition = transform.position;
	}
	
	void Update () {
	
		// scrolling the background
		transform.Translate(0.0f, -SCROLL_SPEED * Time.deltaTime, 0.0f);
		
		// resetting its position to keep the background scrolling
		if (transform.position.y <= REPEAT_POSITION) {
			transform.position = initialPosition;
		}
	}
}

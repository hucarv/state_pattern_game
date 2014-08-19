using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	private const float DESTROY_POSITION = 6.0f;
	private const float SPEED = 8.0f;
	
	public int direction = 1;
	private float lifeTime;

	void FixedUpdate () {
		transform.Translate(0.0f, direction * SPEED * Time.deltaTime, 0.0f);
			
		// destroying the laser
		lifeTime += Time.deltaTime;
		if (lifeTime > 3.0f) {
			Destroy(gameObject);
		}
	}
}

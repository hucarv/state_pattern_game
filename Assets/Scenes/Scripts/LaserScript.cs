using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	private const float DESTROY_POSITION = 6.0f;
	private const float SPEED = 8.0f;
	
	public int direction = 1;
	public GameObject laserCollisionPrefab;

	private float lifeTime;
	private int damage = 3;
	
	void Update () {
		transform.Translate(0.0f, direction * SPEED * Time.deltaTime, 0.0f);
			
		// destroying the laser
		lifeTime += Time.deltaTime;
		if (lifeTime > 3.0f) {
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {

		// damaging the collided object
		collision.gameObject.SendMessage("OnLaserHit", damage);

		// creating an explosion and destroying this laser object
		GameObject laserCollision = (GameObject) Instantiate(laserCollisionPrefab);
		laserCollision.transform.position = transform.position;
		Destroy(gameObject);
	}
}

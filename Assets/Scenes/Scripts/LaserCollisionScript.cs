using UnityEngine;
using System.Collections;

public class LaserCollisionScript : MonoBehaviour {

	private float lifeTime;

	void Update () {
		lifeTime += Time.deltaTime;
		if (lifeTime > 0.2f) {
			Destroy(gameObject);
		}
	}
}

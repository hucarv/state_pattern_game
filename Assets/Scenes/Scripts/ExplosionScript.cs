using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public float explosionTime = 0.2f;

	private float lifeTime;
	
	void Update () {
		lifeTime += Time.deltaTime;
		if (lifeTime > explosionTime) {
			Destroy(gameObject);
		}
	}
}

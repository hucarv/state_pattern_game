using UnityEngine;
using System.Collections;

public abstract class SpaceShipScript : MonoBehaviour {

	public GameObject hp;
	public GameObject explosionPrefab;

	private HPScript hpScript;

	public virtual void Start() {
		hpScript = hp.GetComponent<HPScript>();
	}

	public void OnLaserHit(int damage) {
		if (hpScript.GetHP() > 0) {
			hpScript.Decrease(damage);

			if (hpScript.GetHP() == 0) {
				GameObject explosion = (GameObject) Instantiate(explosionPrefab);
				explosion.transform.position = transform.position;

				Destroy(gameObject);
			}
		}
	}

	public void SetHP(int amount) {
		hpScript.SetHP(amount);
	}

	public int GetHP() {
		return hpScript.GetHP();
	}
}

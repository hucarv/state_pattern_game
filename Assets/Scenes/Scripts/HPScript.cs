using UnityEngine;
using System.Collections;

public class HPScript : MonoBehaviour {

	public GameObject fullGauge;

	private int hp;
	private int maxHP;

	public void SetHP(int amount) {
		hp = amount;
		maxHP = hp;
	}

	public int GetHP() {
		return hp;
	}

	public void Decrease(int amount) {
		hp -= amount;
		
		if (hp <= 0) {
			hp = 0;
		}

		// updating the hp gauge
		float percent = (float) hp / maxHP;
		fullGauge.transform.localScale = new Vector3(
			percent,
			fullGauge.transform.localScale.y,
			fullGauge.transform.localScale.z
		); 
	}
}

using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	private const float WAIT_TIME = 0.2f;

	public GameObject laserPrefab;
	public GameObject laserCannonLeft;
	public GameObject laserCannonRight;
	public bool autoShoot;
	public float autoShootInterval = 1.0f;
	
	private float shootWaitTime;
	private float autoShootTime;

	void Update () {
	
		// waiting a little time before shooting again
		if (shootWaitTime > 0.0f) {
			shootWaitTime -= Time.deltaTime;
			return;
		}	
		
		// shooting
		if (autoShoot) {
			autoShootTime += Time.deltaTime;
			
			if (autoShootTime > autoShootInterval) {
				Shoot();
				autoShootTime = 0.0f;
			}
		} else if (Input.GetKeyDown(KeyCode.Space)) {
			shootWaitTime = WAIT_TIME;
			Shoot();
		}
	}
	
	private void Shoot() {
	
		// creating the two lasers at the each cannon position
		CreateLaser(laserCannonLeft);
		CreateLaser(laserCannonRight);
	}
	
	private void CreateLaser(GameObject cannon) {
		GameObject laser = (GameObject) Instantiate(laserPrefab);
		laser.transform.localRotation = cannon.transform.parent.localRotation;
		laser.transform.position = cannon.transform.position;
	}
	
	public void SetAutoShootInterval(float pInterval) {
		autoShootInterval = pInterval;
	}
}

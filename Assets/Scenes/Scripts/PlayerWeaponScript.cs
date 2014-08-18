using UnityEngine;
using System.Collections;

public class PlayerWeaponScript : MonoBehaviour {

	private const float WAIT_TIME = 0.2f;

	public GameObject laserPrefab;
	public GameObject laserCannonLeft;
	public GameObject laserCannonRight;
	
	private float shootWaitTime;

	void Update () {
	
		// waiting a little time before shooting again
		if (shootWaitTime > 0.0f) {
			shootWaitTime -= Time.deltaTime;
			return;
		}	
		
		// shooting!!!
		if (Input.GetKeyDown(KeyCode.Space)) {
			shootWaitTime = WAIT_TIME;
			
			// creating the two lasers at the each cannon position
			CreateLaser(laserCannonLeft);
			CreateLaser(laserCannonRight);
		}
	}
	
	private void CreateLaser(GameObject cannon) {
		GameObject laser = (GameObject) Instantiate(laserPrefab);
		laser.transform.position = cannon.transform.position;
	}
}

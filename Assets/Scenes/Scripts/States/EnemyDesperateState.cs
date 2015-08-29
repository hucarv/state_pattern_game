using UnityEngine;
using System.Collections;

public class EnemyDesperateState : EnemyState {

	private float rotationSpeed;
	private float changeAngleTime;
	private int shootingDirection;

	public EnemyDesperateState() {
		shootingDirection = -1;
		rotationSpeed = 50.0f;
	}

	public override void Update(EnemyMovementScript enemyMovementScript) {
		enemyMovementScript.gameObject.transform.RotateAround(enemyMovementScript.gameObject.transform.position, 
		                                                      Vector3.forward, shootingDirection * rotationSpeed * Time.deltaTime);
		
		changeAngleTime += Time.deltaTime;
		if (changeAngleTime > 1.0f) {
			shootingDirection *= -1;
			changeAngleTime = -1.0f;
		}
	}
}

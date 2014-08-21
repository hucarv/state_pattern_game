using UnityEngine;
using System.Collections;

public class EnemyAttackRotatingState : EnemyAttackState {

	private float rotationSpeed;
	private float changeAngleTime;
	private int shootingDirection;
	private GameObject gameObject;

	public EnemyAttackRotatingState(GameObject pGameObject) {
		gameObject = pGameObject;
		shootingDirection = -1;
		rotationSpeed = 50.0f;
	}

	public override void Attack() {
		gameObject.transform.RotateAround(gameObject.transform.position, Vector3.forward, shootingDirection * rotationSpeed * Time.deltaTime);
		
		changeAngleTime += Time.deltaTime;
		if (changeAngleTime > 1.0f) {
			shootingDirection *= -1;
			changeAngleTime = -1.0f;
		}
	}
}

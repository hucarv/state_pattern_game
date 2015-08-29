using UnityEngine;
using System.Collections;

public class EnemyConfidentState : EnemyState {

	private GameObject player;
	private float followAttackSpeed;
	private float followAttackTime;

	public EnemyConfidentState() {
		followAttackSpeed = 0.5f;
		player = GameObject.Find("Player");
	}

	public override void Update(EnemyMovementScript enemyMovementScript) {
		if (player == null) {
			return;
		}
		GameObject gameObject = enemyMovementScript.gameObject;
		
		// moving
		Vector3 targetPosition = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, followAttackSpeed * Time.deltaTime);
		
		// shooting
		followAttackTime += Time.deltaTime;
		if (followAttackTime > 1.0f) {
			followAttackTime = 0.0f;
		}

		// changing the attack pattern if the HP is low (internal state has been changed!)
		if (enemyMovementScript.GetHP() < 150) {
			gameObject.SendMessage("SetAutoShootInterval", 0.4f);
			enemyMovementScript.SetState(new EnemyDesperateState());
		}
	}
}

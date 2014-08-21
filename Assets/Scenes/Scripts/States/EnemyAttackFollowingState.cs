using UnityEngine;
using System.Collections;

public class EnemyAttackFollowingState : EnemyAttackState {

	private GameObject player;
	private float followAttackSpeed;
	private float followAttackTime;
	private GameObject gameObject;

	public EnemyAttackFollowingState(GameObject pGameObject) {
		gameObject = pGameObject;
		followAttackSpeed = 0.5f;
		player = GameObject.Find("Player");
	}

	public override void Attack() {
		if (player == null) {
			return;
		}
		
		// moving
		Vector3 targetPosition = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, followAttackSpeed * Time.deltaTime);
		
		// shooting
		followAttackTime += Time.deltaTime;
		if (followAttackTime > 1.0f) {
			followAttackTime = 0.0f;
		}
	}
}

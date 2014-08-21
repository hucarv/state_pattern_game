using UnityEngine;
using System.Collections;

public class EnemyMovementScript : SpaceShipScript {

	private EnemyAttackState state;
	
	public override void Start () {
		base.Start();
		SetHP(300);
		state = new EnemyAttackFollowingState(gameObject);
	}
	
	void Update () {
		state.Attack();
	
		// changing the attack pattern if the HP is low
		if (state is EnemyAttackFollowingState && GetHP() < 150) {
			SendMessage("SetAutoShootInterval", 0.4f);
			state = new EnemyAttackRotatingState(gameObject);
		} 
	}
}

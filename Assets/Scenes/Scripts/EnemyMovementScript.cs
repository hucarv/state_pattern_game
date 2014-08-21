using UnityEngine;
using System.Collections;

public class EnemyMovementScript : SpaceShipScript {

	private const int FOLLOW_ATTACK = 1;
	private const int STOP_AND_SHOOT_ATTACK = 2;

	private int state;
	
	// -- follow attack code ------------------------- //
	private GameObject player;
	private float followAttackSpeed;
	private float followAttackTime;
	// -- follow attack code ------------------------- //
	
	// -- stop and shoot attack code ----------------- //
	private float rotationSpeed;
	private float changeAngleTime;
	private int shootingDirection;
	// -- stop and shoot attack code ----------------- //

	public override void Start () {
		base.Start();
		SetHP(300);
		state = FOLLOW_ATTACK;
		
		// -- follow attack code ------------------------- //
		followAttackSpeed = 0.5f;
		player = GameObject.Find("Player");
		// -- follow attack code ------------------------- //
		
		// -- stop and shoot attack code ----------------- //
		rotationSpeed = 50.0f;
		// -- stop and shoot attack code ----------------- //
	}
	
	void Update () {
	
		// performing the current attack behavior
		switch(state) {
			case FOLLOW_ATTACK: { PerformFollowAttack(); break; }
			case STOP_AND_SHOOT_ATTACK: { PerformStopAndShootAttack(); break; }
		}
		
		// changing the attack pattern if the HP is low
		if (state == FOLLOW_ATTACK && GetHP() < 150) {
			shootingDirection = -1;
			changeAngleTime = 0.0f;
			SendMessage("SetAutoShootInterval", 0.4f);
			state = STOP_AND_SHOOT_ATTACK;
		} 
	}
	
	// -- follow attack code ------------------------- //
	private void PerformFollowAttack() {
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
	// -- follow attack code ------------------------- //
	
	// -- stop and shoot attack code ----------------- //
	private void PerformStopAndShootAttack() {
		gameObject.transform.RotateAround(gameObject.transform.position, Vector3.forward, shootingDirection * rotationSpeed * Time.deltaTime);
		
		changeAngleTime += Time.deltaTime;
		if (changeAngleTime > 1.0f) {
			shootingDirection *= -1;
			changeAngleTime = -1.0f;
		}
	}
	// -- stop and shoot attack code ----------------- //
}

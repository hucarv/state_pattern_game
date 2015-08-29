using UnityEngine;
using System.Collections;

public class EnemyMovementScript : SpaceShipScript {

	private EnemyState state;
	
	public override void Start () {
		base.Start();
		SetHP(300);
		SetState(new EnemyConfidentState());
	}
	
	void Update () {
		state.Update(this);
	}

	public void SetState(EnemyState pState) {
		state = pState;
	}
}

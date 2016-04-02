using UnityEngine;
using System.Collections;

public class EnemyController : ShipController
{
	// Update is called once per frame
	void Update ()
	{
		speed = Mathf.Clamp(speed + acceleration, 0, maxSpeed);

		transform.position += transform.forward * speed * Time.deltaTime;

		RotateTowardsPlayer();
	}

	public void RotateTowardsPlayer()
	{
		PlayerController player = GameController.Instance.player;
		_targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

		transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, rotationSpeed * Time.deltaTime);
	}

	protected Quaternion _targetRotation = new Quaternion();

	public void FixedUpdate ()
	{
		if (PlayerInFront())
		{
			FireLaser ();
		}
	}

	public bool PlayerInFront ()
	{
		PlayerController player = GameController.Instance.player;
		float angleToPlayer = Vector3.Angle(transform.forward, player.transform.position - transform.position);

		return Mathf.Abs(angleToPlayer) < 15;
	}

	public override void Die ()
	{
		GameController.Instance.CheckForWinCondition();
		base.Die();
	}
}
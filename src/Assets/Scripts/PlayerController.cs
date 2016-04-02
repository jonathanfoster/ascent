using UnityEngine;
using System.Collections;

public class PlayerController : ShipController
{
	// Update is called once per frame
	void Update ()
	{
		_rotationDelta.x = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
		_rotationDelta.z = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

		transform.Rotate(_rotationDelta);

		float requestedAcceleration = Input.GetAxis("Vertical");

		if (requestedAcceleration > 0)
		{
			speed += acceleration * requestedAcceleration;
		}
		else
		{
			speed += deceleration * requestedAcceleration;
		}

		// Clamp
		speed = Mathf.Clamp(speed, 0, maxSpeed);

		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void FixedUpdate ()
	{
		if (Input.GetButton("Fire1"))
		{
			FireLaser();
		}
	}

	public override void Die ()
	{
		GameController.Instance.Lose();
	}
}

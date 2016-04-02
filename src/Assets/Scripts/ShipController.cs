using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{
	public float acceleration = 30f;
	public float deceleration = 30f;
	public float maxSpeed = 1000;

	public float speed = 0;

	public float rotationSpeed = 100;

	public GameObject laserAsset;

	public void FireLaser ()
	{
		GameObject laserObject = GameObject.Instantiate(laserAsset) as GameObject;
		LaserController laser = laserObject.GetComponent<LaserController> ();
		laser.Fire(this);
	}

	protected Vector3 _rotationDelta = Vector3.zero;

	public const int LASER_DAMAGE = 10;
	public const int COLLISION_DAMAGE = 10;
	public int hp = 100;

	public void TakeDamage (int damage)
	{
		hp -= damage;

		if (hp <= 0)
		{
			Die();
		}
	}

	public virtual void Die ()
	{
		Destroy(gameObject);
	}

	public void OnTriggerEnter (Collider other)
	{
		LaserController laser = other.gameObject.GetComponent<LaserController>();
		if (laser)
		{
			if (laser.owner != this)
			{
				TakeDamage(laser.damage);
				Destroy(laser.gameObject);
			}
		}
	}

	public void OnCollisionEnter (Collision collision)
	{
		ShipController ship = collision.gameObject.GetComponent<ShipController>();

		if (ship)
		{
			TakeDamage(COLLISION_DAMAGE);			
		}
	}
}

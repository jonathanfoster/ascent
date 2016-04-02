using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{
	public float lifetime = 1f;
	public float laserSpeed = 4000;
	public int damage = 5;

	public ShipController owner;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, lifetime);
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	public void Fire (ShipController owner)
	{
		this.owner = owner;

		transform.position = owner.transform.position;
		transform.rotation = owner.transform.rotation;

		speed = owner.speed + laserSpeed;
	}
}

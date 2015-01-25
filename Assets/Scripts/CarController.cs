using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
	public int dir; // -1 = left, 1 = right
	public int speed = 200;
	private Vector2 escapeVector;
	private bool wasHit = false;
	public bool scared = false;

	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		Vector2 vel = rigidbody2D.velocity;

		vel.x = dir * speed * Time.deltaTime;

		if (wasHit)
		{
			vel = (speed / 25) * escapeVector;
		}

		rigidbody2D.velocity = vel;

		if (Mathf.Abs(transform.position.x) > 100)
		{Destroy(gameObject);}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name.Contains("Player"))
		{
			escapeVector = (transform.position - col.transform.position).normalized;
			wasHit = true;
		}
	}

}

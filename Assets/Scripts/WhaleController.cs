using UnityEngine;
using System.Collections;

public class WhaleController : MonoBehaviour
{
	public float speed = 50;
	public int dir;
	public Vector2 escapeVector;
	public bool wasHit = false;
	public bool scared = false;
	private Vector2 startPos;

	// Use this for initialization
	void Start()
	{
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector3 tempScale = transform.localScale;
		tempScale.x = -dir;
		transform.localScale = tempScale;

		Vector2 vel = rigidbody2D.velocity;
		vel.x = dir * speed * Time.deltaTime;
		rigidbody2D.velocity = vel;

		renderer.sortingOrder = Mathf.RoundToInt(Mathf.Abs(transform.position.y));
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name.Contains("Player"))
		{
			escapeVector = (transform.position - col.transform.position).normalized;
			wasHit = true;
		}
	}

	public void ResetPos()
	{
		transform.position = startPos;
		rigidbody2D.angularVelocity = 0;
		Vector3 tempRot = transform.eulerAngles;
		tempRot.z = 0;
		transform.eulerAngles = tempRot;
	}
}

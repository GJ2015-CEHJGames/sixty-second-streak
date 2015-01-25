using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
	public int dir; // -1 = left, 1 = right
	public int speed = 200;
	private Vector2 escapeVector;
	private bool wasHit = false;
	public bool scared = false;
	public AudioSource aSource;
	public AudioClip honkSound;
	public AudioClip crashSound;
	private float honkTimer;

	// Use this for initialization
	void Start()
	{
		honkTimer = Random.Range(7.0f, 15.0f);
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

		if (!wasHit)
		{
			if (honkTimer > 0)
			{honkTimer -= Time.deltaTime;}
			else
			{
				aSource.clip = honkSound;
				aSource.Play();
				honkTimer = Random.Range(7.0f, 15.0f);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name.Contains("Player"))
		{
			escapeVector = (transform.position - col.transform.position).normalized;
			wasHit = true;
			aSource.clip = crashSound;
			aSource.Play();
		}
		/*else if (col.name.Contains("NPC") && !wasHit)
		{
			aSource.clip = honkSound;
			aSource.Play();
		}*/
	}

}

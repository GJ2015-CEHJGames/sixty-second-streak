using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour
{
	public float speed = 100;
	public bool scared = false;
	enum States
	{Waiting, Moving, Escaping};
	private States currState;
	private Animator animator;
	private float waitTimer = 0;
	private float moveTimer = 0;
	//private int facing = 0; // 0 = Down, 1 = Left, 2 = Up, 3 = Right
	private Vector2 escapeVector;
	private Collider2D player;
	private Vector3 startPos;

	// Use this for initialization
	void Start()
	{
		currState = States.Waiting;
		waitTimer = Random.Range(0.1f, 1.0f);
		animator = this.GetComponent<Animator>();
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update()
	{
		renderer.sortingOrder = Mathf.RoundToInt(Mathf.Abs(transform.position.y));

		Vector2 vel = rigidbody2D.velocity;

		switch (currState)
		{
			/// Waiting
			case States.Waiting:
				if (waitTimer > 0)
				{waitTimer -= Time.deltaTime;}
				else if (waitTimer <= 0)
				{
					currState = States.Moving;
					//facing = Random.Range(0, 5);
					//animator.SetInteger("Facing", facing);
					moveTimer = Random.Range(0.1f, 2.0f);
					/*if (facing == 0)
					{vel.y = -speed * Time.deltaTime;}
					else if (facing == 2)
					{vel.y = speed * Time.deltaTime;}
					if (facing == 1)
					{vel.x = -speed * Time.deltaTime;}
					else if (facing == 3)
					{vel.x = speed * Time.deltaTime;}*/
					animator.speed = 0.5f;
				}
				break;
			// Moving
			case States.Moving:
				if (moveTimer > 0)
				{moveTimer -= Time.deltaTime;}
				else if (moveTimer <= 0)
				{
					currState = States.Waiting;
					waitTimer = Random.Range(0.5f, 4.0f);
					vel.x = vel.y = 0;
					animator.speed = 0;
				}
				break;
			// Escaping
			case States.Escaping:
				vel = (speed / 12) * escapeVector;
				// Need to change facing direction

				if (Vector2.Distance(player.transform.position, transform.position) > 8)
				{currState = States.Waiting;}
				break;
		}

		rigidbody2D.velocity = vel;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name.Contains("Player"))
		{
			player = col;
			escapeVector = (transform.position - col.transform.position).normalized;
			/*if (Mathf.Abs(escapeVector.x) > Mathf.Abs(escapeVector.y))
			{
				if (escapeVector.x > 0)
				{facing = 3;}
				else
				{facing = 1;}
			}
			else
			{
				if (escapeVector.y > 0)
				{facing = 2;}
				else
				{facing = 0;}
			}
			animator.SetInteger("Facing", facing);*/
			currState = States.Escaping;
			Destroy(GetComponent<BoxCollider2D>());
		}
	}

	public void ResetPos()
	{
		transform.position = startPos;
		scared = false;
	}
}

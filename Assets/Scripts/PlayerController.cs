using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public GameManager gmmgr;
	public float speed = 100;
	//int facing = 0; // 0 = Down, 1 = Left, 2 = Up, 3 = Right
	private Animator animator;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector2 vel = rigidbody2D.velocity;
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		vel.x = horiz * speed * Time.deltaTime;
		vel.y = vert * speed * Time.deltaTime;

		// Change animation states
		if (vert > 0)
		{animator.SetInteger("Facing", 2);}
		else if (vert < 0)
		{animator.SetInteger("Facing", 0);}
		if (horiz < 0)
		{animator.SetInteger("Facing", 1);}
		else if (horiz > 0)
		{animator.SetInteger("Facing", 3);}

		rigidbody2D.velocity = vel;
		animator.speed = Mathf.Max(Mathf.Abs(horiz), Mathf.Abs(vert));
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "NPC")
		{
			gmmgr.score += 1;
		}
	}
}

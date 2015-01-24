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
		renderer.sortingOrder = Mathf.RoundToInt(Mathf.Abs(transform.position.y));

		Vector2 vel = rigidbody2D.velocity;
		float horiz = Input.GetAxisRaw("Horizontal");
		float vert = Input.GetAxisRaw("Vertical");
		vel = new Vector2(horiz, vert).normalized * speed * Time.deltaTime;

		// Change animation states
		/*if (vert > 0)
		{animator.SetInteger("Facing", 2);}
		else if (vert < 0)
		{animator.SetInteger("Facing", 0);}
		if (horiz < 0)
		{animator.SetInteger("Facing", 1);}
		else if (horiz > 0)
		{animator.SetInteger("Facing", 3);}*/

		rigidbody2D.velocity = vel;
		animator.speed = Mathf.Max(Mathf.Abs(horiz), Mathf.Abs(vert));
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "NPC" && !col.GetComponent<NPCController>().scared)
		{
			gmmgr.score += 1;
			col.GetComponent<NPCController>().scared = true;;
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public GameManager gmmgr;
	public float speed = 100;
	//int facing = 0; // 0 = Down, 1 = Left, 2 = Up, 3 = Right
	private Animator animator;
	private Vector3 startPos;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		startPos = transform.position;
	}

	void Awake()
	{
		gmmgr = GameObject.Find("GameManager").GetComponent("GameManager") as GameManager;
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector2 vel = rigidbody2D.velocity;
		float horiz = Input.GetAxisRaw("Horizontal");
		float vert = Input.GetAxisRaw("Vertical");

		if (gmmgr.countdownTimer <= 0)
		{
			renderer.sortingOrder = Mathf.RoundToInt(Mathf.Abs(transform.position.y));

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
		}
			animator.speed = Mathf.Max(Mathf.Abs(horiz), Mathf.Abs(vert));
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name.Contains("NPC") && !col.GetComponent<NPCController>().scared)
		{
			gmmgr.score += 1;
			NPCController npcScr = col.GetComponent<NPCController>() as NPCController;
			npcScr.scared = true;
			Sprite randBubble = npcScr.bubbleSprites[Random.Range(0, npcScr.bubbleSprites.Count - 1)];
			GameObject bubble = new GameObject("Bubble");
			SpriteRenderer sr;
			sr = bubble.AddComponent("SpriteRenderer") as SpriteRenderer;
			sr.sprite = randBubble;
			Instantiate(bubble, col.transform.position, transform.rotation);
		}
		else if (col.name.Contains("Car") && !col.GetComponent<CarController>().scared)
		{
			gmmgr.score += 1;
			col.GetComponent<CarController>().scared = true;
			col.GetComponent<CarController>().rigidbody2D.angularVelocity = (Random.value > 0.5) ? 1000 : -1000;
		}
	}

	public void ResetPos()
	{
		transform.position = startPos;
	}
}

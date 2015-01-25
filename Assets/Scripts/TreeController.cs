using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour
{
	public bool onFire = false;
	private Animator animator;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
		animator.SetBool("OnFire", onFire);
	}
}

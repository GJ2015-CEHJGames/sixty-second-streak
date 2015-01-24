using UnityEngine;
using System.Collections;

public class Prop : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		renderer.sortingOrder = Mathf.RoundToInt(Mathf.Abs(transform.position.y));
	}
}

using UnityEngine;
using System.Collections;

public class TopDownCameraFollow : MonoBehaviour{

	public Transform playerTransform;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector3 trans = transform.position;
		trans.x = playerTransform.position.x;
		trans.y = playerTransform.position.y;

		transform.position = trans;
	}
}

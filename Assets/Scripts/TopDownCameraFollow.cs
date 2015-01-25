using UnityEngine;
using System.Collections;

public class TopDownCameraFollow : MonoBehaviour{

	public Transform playerTransform;
	public SpriteRenderer BGRenderer;
	//private Rect BGRect;

	// Use this for initialization
	void Start()
	{
		//BGRect = new Rect(BGRenderer.sprite.rect.x - (BGRenderer.sprite.rect.width / 2), BGRenderer.sprite.rect.x + BGRenderer.transform.position.y, BGRenderer.sprite.rect.width, BGRenderer.sprite.rect.height);
		//Debug.Log(BGRect);
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector3 trans = transform.position;

		if (playerTransform != null)
		{
			trans.x = playerTransform.position.x;
			trans.y = playerTransform.position.y;
		}

		//trans.x = Mathf.Clamp(playerTransform.position.x, -15 + (camera.rect.width / 2), 15 - (camera.rect.width / 2));
		//trans.y = Mathf.Clamp(playerTransform.position.y, -25, 0);

		transform.position = trans;
	}
}

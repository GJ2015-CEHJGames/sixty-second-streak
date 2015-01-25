using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
	public GameObject carPrefab;
	public int dir;
	private float spawnTimer;

	// Use this for initialization
	void Start()
	{
		spawnTimer = Random.Range(1.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update()
	{
		if (spawnTimer > 0)
		{spawnTimer -= Time.deltaTime;}
		else
		{
			GameObject carObj = Instantiate(carPrefab, transform.position, transform.rotation) as GameObject;
			CarController cctrlr = carObj.GetComponent<CarController>() as CarController;
			cctrlr.dir = dir;
			spawnTimer = Random.Range(1.0f, 5.0f);
		}
	}
}

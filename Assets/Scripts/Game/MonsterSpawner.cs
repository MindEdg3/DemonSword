using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour
{
	
	public Monster[] monsters;
	public float minSpawnRate;
	public float maxSpawnRate;
	private float lastSpawnTime;
	private float nextDelay;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (lastSpawnTime + nextDelay < Time.time) {
			SpawnMonster ();
		}
	}

	void SpawnMonster ()
	{
		Monster newMonster = Instantiate (monsters [0], transform.position, Quaternion.identity) as Monster;
		GameManager.Instance.monsters.Add (newMonster);
		nextDelay = Random.Range (minSpawnRate, maxSpawnRate);
		lastSpawnTime = Time.time;
	}
}

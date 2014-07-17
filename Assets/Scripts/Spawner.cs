using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 2f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.


	void Start ()
	{
		spawnTime = Random.Range (0.5f, 3f);
		spawnDelay = Random.Range (0, 3);
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}


	void Spawn ()
	{
		spawnTime = Random.Range (1, 3);
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}
}

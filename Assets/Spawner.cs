using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour 
{
	public List<GameObject> PokemonPrefabs;
	// Use this for initialization
	void Start () 
	{
		GameObject prefab = PokemonPrefabs[Random.Range (0, PokemonPrefabs.Count - 1)];
		GameObject pokemon = GameObject.Instantiate(prefab) as GameObject;
		pokemon.transform.position = transform.position;
		pokemon.transform.rotation = transform.rotation;
		GameObject.Destroy(gameObject);
	}
}

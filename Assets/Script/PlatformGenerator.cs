using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
	//public GameObject platformPrefab;
	public List<GameObject> platformPrefabs;
	
	public int numberOfPlatforms = 20000;
	public float minY = 0.4f;
	public float maxY = 1.4f;
	public float width = 3f;

	public void Start(){
		Vector3 nextPlatform = new Vector3();
		for(int i = 0; i < numberOfPlatforms; i++){
			nextPlatform.y += Random.Range(minY, maxY);
			nextPlatform.x = Random.Range(-width, width);
			Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Count)], nextPlatform, Quaternion.identity);
		}
	}
}

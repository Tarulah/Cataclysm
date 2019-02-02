using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public GameObject [] EnemyPrefab;

	public bool SpawnEnemy(int enemyID){
		if(enemyID >= EnemyPrefab.Length){
			Debug.Log("Invalid enemyID");
			return false;
		}
		Instantiate(EnemyPrefab[enemyID], transform.position + (transform.forward*5), Quaternion.identity);
		return true;
	}
	
}

using UnityEngine;
using System.Collections;

public class SpawnInstance {
	public float TimeCode;
	public int MonsterType;
	public bool Triggered;
}

public class SpawnController : MonoBehaviour {
	public float TimeCode;
	public SpawnPoint [] SpawnPoint;

	private ArrayList SpawnQueue;
	private bool spawnedEnemyThisRound = false;

	public void AddItemToQueue(float _TimeCode, int _MonsterType){
		SpawnInstance monster = new SpawnInstance();
		monster.TimeCode = _TimeCode;
		monster.Triggered = false;
		monster.MonsterType = _MonsterType;
		SpawnQueue.Add(monster);
		//Debug.Log("Told the monster " + _MonsterType + " to spawn at time " + _TimeCode);
	}

	void Awake(){
		SpawnQueue = new ArrayList();
	}

	void Start(){
		//                      Difficulty, # Wave 
		InitializeSpawnSequence(        1,      1);
	}

	void OnGUI(){
		GUI.Label(new Rect(10,10,100,100), "Time: " + TimeCode);
	}

	void InitializeSpawnSequence(int Difficulty, int Wave){
		int numberOfMonsters = Difficulty * 20 * Wave;
		Debug.Log("Initializing wave" + Wave + ". Difficulty " + Difficulty + ". Number of monsters: " + numberOfMonsters);
		for(int i=0 ;i< numberOfMonsters ;i++){
			AddItemToQueue(Random.Range(1.0f, 120.0f), Random.Range(0,1));
		}
	}
	
	void Update () {
		int i=0;
		TimeCode += Time.deltaTime;
		spawnedEnemyThisRound = false;
		for(i = 0; i < SpawnQueue.Count; i++){
			SpawnInstance s = (SpawnInstance) SpawnQueue[i];
			//Debug.Log(s.TimeCode + " " + TimeCode);
			if(s.TimeCode < TimeCode){
				int SpawnDirection = Random.Range(0, SpawnPoint.Length);
				spawnedEnemyThisRound = true;
				SpawnPoint[SpawnDirection].SpawnEnemy(s.MonsterType);
				//Debug.Log("Spawning an enemy from portal " + SpawnDirection);
				break;
				
			}
		}
		if(spawnedEnemyThisRound){
			//Debug.Log("Removing enemy spawning order from the slot number " +i );
			SpawnQueue.RemoveAt(i);
		}
		//	}
        /*if (Input.GetKeyDown(KeyCode.Return)){    Only for debugging purposes
        	AddItemToQueue(Random.Range(1.0f, 120.0f), Random.Range(0,1));
        }*/
	}
}

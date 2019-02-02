using UnityEngine;
using System.Collections;

//Script for enemy//

public class EnemyAttack : MonoBehaviour {

    private GameObject Player;

    //Distance after which enemy tries to attack the player
    public float MaxDist;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        //Check the distance between enemy and the player
        float distance = Vector3.Distance(Player.transform.position, gameObject.transform.position);

        if (distance <= MaxDist)
        {
            EnemySpeed.SharedSpeed.Speed = 0;
            StartCoroutine(DelayBetweenAttacks());
        }
        else
        {
            EnemySpeed.SharedSpeed.Speed = 2;
        }
	}

    IEnumerator DelayBetweenAttacks()
    {
        yield return new WaitForSeconds(10);
    }
}

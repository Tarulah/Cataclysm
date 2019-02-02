using UnityEngine;
using System.Collections;

//Script for enemy//

public class EnemySpeed
{ 

    private static EnemySpeed SpeedInstance = null;
    public static EnemySpeed SharedSpeed
    {
        get
        {
            if (SpeedInstance == null)
            {
                SpeedInstance = new EnemySpeed();
            }
            return SpeedInstance;
        }
    }
    public float Speed = 1;
}

public class MoveEnemy : MonoBehaviour {

	private GameObject Player;
    //Enemys base speed
    public static float baseSpeed = 2;
    //Makes the enemy go faster (or slower)
    public float SpeedMultiplier = baseSpeed;
    //When will the enemy rush
    public int startRush = 100;
    public float MaxDist;
    int rush;

    void Start()
    {
        Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update (){

        //Moves the enemy
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, EnemySpeed.SharedSpeed.Speed * SpeedMultiplier * Time.deltaTime);
        rush = Random.Range(1, startRush + 1);
        //"Desides" if the enemy will rush towards the player
        RushTowards();
    }


    //The enemy is very angry and rushes towards the player
    void RushTowards()
    {
        
        if (/*rush == startRush*/ Input.GetKeyDown(KeyCode.E))
        {
            while (SpeedMultiplier < 4)
            {
                //Makes the enemy go faster
                SpeedMultiplier = SpeedMultiplier + 1f;
                Debug.Log("Enemy is faster");
            }

            Vector3 playerPos = new Vector3(transform.position.x, transform.position.y, 0) * SpeedMultiplier * Time.deltaTime;

            //Keeps enemy rushing for a while
            StartCoroutine(RunForAWhile());

            //Check the distance between enemy and the player
            float distance = Vector3.Distance(Player.transform.position, gameObject.transform.position);

            if(distance <= MaxDist)
            {
                SpeedMultiplier = 0;
            }

        }
    }

    IEnumerator OutOfBreath()
    {
        yield return new WaitForSeconds(2f);
        SpeedMultiplier = baseSpeed;
        Debug.Log("Running again");
    }

    IEnumerator RunForAWhile()
    {
        yield return new WaitForSeconds(2f);
        while (SpeedMultiplier > 0)
        {
            //Slows down the enemy to normal speed
            SpeedMultiplier = SpeedMultiplier - 0.5f;
            Debug.Log("Enemy slowed down");
            if (SpeedMultiplier <= 0)
            {
                Debug.Log("Huffpuff");
                StartCoroutine(OutOfBreath());
            }
        }
        rush = 1;
    }
}

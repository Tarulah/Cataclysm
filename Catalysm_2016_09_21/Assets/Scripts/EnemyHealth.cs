using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float BruteHealth = 100f;

	public void Damage(float damageAmount)
	{
		BruteHealth -= damageAmount;

		if (BruteHealth <= 0) 
		{
			gameObject.SetActive (false);
		}
	}
}

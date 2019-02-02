using UnityEngine;
using System.Collections;

public class RayViewer : MonoBehaviour {

	public float WeaponRange = 15f;
	Camera FpsCamera;

	// Use this for initialization
	void Start () 
	{
		FpsCamera = GetComponentInParent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 lineOrigin = FpsCamera.ViewportToWorldPoint (new Vector3 (.5f, .5f, 0f));

		Debug.DrawRay (lineOrigin, FpsCamera.transform.forward * WeaponRange, Color.red);
	}
}

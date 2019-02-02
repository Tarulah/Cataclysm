using UnityEngine;
using System.Collections;

public class EnemyMortality : MonoBehaviour {

	public float HitPoints = 100f;

	void InitializeValues(){
		if (transform.tag == "Brute") {
			HitPoints = 100f;
		}
		// else if(transform.tag == "Next Enemy Type
	}
	/*
	void TriangleExplosion(){
		MeshFilter MF = GetComponent<MeshFilter> ();
		MeshRenderer MR = GetComponent<MeshRenderer> ();
		Mesh M = MF.mesh;
		for (int submesh = 0; submesh < M.subMeshCount; submesh++) {
			int[] indices = M.GetTriangles (submesh);
			for (int i = 0; i < indices.Length; i += 3) {  
	
				Vector3[] newVerts = new Vector3[3];
				Vector3[] newNormals = new Vector3[3];
				Vector2[] newUvs = new Vector2[3];
				for (int n = 0; n < 3; n++) {
					int index = indices [i + n];
					newVerts [n] = verts [index];
					newUvs [n] = uvs [index];
					newNormals [n] = normals [index];
				}
				Mesh mesh = new Mesh ();
				mesh.vertices = newVerts;
				mesh.normals = newNormals;
				mesh.uv = newUvs;
				mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };

				triangleMeshes.Add (mesh);

				GameObject GO = new GameObject ("Triangle " + (i / 3));
				GO.transform.position = transform.position;
				GO.transform.rotation = transform.rotation;
				GO.AddComponent<MeshRenderer> ().material = MR.materials [submesh];
				GO.AddComponent<MeshFilter> ().mesh = triangleMeshes [(submesh + (i / 3))];
				GO.AddComponent<BoxCollider> ();
				Rigidbody rb = GO.AddComponent<Rigidbody> ();
				rb.mass = Random.Range (0.5f, 1.0f);
				rb.AddExplosionForce (10, touch, 30, 0, ForceMode.Impulse);
				Destroy (GO, 1 + Random.Range (0.0f, 1.0f));
			}
		}
	}*/
}

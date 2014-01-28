using UnityEngine;
using System.Collections;

public class startBattle : MonoBehaviour 
{

	public GameObject vilain;

	void Start ()
	{
		StartCoroutine (VilainSpawn());
	}

	IEnumerator VilainSpawn()
	{
		while(true)
		{

			int side = Random.Range(1,200) % 2;
			float sSide = -10;
			if (side == 1)
				sSide = 10;
			Vector3 v = new Vector3(sSide,0,0);
			Instantiate (vilain, v, Quaternion.identity); 
			yield return new WaitForSeconds(1.1f);

		}
	}
}

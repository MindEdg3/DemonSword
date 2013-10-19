using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon
{
	public float damage;
	
	public float Attack (Monster target)
	{
		float ret = Random.value;
		return ret;
	}
}

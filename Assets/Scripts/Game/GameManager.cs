using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	
	private static GameManager _instance;

	public static GameManager Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType (typeof(GameManager)) as GameManager;
			}
			return _instance;
		}
	}
	
	public List<Monster> monsters = new List<Monster> ();

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

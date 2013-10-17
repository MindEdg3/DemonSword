using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
	
	private PlayerController _myPlayer;

	private PlayerController MyPlayer {
		get {
			if (_myPlayer == null) {
				_myPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
			}
			return _myPlayer;
		}
	}
	
	private Transform _myPlayerTr;

	private Transform MyPlayerTr {
		get {
			if (_myPlayerTr == null) {
				_myPlayerTr = MyPlayer.transform;
			}
			return _myPlayerTr;
		}
	}

	private NavMeshAgent _myNavigation;

	private NavMeshAgent MyNavigation {
		get {
			if (_myNavigation == null) {
				_myNavigation = GetComponent<NavMeshAgent> ();
			}
			return _myNavigation;
		}
	}

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		MyNavigation.destination = MyPlayerTr.position;
	}
}

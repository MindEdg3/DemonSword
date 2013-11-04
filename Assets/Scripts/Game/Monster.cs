using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
	public float maxHP;
	public float movementSpeed;
	public float attackSpeed;
	
	#region Properties
	private Transform _tr;

	public Transform Tr {
		get {
			if (_tr == null) {
				_tr = transform;
			}
			return _tr;
		}
	}

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
	
	private float _currentHP;
	
	public float CurrentHP {
		get {
			return _currentHP;
		}
		set {
			_currentHP = value;
		}
	}
	
	private float _currentMovementSpeed;
	
	public float CurrentMovementSpeed {
		get {
			return _currentMovementSpeed;
		}
		set {
			_currentMovementSpeed = value;
		}
	}
	
	private float _currentAttackSpeed;
	
	public float CurrentAttackSpeed {
		get {
			return _currentAttackSpeed;
		}
		set {
			_currentAttackSpeed = value;
		}
	}
	#endregion
	
	// Use this for initialization
	void Start ()
	{
		CurrentHP = maxHP;
		CurrentMovementSpeed = movementSpeed;
		CurrentAttackSpeed = attackSpeed;
		MyNavigation.speed = CurrentMovementSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		MyNavigation.destination = MyPlayerTr.position;
	}
}

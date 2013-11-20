using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
		public float speed;
		public float maxTargetDistance;
		public Monster target;
		public Weapon weapon;
	
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
	
		private Camera _myCamera;
	
		public Camera MyCamera {
				get {
						if (_myCamera == null) {
								_myCamera = Camera.main;
						}
						return _myCamera;
				}
		}

		private Transform _myCameraTr;
	
		public Transform MyCameraTr {
				get {
						if (_myCameraTr == null) {
								_myCameraTr = MyCamera.transform;
						}
						return _myCameraTr;
				}
		}
	#endregion
	
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				// clear target that gone far away
				if (target != null) {
						if ((target.Tr.position - Tr.position).sqrMagnitude > maxTargetDistance * maxTargetDistance) {
								target = null;
						}
				}
				#if UNITY_IPHONE && !UNITY_EDITOR
		if (Input.touchCount>0) {
			if (!animation.isPlaying) {
				HandleAttack ();
			}
		}
				#else
				if (Input.GetButton ("Fire1")) {
						if (!animation.isPlaying) {
								HandleAttack ();
						}
				}
				#endif
		}

		void FixedUpdate ()
		{
				Vector3 cameraRotation = MyCameraTr.rotation.eulerAngles;
				Vector3 forceDirection = Quaternion.Euler (0f, cameraRotation.y, 0f) * new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical")) * speed;
#if UNITY_IPHONE && !UNITY_EDITOR
		Vector3 dir = Vector3.zero;

		float sensitivity = 0.1f;
		float yInitialValue = 0.25f;

		if (Input.acceleration.x > sensitivity || Input.acceleration.x < -sensitivity) {
			dir.x = Input.acceleration.x;
		}
		if (Input.acceleration.y + yInitialValue > sensitivity || Input.acceleration.y + yInitialValue < -sensitivity) {
			dir.y = Input.acceleration.y + yInitialValue;
		}

		dir.Normalize();

		forceDirection = Quaternion.Euler (0f, cameraRotation.y, 0f) * new Vector3 (dir.x, 0f, dir.y) * speed;
#endif
				rigidbody.AddForce (forceDirection, ForceMode.Acceleration);
				if (forceDirection != Vector3.zero) {
						rigidbody.MoveRotation (Quaternion.LookRotation (forceDirection));
				}

		
		}
	
		/// <summary>
		/// Handles the attack.
		/// </summary>
		private void HandleAttack ()
		{
				// Get target
				if (target == null) {
						target = GetClosestTarget ();
				}
				// Attack target if it have been found
				if (target != null) {
						float resultedDamage = weapon.Attack (target);
//						Debug.Log (resultedDamage);
				}
				// Anyway play animation
				animation.Play ();
		}
	
		/// <summary>
		/// Gets the closest target.
		/// </summary>
		/// <returns>
		/// The closest target.
		/// </returns>
		private Monster GetClosestTarget ()
		{
				Monster ret = null;
		
				List<Monster> monsters = GameManager.Instance.monsters;
				float closestMonsterRange = -1f;
		
				for (int i = 0; i < monsters.Count; i++) {
						float rangeToMonster = (monsters [i].Tr.position - Tr.position).sqrMagnitude;
						if (rangeToMonster < maxTargetDistance * maxTargetDistance) {
								if (closestMonsterRange == -1f || rangeToMonster < closestMonsterRange) {
										closestMonsterRange = rangeToMonster;
										ret = monsters [i];
								}
						}
				}
		
				return ret;
		}
}

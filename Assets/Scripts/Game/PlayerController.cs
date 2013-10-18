using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
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
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			if (!animation.isPlaying) {
				Attack ();
			}
		}
	}

	void FixedUpdate ()
	{
		Vector3 cameraRotation = MyCameraTr.rotation.eulerAngles;
		Vector3 forceDirection = Quaternion.Euler (0f, cameraRotation.y, 0f) * new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical")) * speed;
		rigidbody.AddForce (forceDirection, ForceMode.Acceleration);
		if (forceDirection != Vector3.zero) {
			rigidbody.MoveRotation (Quaternion.LookRotation (forceDirection));
		}
	}

	void Attack ()
	{
		animation.Play ();
	}
}

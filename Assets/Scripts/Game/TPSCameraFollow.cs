using UnityEngine;
using System.Collections;

public class TPSCameraFollow : MonoBehaviour
{
	public Transform target;
	public Vector3 offset;
	public Vector3 lookPoint;
	public float followSpeed;
	public float rotationDelay;
	private float lastRotationTime = -1f;
	private Quaternion lastTargetRotation;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	void Update ()
	{
//		transform.position = Vector3.MoveTowards (transform.position, (target.position + (Quaternion.Euler (0f, target.rotation.eulerAngles.y, 0f) * offset)), followSpeed * Time.deltaTime);
				
//		if (lastRotationTime != -1) {
//			if (lastRotationTime + rotationDelay > Time.time) {
//			}
//		}
//		if (target.rotation != lastTargetRotation) {
//			lastRotationTime = Time.time;
//		}
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		transform.position = target.position + (Quaternion.Euler (0f, transform.rotation.eulerAngles.y, 0f) * offset);
		transform.LookAt (target.position + lookPoint);
	}
}

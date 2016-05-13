using UnityEngine;
using System.Collections;

public class FollowCamera2D : MonoBehaviour {
	public float interpVelocity, minDistance, followDistance, distanceR, distanceL, floatHeight, liftForce, damping;
	public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit2D hit = Physics2D.Raycast(target.transform.position, Vector2.right);
        if (hit.collider != null)
        {
            distanceR = hit.point.x;
        }
        if (target){
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;
		
			Vector3 targetDirection = (target.transform.position - posNoZ);
		
			interpVelocity = targetDirection.magnitude * 5f;
		
			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 
		
			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);
		}
	}
}


using UnityEngine;
using System.Collections;

public class EnemyMovement2D : MonoBehaviour {
    private float minDistance, followDistance, distanceR, distanceL, floatHeight, liftForce, damping;
    private GameObject target;
    private Vector3 offset;
    Vector3 targetPos;
    private float interpVelocity = 0.5f;
    private bool achouPlayer = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = GameObject.FindGameObjectWithTag("Player");
            targetPos = transform.position;
            achouPlayer = true;
        }
    }
    void Update() {
        if (achouPlayer) Chase();
    }

    void Chase() {
        RaycastHit2D hit = Physics2D.Raycast(target.transform.position, Vector2.right);
        if (hit.collider != null)
        {
            distanceR = hit.point.x;
        }
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 1.1f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }
}

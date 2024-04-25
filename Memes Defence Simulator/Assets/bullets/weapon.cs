using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform bullet;
    public int BulletForce = 5000;
    public GameObject spawn;
    public Camera playerCamera;

    float currentTime = 0;
    public float reloadTime = 1; // seconds
    private float maxDistance = 100;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentTime + reloadTime < Time.time)
        {
            currentTime = Time.time;
            Transform BulletInstance = Instantiate(bullet, spawn.transform.position, Quaternion.identity);
            BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);

            // Get the position of the cursor in the world
            Vector3 cursorPosition = Input.mousePosition;
            cursorPosition.z = playerCamera.nearClipPlane; // Adjust to the camera's near clip plane

            // Convert the cursor position from screen space to world space
            Vector3 targetPosition = playerCamera.ScreenToWorldPoint(cursorPosition);

            // Cast a ray from the player's position in the direction of the cursor
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (targetPosition - transform.position).normalized, out hit, maxDistance))
            {
                // Draw a visual ray from the player's position to the hit point
                Debug.DrawLine(transform.position, hit.point, Color.red, 0.1f);
            }
            else
            {
                // If the ray doesn't hit anything, draw a visual ray to the maximum distance
                Debug.DrawLine(transform.position, transform.position + (targetPosition - transform.position).normalized * maxDistance, Color.red, 0.1f);
            }

        }
    }
}

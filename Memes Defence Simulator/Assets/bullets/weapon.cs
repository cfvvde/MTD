using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform bullet;
    public int BulletForce = 5000;
    public GameObject spawn;
    public Camera playerCamera;
    public LineRenderer lineRenderer;

    float currentTime = 0;
    public float reloadTime = 1f; // seconds
    private float maxDistance = 100;

    private int tries = 500;

    void Update()
    {
        if (lineRenderer == null && tries-- > 0)
        {
            lineRenderer = GetComponent<LineRenderer>();
            return;
        }
        if (Input.GetMouseButtonDown(0) && currentTime + reloadTime < Time.time)
        {
            currentTime = Time.time;
            //Transform BulletInstance = Instantiate(bullet, spawn.transform.position, Quaternion.identity);
            //BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * BulletForce);

            // Get the position of the cursor in the world
            Vector3 cursorPosition = Input.mousePosition;
            cursorPosition.z = playerCamera.nearClipPlane; // Adjust to the camera's near clip plane

            Ray ray = playerCamera.ScreenPointToRay(cursorPosition);

            // Perform the raycast and check if it hits something
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Vector3 targetPosition = hit.point;
            if (Physics.Raycast(ray, out hit))
            {
                // Draw a visual ray from the player's position to the hit point using LineRenderer
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                // If the ray doesn't hit anything, draw a visual ray to the maximum distance
                Vector3 endPoint = transform.position + targetPosition * maxDistance;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, endPoint);
            }
        }
    }
}

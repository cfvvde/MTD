using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public int damage = 10;
    public Camera playerCamera;
    public LineRenderer lineRenderer;

    float currentTime = 0;
    public float reloadTime = 0.3f;
    private float maxDistance = 100;
    private void Awake()
    {
        if (!playerCamera && GameObject.FindWithTag("MainCamera").GetComponent<Camera>())
        {
            playerCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
    }

    void FixedUpdate()
    {
        if (!lineRenderer && GetComponent<LineRenderer>())
        {
            lineRenderer = GetComponent<LineRenderer>();
            return;
        }
        else if (!lineRenderer && !GetComponent<LineRenderer>())
        {
            Debug.LogError($"object {transform.name} has no component: 'LineRenderer'", transform);
        }

        // Make the line invisible by setting its positions to the same point
        if (currentTime + 0.1f < Time.time)
        {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }


        if (Input.GetMouseButton(0) && currentTime + reloadTime < Time.time)
        {
            currentTime = Time.time;

            Vector3 cursorPosition = Input.mousePosition;
            cursorPosition.z = playerCamera.nearClipPlane;


            Ray ray = playerCamera.ScreenPointToRay(cursorPosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);

                GameObject other = hit.transform.gameObject;
                print($"{other}");

                if (other.GetComponent<EnemyMove>())
                {
                    other.GetComponent<EnemyMove>().assignCore();
                    GameObject core = other.GetComponent<EnemyMove>().core;


                    core.GetComponent<EnemyScript>().TakeDamage(damage);
                }
                else
                    print($"he is not an enemy");
            }
            else
            {
                Vector3 forward = playerCamera.transform.forward.normalized;
                Vector3 pointInFront = playerCamera.transform.position + forward * maxDistance;

                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, pointInFront);
            }
        }
    }
}

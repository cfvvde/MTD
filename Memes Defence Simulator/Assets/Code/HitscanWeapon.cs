using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public int damage = 10;
    public Camera playerCamera;
    public LineRenderer lineRenderer;
    float lineRadius = 0;
    public float lineDecayAmount = 0.01f;
    public float maxLineRadus = 1f;

    float currentTime = 0;
    public float reloadTime = 0.3f;
    private float maxDistance = 100;
    private void Awake()
    {
        if (!playerCamera && GameObject.FindWithTag("MainCamera").GetComponent<Camera>())
        {
            playerCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
        lineRadius = maxLineRadus;
        StartCoroutine(lineDecay());
    }
    // runs every 10ms
    private IEnumerator lineDecay()
    {
        while (true)
        {
            if (lineRadius > 0)
            {
                lineRadius -= lineDecayAmount;
            }
            else
            {
                lineRenderer.enabled = false;
            }
            lineRenderer.endWidth = lineRadius;
            lineRenderer.startWidth = lineRadius;
            yield return new WaitForSeconds(0.01f);
        }
    }

    void Update()
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


        if (Input.GetMouseButton(0) && currentTime + reloadTime < Time.time)
        {
            currentTime = Time.time;
            lineRadius = maxLineRadus;

            Vector3 cursorPosition = Input.mousePosition;
            cursorPosition.z = playerCamera.nearClipPlane;


            Ray ray = playerCamera.ScreenPointToRay(cursorPosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                lineRenderer.enabled = true;
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
                lineRenderer.enabled = true;
                Vector3 forward = playerCamera.transform.forward.normalized;
                Vector3 pointInFront = playerCamera.transform.position + forward * maxDistance;

                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, pointInFront);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackscript : MonoBehaviour
{
    public GameObject sword;
    Animator animator;
    Collider rb;
  
    void Start()
    {
        rb = sword.GetComponent<BoxCollider>();
        rb.enabled = false;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.enabled = false;
            rb.enabled = true;
            animator.SetBool("attack", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            
            
            animator.SetBool("attack", false);
            rb.enabled = false;
        }
    }
}

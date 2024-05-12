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

    private void Delay()
    {
        weapon.AnimationCoolDown = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.AnimationCoolDown = true;
            rb.enabled = false;
            rb.enabled = true;
            animator.SetBool("attack", true);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            
            
            animator.SetBool("attack", false);
            rb.enabled = false;
            Invoke("Delay", 1);
        }
    }
}

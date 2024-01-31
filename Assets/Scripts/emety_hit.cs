using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emety_hit : MonoBehaviour
{
    private Animator animator;
    private Collider2D emetyCollider;
    private Rigidbody2D emetyRigidbody;

    private BoxCollider2D[] emetyColliders;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        emetyCollider = GetComponent<Collider2D>();
        emetyRigidbody = GetComponent<Rigidbody2D>();
        emetyColliders = GetComponentsInChildren<BoxCollider2D>();
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (animator != null)
            {
                animator.SetBool("isdie", true);
                StartCoroutine(DestroyAfterAnimation());
            }
            else
            {
                Destroy(gameObject);
            }

            if (emetyCollider != null)
            {
                emetyCollider.enabled = false; // Tắt collider
            }

            if (emetyRigidbody != null)
            {
                emetyRigidbody.bodyType = RigidbodyType2D.Static; // Tắt Rigidbody
            }
            foreach (var collider in emetyColliders)
            {
                collider.enabled = false; // Tắt box collider
            }
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
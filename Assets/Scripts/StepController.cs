using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private IEnumerator FallTimer()
    {
        yield return new WaitForSeconds(timer);
        rb.useGravity=true;
        Destroy(gameObject,4f);
    }
    private void OnCollisionEnter(Collision collision)
   {
      if(collision.gameObject.tag=="Player")
      {
        GameManager.Score++;
          StartCoroutine(FallTimer());
      }
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public delegate void PlatformTurn();
    public static PlatformTurn TurnPlatform;
    [SerializeField] private float moveSpeed;
    private Animator runAnim;
    public bool IsGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField]private LayerMask ground;
    private Rigidbody rb;
    public static bool IsDead;
    private void Start()
    {
        rb=GetComponent<Rigidbody>();
        runAnim=GetComponent<Animator>();
        runAnim.SetTrigger("Run");
    }
    private void Ground()
    {
        IsGrounded=Physics.CheckSphere(groundCheck.position,0.4f,ground);
        if(IsGrounded)
          rb.useGravity=false;
        else
          rb.useGravity=true;
    }
    private void PlatformControl()
    {
        if(Input.GetMouseButtonDown(0))
        {   
            if(TurnPlatform!=null)
            {  
                TurnPlatform();
                 print("aa");
            }
        }
    }
    private void Move()
    {
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
    }
    private void DeadController()
    {
        if(transform.position.y<-3f)
        {
            IsDead=true;
        }
        else
        {
            IsDead=false;
        }
    }
    private void Update()
    {
       Move();
       Ground();
       DeadController();
       PlatformControl();
    }
    //Trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Wall")
        {
           PipeSpawner pipeSpawner = other.gameObject.GetComponent<PipeSpawner>();
           if(pipeSpawner != null)
           {
               pipeSpawner.Spawn();
           }
        }
        if(other.gameObject.tag=="StepObstacle")
        {
            moveSpeed = 0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="StepObstacle")
        {
            moveSpeed = 0f;
        }
    }
}

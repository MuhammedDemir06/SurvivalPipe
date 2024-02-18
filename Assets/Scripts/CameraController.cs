using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private Transform player;
    [SerializeField]private float distance;
    private Camera cam;

    private void Start()
    {
        cam=GetComponent<Camera>();
    }
    private void Follow()
    {
        var newPos=new Vector3(10,9,player.position.z+distance);
       cam.transform.position =newPos;
    }
    private void Update()
    {
        Follow();
    }
}

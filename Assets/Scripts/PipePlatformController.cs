using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePlatformController : MonoBehaviour
{
    public void OnEnable()
    {
       CharacterControl.TurnPlatform += Turn;
    }
    public void OnDisable()
    {
       CharacterControl.TurnPlatform -= Turn;
    }
   private void Turn()
   {
     if(!CharacterControl.IsDead)
     {
        print("Turn");
        transform.Rotate(Vector3.forward * 90f);
     }
   }
    void Update()
    {
        
    }
}

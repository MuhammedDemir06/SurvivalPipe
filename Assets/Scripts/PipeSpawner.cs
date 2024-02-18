using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
   [SerializeField]private GameObject[] pipe;
   private int index;
   [SerializeField]private float addDistance;
   public void Spawn()
   {
      index=Random.Range(0,pipe.Length);
      Instantiate(pipe[index],new Vector3(0,0f,transform.position.z+addDistance),Quaternion.identity);
   }
}

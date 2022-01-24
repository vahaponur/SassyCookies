using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcala : MonoBehaviour
{
   private MeshCollider _meshCollider;
   private MeshFilter _meshFilter;
   private Mesh _mesh;
   private Vector3[] vertices;
   [SerializeField] private float radius = 0.1f;
   [SerializeField] private float power = 20;
   private void Awake()
   {
      _meshCollider = GetComponent<MeshCollider>();
      _meshFilter = GetComponent<MeshFilter>();
      _mesh = _meshFilter.mesh;
      vertices = _mesh.vertices;
   }

   private void Start()
   {
      
   }

   private void OnCollisionStay(Collision other)
   {
      if (other.gameObject.CompareTag("Needle"))
      {
         DeformThisPlane(other.contacts[0].point);
      }

    
   }

   public void DeformThisPlane(Vector3 PosToDeform)
   {
     
      PosToDeform = transform.InverseTransformPoint(PosToDeform);
      for (int i = 0; i < vertices.Length; i++)
      {
         float distance = (vertices[i] - PosToDeform).sqrMagnitude;
         
         if (distance < radius)
         {
            vertices[i] -= Vector3.up * power;

         }
      }

      _mesh.vertices = vertices;
      
   }
}

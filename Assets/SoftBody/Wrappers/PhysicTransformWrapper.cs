using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicTransformWrapper : MonoBehaviour {
  public float mass;
  public PhysicEntity.PhysicType pType;
  public PhysicTransform pTransform;
  // Start is called before the first frame update
  void Start() {
    pTransform = new PhysicTransform(transform, mass, pType);
    PhysicManagerWrapper.instance.AddPhysEnity(pTransform);
  }
  void OnValidate() {
    pTransform.Mass = mass;
    pTransform.Type = pType;
  }

}

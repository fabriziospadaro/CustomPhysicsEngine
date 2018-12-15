using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringWrapper : MonoBehaviour {
  public float stiffness = 8.0f;
  //it's the resistence the spring will have
  public float damping = 0.1f;

  public PhysicTransformWrapper A;

  public PhysicTransformWrapper B;
  private Spring spring;
  // Start is called before the first frame update
  void Start() {
    spring = new Spring(stiffness, damping, A.pTransform, B.pTransform);
    PhysicManagerWrapper.instance.AddSpring(spring);
  }
  //we don't want to allow PhysicTranform changes at runtime
  void OnValidate() {
    spring.Stiffness = stiffness;
    spring.Damping = damping;
  }

}

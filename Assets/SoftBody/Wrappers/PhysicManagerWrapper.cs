using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicManagerWrapper : MonoBehaviour {
  public Vector2 GRAVITY = new Vector2(0, -9.81f);
  public float FRICTION = 0.5F;
  public enum Processor_types { ForwardEuler };
  public Processor_types processor_type;
  public static PhysicManager instance;

  Gravity gravity;
  Medium medium;
  private void Start() {
    instance = new PhysicManager();
    instance.AddGlobalForce(GenerateGravity());
    instance.AddGlobalForce(GenerateFriction());
    instance.Processor = GetProcessor(processor_type);
  }

  Gravity GenerateGravity() {
    gravity = new Gravity(GRAVITY);
    return gravity;
  }

  Medium GenerateFriction() {
    medium = new Medium(FRICTION);
    return medium;
  }

  PhysicsProcessor GetProcessor(Processor_types type) {
    switch(type) {
      case Processor_types.ForwardEuler:
        return new ForwardEuler();
    }
    return null;
  }

  public void FixedUpdate() {
    instance.Update(Time.fixedDeltaTime);
  }

  public void OnDrawGizmos() {
    if(Application.isPlaying)
      foreach(SpringWrapper sr in FindObjectsOfType<SpringWrapper>())
        Gizmos.DrawLine(sr.A.pTransform.CurrPosition, sr.B.pTransform.CurrPosition);
  }

  void OnValidate() {
    gravity.Acceleration = GRAVITY;
    medium.DragCoefficient = FRICTION;
  }

}

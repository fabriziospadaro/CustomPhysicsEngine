using UnityEngine;
public sealed class Spring : IForce {
  private float stiffness;
  private float damping;
  private float restLength;
  private PhysicEntity pEntityA;
  private PhysicEntity pEntityB;

  public Spring(float stiffness, float damping, PhysicEntity pEntityA, PhysicEntity pEntityB)
    : this(stiffness, damping, pEntityA, pEntityB, (pEntityA.CurrPosition - pEntityB.CurrPosition).magnitude) { }

  public Spring(float stiffness, float damping, PhysicEntity pEntityA, PhysicEntity pEntityB, float restLength)
    : base() {
    this.stiffness = stiffness;
    this.damping = damping;
    this.pEntityA = pEntityA;
    this.pEntityB = pEntityB;
    this.restLength = restLength;
  }

  private Vector2 direction;
  private float currLength;
  private Vector2 force;
  public void ApplyForce(PhysicEntity pEntity = null) {
    //get the direction vector
    direction = pEntityA.CurrPosition - pEntityB.CurrPosition;
    //check for zero vector
    if(direction != Vector2.zero) {
      //get length
      currLength = direction.magnitude;
      //normalize
      direction.Normalize();
      //add spring force
      force = -stiffness * ((currLength - restLength) * direction);
      //add spring damping force
      force += -damping * Vector2.Dot(pEntityA.CurrVelocity - pEntityB.CurrVelocity, direction) * direction;
      //apply the equal and opposite forces to the objects
      pEntityA.ResultantForce += force;
      pEntityB.ResultantForce += -force;
    }
  }

  public float Stiffness {
    get { return stiffness; }
    set { stiffness = value; }
  }
  public float Damping {
    get { return damping; }
    set { damping = value; }
  }
  public PhysicEntity PEntityA {
    get { return pEntityA; }
    set { pEntityA = value; }
  }
  public PhysicEntity PEntityB {
    get { return pEntityB; }
    set { pEntityB = value; }
  }
}
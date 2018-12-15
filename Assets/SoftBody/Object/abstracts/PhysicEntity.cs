using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhysicEntity {
  public enum PhysicType { ACTIVE, PASSIVE }
  private PhysicType type;
  private float mass;
  protected Vector2 currPosition;
  protected Vector2 prevPosition;
  protected Vector2 currVelocity;
  protected Vector2 resultantForce;
  public PhysicEntity(float mass, PhysicType type) {
    this.mass = mass;
    this.type = type;
    this.currPosition = Vector2.zero;
    this.prevPosition = this.currPosition;
    this.currVelocity = Vector2.zero;
  }

  public float Mass {
    get { return mass; }
    //can't have negative mass
    set { mass = Mathf.Clamp(value, 0, value); }
  }
  public PhysicType Type {
    get { return type; }
    set { type = value; }
  }
  public Vector2 CurrPosition {
    get { return currPosition; }
    set { currPosition = value; }
  }
  public float CurrPositionX {
    get { return currPosition.x; }
    set { currPosition.x = value; }
  }
  public float CurrPositionY {
    get { return currPosition.y; }
    set { currPosition.y = value; }
  }
  public Vector2 PrevPosition {
    get { return prevPosition; }
    set { prevPosition = value; }
  }
  public Vector2 CurrVelocity {
    get { return currVelocity; }
    set { currVelocity = value; }
  }
  public Vector2 ResultantForce {
    get { return resultantForce; }
    //we may wanna limit the max force for an object
    set { resultantForce = value; }
  }
  public void ResetForces() {
    this.resultantForce = Vector2.zero;
  }
  public abstract void Update();
}

using UnityEngine;
public sealed class Gravity : IForce {
  private Vector2 acceleration;

  public Gravity()
    : this(new Vector2(0, -9.81f)) { }

  public Gravity(Vector2 acceleration) : base() {
    Acceleration = acceleration;
  }

  public Vector2 Acceleration {
    get { return acceleration; }
    set { acceleration = value; }
  }
  public float AccelerationX {
    get { return acceleration.x; }
    set { acceleration.x = value; }
  }
  public float AccelerationY {
    get { return acceleration.y; }
    set { acceleration.y = value; }
  }
  public void ApplyForce(PhysicEntity pEntity) {
    pEntity.ResultantForce += pEntity.Mass * acceleration;
  }
}

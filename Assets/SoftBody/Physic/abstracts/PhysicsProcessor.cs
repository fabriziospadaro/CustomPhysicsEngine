using UnityEngine;
public abstract class PhysicsProcessor {
  public abstract void Process(Vector2 acceleration, PhysicEntity pEntity, float time);
}
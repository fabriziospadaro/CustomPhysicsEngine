using UnityEngine;

public class ForwardEuler : PhysicsProcessor {
  public override void Process(Vector2 acceleration, PhysicEntity pEntity, float time) {
    pEntity.CurrPosition += pEntity.CurrVelocity * time;
    pEntity.CurrVelocity += acceleration * time;
  }
}

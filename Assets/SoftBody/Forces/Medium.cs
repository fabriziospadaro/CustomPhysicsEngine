public sealed class Medium : IForce {
  private float dragCoefficient;
  public float DragCoefficient {
    get { return dragCoefficient; }
    set { dragCoefficient = value; }
  }
  //--------------------------------------------------------
  public Medium(float dragCoefficient) {
    this.dragCoefficient = dragCoefficient;
  }
  public void ApplyForce(PhysicEntity pEntity) {
    pEntity.ResultantForce += -dragCoefficient * pEntity.CurrVelocity;
  }
}
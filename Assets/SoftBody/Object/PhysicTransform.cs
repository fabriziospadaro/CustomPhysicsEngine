using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicTransform : PhysicEntity {
  private Transform pTransform;
  public PhysicTransform(Transform _pTransform, float _mass, PhysicType type) : base(_mass, type) {
    this.pTransform = _pTransform;
    this.currPosition = this.pTransform.position;
    this.prevPosition = this.currPosition;
  }
  public Transform PTransform {
    get { return pTransform; }
    set { pTransform = value; }
  }
  public override void Update() {
    this.pTransform.position = this.currPosition;
  }
}

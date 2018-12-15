using System.Collections.Generic;
using UnityEngine;

public class PhysicManager {

  protected List<PhysicEntity> pEntities = new List<PhysicEntity>();
  protected List<IForce> globalForces = new List<IForce>();
  protected List<Spring> springs = new List<Spring>();
  protected PhysicsProcessor processor;

  public List<PhysicEntity> PEntities {
    get { return pEntities; }
    set { pEntities = value; }
  }
  public PhysicsProcessor Processor {
    get { return processor; }
    set { processor = value; }
  }
  //------------------------------------------------------------------
  public PhysicManager() {
    //create a default integrator
    this.processor = new ForwardEuler();
  }
  public void AddSpring(Spring spring) {
    springs.Add(spring);
  }
  public void AddPhysEnity(PhysicEntity simObject) {
    pEntities.Add(simObject);
  }
  public void AddGlobalForce(IForce force) {
    globalForces.Add(force);
  }

  public IForce GetForceByType(System.Type force) {
    foreach(IForce i in globalForces) {
      if(i.GetType() == force)
        return i;
    }
    return null;
  }

  Vector2 acceleration;
  public virtual void Update(float time) {
    foreach(Spring spring in springs) {
      spring.ApplyForce();
    }

    //sum all global forces acting on the objects
    foreach(PhysicEntity pEntity in pEntities) {
      if(pEntity.Type == PhysicEntity.PhysicType.ACTIVE) {
        foreach(IForce force in globalForces) {
          force.ApplyForce(pEntity);
        }
        acceleration = pEntity.ResultantForce / pEntity.Mass;
        processor.Process(acceleration, pEntity, time);
      }
      pEntity.Update();
      if(pEntity.Type == PhysicEntity.PhysicType.ACTIVE) {
        pEntity.ResetForces();
      }
    }

  }
}
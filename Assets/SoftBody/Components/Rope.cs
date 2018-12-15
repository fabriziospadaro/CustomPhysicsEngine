using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

  public Color startColor;
  public SpringWrapper spring;
  public float elasticity = 1;

  private int numPoints = 20;
  private float dst;
  private Vector2[] points;
  private int steps = 20;
  private Gravity gravity;
  LineRenderer lineRenderer;
  private float strenght;
  private float startLenght;
  private float RopeLenght() {
    return (start - end).magnitude;
  }
  // Use this for initialization
  void Start() {
    startLenght = RopeLenght();
    gravity = (Gravity)PhysicManagerWrapper.instance.GetForceByType(typeof(Gravity));
    dst = startLenght;
    numPoints = (int)(startLenght * 10f);
    strenght = startLenght * 100 / (elasticity);

    lineRenderer = GetComponent<LineRenderer>();
    lineRenderer.startColor = startColor;
    lineRenderer.endColor = startColor;

    lineRenderer.positionCount = numPoints;
    points = new Vector2[numPoints];

    for(int i = 0; i < numPoints; i++) {
      float p = i / (numPoints - 1f);
      points[i] = Vector2.Lerp(start, end, p);
    }

    for(int i = 0; i < 200; i++) {
      UpdateRope();
    }
  }

  void FixedUpdate() {
    UpdateRope();

    for(int i = 0; i < lineRenderer.positionCount; i++) {
      lineRenderer.SetPosition(i, (Vector3)points[i] + Vector3.forward * -.3f);
    }

  }

  void UpdateRope() {
    float S = strenght;
    points[0] = start;
    points[points.Length - 1] = end;

    for(int ik = 0; ik < steps; ik++) {
      for(int i = 1; i < points.Length - 1; i++) {
        Vector2 offsetPrev = (points[i - 1] - points[i]);
        Vector2 offsetNext = points[i + 1] - points[i];
        Vector2 velocity = offsetPrev.normalized * offsetPrev.magnitude * S + offsetNext.normalized * offsetNext.magnitude * S;
        points[i] += velocity * Time.deltaTime / steps;
      }
      for(int i = 1; i < points.Length - 1; i++) {
        points[i] += gravity.Acceleration * Time.deltaTime / steps;
      }
    }
  }
  private void OnValidate() {
    strenght = startLenght * 100 / (elasticity);
    strenght = Mathf.Clamp(strenght, 1, strenght);
  }


  Vector2 start {
    get {
      return spring.A.transform.position;
    }
  }

  Vector2 end {
    get {
      return spring.B.transform.position;
    }
  }
}
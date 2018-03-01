﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Road : MonoBehaviour {
	public RoadControlPoint controlPointTemplate;

	private LineRenderer lineRenderer;
	private List<RoadControlPoint> controlPoints;

	private const int SEGMENT_COUNT = 20; // Number of line segments per curve, increase this number for a smoother line

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		controlPoints = new List<RoadControlPoint> ();

		CreateControlPoint (new Vector3(0f, 0f, 0f));
		CreateControlPoint (new Vector3 (1f, 4f, 6f));
		CreateControlPoint (new Vector3 (5f, 1f, 6f));
		CreateControlPoint (new Vector3(7f, 0f, 7f));

		lineRenderer.positionCount = SEGMENT_COUNT;

		UpdateCurve ();
	}

	void CreateControlPoint(Vector3 position) {
		RoadControlPoint newPoint = (RoadControlPoint)GameObject.Instantiate (controlPointTemplate);
		newPoint.transform.position = position;
		newPoint.road = this;
		newPoint.transform.parent = this.transform;
		controlPoints.Add(newPoint);
	}

	public void UpdateCurve() {
		for (int i = 0; i < SEGMENT_COUNT; i++) {
			float t = i / (float)(SEGMENT_COUNT - 1);

			Vector3 point = CalculateBezier (t, controlPoints);
			lineRenderer.SetPosition(i, point);
		}
	}

	Vector3 CalculateBezier(float t, List<RoadControlPoint> points) {
		int count = points.Count;
		if (count > 2) {
			return (1 - t) * CalculateBezier(t, points.GetRange(0, count - 1)) * t + t * CalculateBezier(t, points.GetRange(1, count - 1)) * t;
		} else {
			return Vector3.Lerp (points [0].transform.position, points [1].transform.position, t);
		}
	}
}

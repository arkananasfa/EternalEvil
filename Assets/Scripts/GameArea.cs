using System;
using System.Collections;
using UnityEngine;

public class GameArea : MonoBehaviour {

    private EdgeCollider2D edgeCollider;

    private void Awake() {
        SetCollider();
        StartCoroutine(ReduceSize());
    }

    private float timeDelay = 0.1f;
    private int maxSteps = 600;

    private void SetCollider() {
        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
        if (poly == null) {
            poly = gameObject.AddComponent<PolygonCollider2D>();
        }
        int len = poly.points.Length;
        Vector2[] points = new Vector2[len + 1];
        for (int i = 0; i < len; i++) points[i] = poly.points[i];
        points[len] = points[0];
        edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        edgeCollider.points = points;
        Destroy(poly);
    }

    private IEnumerator ReduceSize() {
        for (int i = 0; i < maxSteps; i++) {
            transform.localScale -= Vector3.one / 800;
            yield return new WaitForSeconds(timeDelay);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == (int)ObjectsLayers.Obstacle)
            other.gameObject.SetActive(false);
    }

}
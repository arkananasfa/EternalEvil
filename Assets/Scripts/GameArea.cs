using System;
using System.Collections;
using UnityEngine;

public class GameArea : MonoBehaviour {
    
    private Vector3 startSize;
    private readonly float timeDelay = 0.1f;
    private readonly int maxSteps = 600;

    private IEnumerator reduceSize;

    private void Awake() {
        SetCollider();
    }

    private void OnEnable() {
        GameLoopEvents.OnRoundStarted += ReduceSize;
        GameLoopEvents.OnRoundEnded += RestoreSize;
    }

    private void OnDisable() {
        GameLoopEvents.OnRoundStarted -= ReduceSize;
        GameLoopEvents.OnRoundEnded -= RestoreSize;
    }
    
    private void SetCollider() {
        PolygonCollider2D poly = GetComponent<PolygonCollider2D>();
        if (poly == null) {
            poly = gameObject.AddComponent<PolygonCollider2D>();
        }
        int len = poly.points.Length;
        Vector2[] points = new Vector2[len + 1];
        for (int i = 0; i < len; i++) points[i] = poly.points[i];
        points[len] = points[0];
        EdgeCollider2D edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        edgeCollider.points = points;
        startSize = transform.localScale;
        Destroy(poly);
    }

    private void ReduceSize() {
        reduceSize = ReduceSizeRoutine();
        StartCoroutine(reduceSize);
    }
    
    private IEnumerator ReduceSizeRoutine() {
        for (int i = 0; i < maxSteps; i++) {
            transform.localScale -= Vector3.one / 800;
            yield return new WaitForSeconds(timeDelay);
        }
    }

    private void RestoreSize() {
        StopCoroutine(reduceSize);
        transform.localScale = startSize;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.layer == (int)ObjectsLayers.Obstacle)
            other.gameObject.SetActive(false);
    }

}
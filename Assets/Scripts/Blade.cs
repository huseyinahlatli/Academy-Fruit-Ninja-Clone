using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject bladeTrailPrefab;
    private Rigidbody2D rigidbody;
    private Camera camera;
    private GameObject currentBladeTrail;
    private CircleCollider2D circleCollider;
   
    [Header("Values")]
    [SerializeField] private float minCuttingVelocity = 0.001f;
    private bool isCutting = false;
    private Vector2 previousPosition;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCutting();
        else if (Input.GetMouseButtonUp(0))
            StopCutting();

        if (isCutting)
        {
            UpdateCutting();
        }
    }

    private void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void UpdateCutting()
    {
        Vector2 newPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        rigidbody.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (velocity > minCuttingVelocity)
            circleCollider.enabled = true;
        
        previousPosition = newPosition;
    }

    private void StopCutting()
    { 
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }
}

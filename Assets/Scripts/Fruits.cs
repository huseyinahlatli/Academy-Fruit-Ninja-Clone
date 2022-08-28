using System;
using UnityEngine;
using TMPro;
public class Fruits : MonoBehaviour
{
    
    [SerializeField] private GameObject fruitSlicedPrefab;
    [SerializeField] private float startForce = 12.5f;
    private Rigidbody2D rigidbody;
    private const int point = 5;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Blade"))
        {
            Vector3 direction = (collider.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            
            GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            Destroy(gameObject);
            Destroy(slicedFruit, 4f);

            UI.Instance.SetScore(point);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Rigidbody rigidbody;

    private void Awake()
    {
        Debug.Assert(rigidbody != null, "rigidbody cannot be null");
        Debug.Assert(speed > 0, "speed has to be more than zero");
    }
    
    public void Init(Transform direction)
    {
        Move(direction);
    }

    private void Move(Transform direction)
    {
        rigidbody.velocity = direction.transform.forward * speed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var target = other.gameObject.GetComponent<IDamageable>();
        target?.TakeHit(damage);
        Destroy(gameObject);
    }
}

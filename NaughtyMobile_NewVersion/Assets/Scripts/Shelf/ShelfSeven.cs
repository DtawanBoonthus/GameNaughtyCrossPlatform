using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ShelfSeven : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var target = other.gameObject.GetComponent<IOpenShelfSeven>();
        target?.OpenShelfSeven();
    }
}

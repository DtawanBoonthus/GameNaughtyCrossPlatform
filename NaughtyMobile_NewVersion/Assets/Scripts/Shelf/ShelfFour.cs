using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ShelfFour : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var target = other.gameObject.GetComponent<IOpenShelfFour>();
        target?.OpenShelfFour();
    }
}

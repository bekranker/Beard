using InteractingObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpadManager))]
public class JumpadDedectionManager : MonoBehaviour
{
    [Space(15)]
    [Header("-----Components-----")]
    [Space(15)]
    [SerializeField] private JumpadManager _JumpadManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ObjectManager objectManager))
        {
            _JumpadManager.JumpObject(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
}

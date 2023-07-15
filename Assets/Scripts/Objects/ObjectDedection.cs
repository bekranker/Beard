using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractingObjects
{



    /// <summary>
    /// This Class is working on object detection where we wanna to be beard or not beard to the objects
    /// </summary>





    public class ObjectDedection : MonoBehaviour
    {
        [Header("----Components-----")]
        [SerializeField] private ObjectManager _ObjectManager;
        [Space(25)]
        [Header("-----Layers-----")]
        [SerializeField] private LayerMask _TouchableColliderLayers;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_TouchableColliderLayers == LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)))
            {
                if (collision.gameObject.TryGetComponent(out ObjectManager objectManager))
                {
                    _ObjectManager.DedectedObjects.Add(objectManager);
                    _ObjectManager.DedectionAction(objectManager);
                }
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ObjectManager objectManager))
            {
                if (_ObjectManager.DedectedObjects.Contains(objectManager))
                {
                    _ObjectManager.DedectedObjects.Remove(objectManager);
                }
            }
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace InteractingObjects
{
    public class ScissorsManager : MonoBehaviour
    {

        private List<ObjectManager> _dedectedObjects = new List<ObjectManager>();
        public void CutTheBeard(ObjectManager objectManager)
        {
            objectManager.myState = States.ObjectState.WithoutBeard;
            objectManager.IsTouchingScissors = true;
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ObjectManager objectManager))
            {
                if (!_dedectedObjects.Contains(objectManager))
                {
                    _dedectedObjects.Add(objectManager);
                    CutTheBeard(objectManager);
                }
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ObjectManager objectManager))
            {
                if (_dedectedObjects.Contains(objectManager))
                {
                    objectManager.IsTouchingScissors = false;
                    _dedectedObjects.Remove(objectManager);
                }
            }
            
        }


    }
}


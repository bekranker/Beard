using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
using System;

namespace States
{
    public enum ObjectState
    {
        WithBeard,
        WithoutBeard,
        Freeze,
    }
}

namespace InteractingObjects
{
    public class ObjectManager : MonoBehaviour
    {
        public ObjectState myState = ObjectState.WithoutBeard;
        public List<ObjectManager> DedectedObjects = new List<ObjectManager>();
        public bool IsTouchingScissors = false;
        public event Action OnDedection;

        [SerializeField] private ObjectSpriteManager _ObjectSpriteManager;
        [SerializeField] private PhysicsMaterial2D WithFriction, WithoutFriction;
        [SerializeField] private Collider2D _Collider2D;


        public void DedectionAction(ObjectManager objectManager)
        {
            if (IsTouchingScissors) return;
            MultipleChangeState(objectManager);
        }
        private void MultipleChangeState(ObjectManager objectManager)
        {
            if (MyState(ObjectState.Freeze)) return;
            if (MyState(ObjectState.WithBeard)) return;

            if (objectManager.MyState(ObjectState.WithBeard))
            {
                ChangeState(ObjectState.WithBeard);
                DedectedObjects?.ForEach((dedectedObject) =>
                {
                    if (dedectedObject != objectManager)
                    {
                        dedectedObject.DedectedObjects.ForEach((obj) =>
                        {
                            dedectedObject.DedectionAction(obj);
                        });
                    }
                });
            }
            OnDedection?.Invoke();
        }
        public void ChangeState(ObjectState state)
        {
            myState = state;
            _ObjectSpriteManager.SetSprite();
            ChangeFriction();
        }
        public bool MyState(ObjectState state) => state == myState ? true : false;
        private void ChangeFriction()
        {
            if (myState == ObjectState.Freeze)
            {
                _Collider2D.sharedMaterial = WithoutFriction;
            }
            else
                _Collider2D.sharedMaterial = WithFriction;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;


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
        [SerializeField] private ObjectSpriteManager _ObjectSpriteManager;
        public bool IsTouchingScissors = false;


        public void DedectionAction(ObjectManager objectManager)
        {
            if (IsTouchingScissors) return;
            ChangeState(objectManager);
        }
        private void ChangeState(ObjectManager objectManager)
        {
            if (MyState(ObjectState.Freeze)) return;
            if (MyState(ObjectState.WithBeard)) return;

            if (objectManager.MyState(ObjectState.WithBeard))
            {
                myState = ObjectState.WithBeard;
                _ObjectSpriteManager.SetSprite(_ObjectSpriteManager._WithBeardColor);
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
        }
        public bool MyState(ObjectState state) => state == myState ? true : false;
    }
}

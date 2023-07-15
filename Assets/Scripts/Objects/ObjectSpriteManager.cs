using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;


namespace InteractingObjects
{

    /// <summary>
    /// This Class is for just Changing the sprite
    /// </summary>


    public class ObjectSpriteManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _Sp;
        [SerializeField] public Color _WithBeardColor, _WithoutBeardColor, _FreezedBeardColor;
        [SerializeField] private ObjectManager _ObjectManager;

        private void Start()
        {
            SetSprite();
        }
        //Changing Sprite with selecting Sprite Type
        public void SetSprite()
        {
            //its working with colors temporary

            switch (_ObjectManager.myState)
            {
                case ObjectState.WithBeard:
                    SetSprite(_WithBeardColor);
                    break;
                case ObjectState.WithoutBeard:
                    SetSprite(_WithoutBeardColor);
                    break;
                case ObjectState.Freeze:
                    SetSprite(_FreezedBeardColor);
                    break;
                default:
                    break;
            }
        }
        //Sprite Change
        public void SetSprite(Color color) => _Sp.color = color;
    }
}
using InteractingObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagWalkyBlock : MonoBehaviour
{
    [SerializeField] private ObjectManager _ObjectManager;
    [SerializeField] private WalkyBlockMovement _WalkyBlockMovement;

    private void OnEnable()
    {
        _ObjectManager.OnDedection += WalkyWalk;
    }
    private void OnDisable()
    {
        _ObjectManager.OnDedection -= WalkyWalk;
    }

    private void WalkyWalk()
    {
        if (_ObjectManager.myState == States.ObjectState.WithBeard)
        {
            _WalkyBlockMovement.enabled = true;
        }
        else
        {
            _WalkyBlockMovement.enabled = false;
        }
    }
}

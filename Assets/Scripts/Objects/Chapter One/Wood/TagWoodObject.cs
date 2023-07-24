using UnityEngine;


namespace Chapter1
{
    public class TagWoodObject : MonoBehaviour
    {
        [SerializeField, Range(0.05f, 10)] private float _BreakPoint;
        public void BreakMe(float force)
        {
            if (force < _BreakPoint) return;
            print("I broked");
            Destroy(gameObject);
        }
    }
}


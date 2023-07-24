using UnityEngine;

namespace Chapter2
{
    public class TagIceObject : MonoBehaviour
    {
        public void VaporizeMe()
        {
            print("Vaporized");
            Destroy(gameObject);
        }
    }
}



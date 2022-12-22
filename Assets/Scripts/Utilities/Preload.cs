using UnityEngine;

namespace JRPG.Utilities
{
    public class Preload : MonoBehaviour
    {
        //This doesn't do much now, but I need to set 60FPS due to timed hits.
        void Start()
        {
            Application.targetFrameRate = 60;
        }
    }
}

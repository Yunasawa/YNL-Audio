#if YNL_UTILITIES
using UnityEngine;
using YNL.Extensions.Methods;

namespace YNL.Audios.AudioBarrier
{
    public class AudioListenerSetup : MonoBehaviour
    {
        private SphereCollider _collider;

        private void Awake()
        {
            _collider = this.GetOrAddComponent<SphereCollider>();
            _collider.radius = 0.1f;
            _collider.isTrigger = true;
        }
    }
}
#endif
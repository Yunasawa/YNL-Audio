using UnityEditor;
using UnityEngine;
#if YNL_EDITOR
using YNL.Editors.Extensions;
#endif
#if YNL_UTILITIES
using YNL.Extensions.Methods;
#endif

namespace YNL.Audios.Barrier
{
    public class AudioListenerSetup : MonoBehaviour
    {
        private SphereCollider _collider;

        private void Awake()
        {
#if YNL_UTILITIES
            _collider = this.GetOrAddComponent<SphereCollider>();
            _collider.radius = 0.1f;
            _collider.isTrigger = true;
#endif
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AudioListenerSetup))]
    public class AudioListenerEditor : Editor
    {
        private AudioListenerSetup _main;

        private void OnEnable()
        {
            _main = this.target as AudioListenerSetup;
#if YNL_UTILITIES
            if (!_main.HasComponent<UnityEngine.AudioListener>()) _main.gameObject.AddComponent<UnityEngine.AudioListener>();
#endif
#if YNL_EDITOR
            EditorTag.AddTag("Audio Listener");
            _main.gameObject.tag = "Audio Listener";
#endif
        }

        public override void OnInspectorGUI() { }
    }
#endif
}
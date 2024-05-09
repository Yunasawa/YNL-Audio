using UnityEditor;
using UnityEngine;
using YNL.Editors.Extensions;
using YNL.Extensions.Methods;

namespace YNL.Audio.Barrier
{
    public class AudioSourceSetup : MonoBehaviour
    {
        private SphereCollider _collider;

        private void Awake()
        {
            _collider = this.GetOrAddComponent<SphereCollider>();
            _collider.radius = 0.2f;
            _collider.isTrigger = true;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AudioSourceSetup))]
    public class AudioSourceEditor : Editor
    {
        private AudioSourceSetup _main;
        private AudioSource _source;

        private void OnEnable()
        {
            _main = this.target as AudioSourceSetup;
            
            EditorTag.AddTag("Audio Source");
            _main.gameObject.tag = "Audio Source";

            _source = _main.GetOrAddComponent<AudioSource>();
            _source.spatialBlend = 1;
        }

        public override void OnInspectorGUI() { }
    }
#endif
}
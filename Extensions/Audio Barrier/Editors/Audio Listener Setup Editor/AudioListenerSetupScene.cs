#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEditor;
using YNL.Audios.AudioBarrier;
using YNL.Editors.Extensions;
using YNL.Extensions.Methods;

public partial class AudioListenerSetupEditor : Editor
{
    private AudioListenerSetup _main;

    private void OnEnable()
    {
        _main = this.target as AudioListenerSetup;

        if (!_main.HasComponent<UnityEngine.AudioListener>()) _main.gameObject.AddComponent<UnityEngine.AudioListener>();

        EditorTag.AddTag("Audio Listener");
        _main.gameObject.tag = "Audio Listener";
    }

    public override void OnInspectorGUI() { }
}
#endif
#endif
#endif
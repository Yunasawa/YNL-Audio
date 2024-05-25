#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Audios.Statics;
using YNL.Editors.UIElements.Flexs;
using YNL.Editors.Windows.Utilities;
using YNL.Extensions.Addons;

namespace YNL.Audios.AudioBarrier
{
    [CustomEditor(typeof(AudioListenerSetup))]
    [CanEditMultipleObjects]
    public partial class AudioListenerSetupEditor : Editor
    {
        private VisualElement _root;

        public override VisualElement CreateInspectorGUI()
        {
            FindProperties();
            InitializeEditor();
            Compose();

            return _root;
        }

        private void FindProperties()
        {

        }

        private void InitializeEditor()
        {
            _root = new VisualElement();
        }

        private void Compose()
        {
            _root.SetAsFlexInsppector();

            _root.AddElements(new FlexComponentHeader()
                .SetGlobalColor("#FDC008")
                .AddIcon("Textures/Icons/Audio Listener", MAddressType.Resources).SetIconColor(Color.white)
                .AddTitle("Audio Listener Setup")
                .AddDocumentation(StaticLink.AudioBarrierDocumentation));
        }
    }
}
#endif
#endif
#endif
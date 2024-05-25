#if UNITY_EDITOR && YNL_EDITOR && YNL_UTILITIES
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.Windows.Utilities;
using YNL.Extensions.Methods;

namespace YNL.Audios.AudioBarrier
{
    public class EnableGizmosBox : VisualElement
    {
        private const string _styleSheet = "Style Sheets/EnableGizmosBox";

        private Color _globalColor = "#FDC008".ToColor();

        private Label _label;
        private Button _toggle;

        private SerializedProperty _boolProperty;

        public EnableGizmosBox(SerializedProperty property, string label = "")
        {
            _boolProperty = property;

            this.AddStyle(_styleSheet, EStyleSheet.Font).AddClass("Main");

            _label = new Label().AddClass("Label");
            _label.SetText(label == "" ? property.name : label);

            _toggle = new Button().AddClass("Toggle");
            _toggle.clicked += ChangeBool;

            this.AddElements(_label, _toggle);

            this.RegisterCallback<MouseDownEvent>(OnMouseDown);
            this.RegisterCallback<MouseEnterEvent>(OnMouseEnter);
            this.RegisterCallback<MouseLeaveEvent>(OnMouseLeave);

            UpdateToggle();
        }

        #region Initialization
        private void OnMouseDown(MouseDownEvent e)
        {
            ChangeBool();
        }
        
        private void OnMouseEnter(MouseEnterEvent e)
        {
            this.EnableClass("Main_Enter");
        }

        private void OnMouseLeave(MouseLeaveEvent e)
        {
            this.DisableClass("Main_Enter");
        }

        private void ChangeBool()
        {
            _boolProperty.boolValue = !_boolProperty.boolValue;
            _boolProperty.serializedObject.ApplyModifiedProperties();

            UpdateToggle();
        }

        private void UpdateToggle()
        {
            if (_boolProperty.boolValue) _toggle.EnableClass("Toggle_True");
            else _toggle.DisableClass("Toggle_True");
        }
        #endregion

        #region Style
        public EnableGizmosBox SetBoxWidth(float width, bool isPercent = false)
        {
            if (width == -1) this.SetWidth(StyleKeyword.Auto);
            else this.SetWidth(width, isPercent);

            return this;
        }
        #endregion
    }
}
#endif
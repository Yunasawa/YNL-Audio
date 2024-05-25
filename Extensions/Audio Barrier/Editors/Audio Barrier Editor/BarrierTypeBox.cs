#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.Windows.Utilities;
using YNL.Extensions.Methods;

namespace YNL.Audios.AudioBarrier
{
    public class BarrierTypeBox : VisualElement
    {
        private const string _styleSheet = "Style Sheets/BarrierTypeBox";

        private Label _label;
        private Image _typeContainer;

        private SerializedProperty _property;

        private List<BarrierTypeToggle> _toggles = new();

        public BarrierTypeBox(SerializedProperty property)
        {
            _property = property;

            this.AddStyle(_styleSheet, EStyleSheet.Font).AddClass("Main");

            _label = new Label("Type").AddClass("Label");
            _typeContainer = new Image().AddClass("TypeContainer");

            _toggles.Add(new BarrierTypeToggle(this, BarrierType.Sphere, "Textures/Sphere Icon".LoadResource<Texture2D>()));
            _toggles.Add(new BarrierTypeToggle(this, BarrierType.Box, "Textures/Cube Icon".LoadResource<Texture2D>()));
            _toggles.Add(new BarrierTypeToggle(this, BarrierType.Cylinder, "Textures/Cylinder Icon".LoadResource<Texture2D>()));

            foreach (var toggle in _toggles) _typeContainer.AddElements(toggle);

            this.AddElements(_label, _typeContainer);

            SelectType((BarrierType)property.intValue);
        }

        public void SelectType(BarrierTypeToggle typeToggle)
        {
            foreach (var toggle in _toggles) toggle.Deselect();
            typeToggle.Select();

            _property.intValue = (int)typeToggle.Type;
            _property.serializedObject.ApplyModifiedProperties();
        }

        public void SelectType(BarrierType type)
        {
            foreach (var toggle in _toggles) toggle.Deselect();
            _toggles.Find(i => i.Type == type).Select();

            _property.intValue = (int)type;
            _property.serializedObject.ApplyModifiedProperties();
        }
    }

    public class BarrierTypeToggle : VisualElement
    {
        private const string _styleSheet = "Style Sheets/BarrierTypeToggle";

        private Image _icon;
        private BarrierTypeBox _root;
        public BarrierType Type;

        public BarrierTypeToggle(BarrierTypeBox root, BarrierType type, Texture2D image)
        {
            _root = root;
            Type = type;

            this.AddStyle(_styleSheet).AddClass("Main");

            _icon = new Image().AddClass("Icon").SetBackgroundImage(image);

            this.AddElements(_icon);

            this.RegisterCallback<MouseDownEvent>(MouseDown);
            this.RegisterCallback<MouseEnterEvent>(MouseEnter);
            this.RegisterCallback<MouseLeaveEvent>(MouseLeave);
        }

        public void Select()
        {
            this.EnableClass("Main_Selected");
            _icon.EnableClass("Icon_Selected");
        }

        public void Deselect()
        {
            this.DisableClass("Main_Selected");
            _icon.DisableClass("Icon_Selected");
        }

        private void MouseDown(MouseDownEvent evt)
        {
            _root.SelectType(this);
            evt.StopPropagation();
        }
        private void MouseEnter(MouseEnterEvent evt)
        {
            evt.StopPropagation();
        }
        private void MouseLeave(MouseLeaveEvent evt)
        {
            evt.StopPropagation();
        }
    }
}
#endif
#endif
#endif
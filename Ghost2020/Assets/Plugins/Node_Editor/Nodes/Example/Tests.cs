using NodeEditorFramework.Utilities;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [Node(false, "Example/Tests")]
    public class Tests : Node
    {
        public const string ID = "tests";
        public override string GetID { get { return ID; } }

        public override string Title { get { return "Tests"; } }
        public override Vector2 DefaultSize { get { return new Vector2(150, 260); } }

        [ValueConnectionKnob("Input", Direction.In, "Float")]
        public ValueConnectionKnob inputKnob;
        [ValueConnectionKnob("Output", Direction.Out, "Float")]
        public ValueConnectionKnob outputKnob;

        public string text = "";

        public override void NodeGUI()
        {
            this.backgroundColor = Color.red;

            RTEditorGUI.PrefixLabel(new Rect(3, 35, 100, 50), new GUIContent(text), new GUIStyle());

            if (Event.current != null && Event.current.type == EventType.MouseUp && Event.current.button == 0)
            {
                text = "YEEEEAAAAHHHH";
            }

            if (GUI.changed)
                NodeEditor.curNodeCanvas.OnNodeChange(this);

            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();

            inputKnob.DisplayLayout();

            GUILayout.EndVertical();
            GUILayout.BeginVertical();

            outputKnob.DisplayLayout();

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

        }

        public override bool Calculate()
        {
            outputKnob.SetValue<float>(inputKnob.GetValue<float>() * 5);
            return true;
        }
    }
}
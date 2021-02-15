using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using System;
using System.IO;
using UnityEditor;

[Node(false, "GHOST/Characters/1c. Background")]
public class Background : Node
{
    public const string ID = "ghost_background";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Background"; } }
    public override Vector2 DefaultSize { get { return new Vector2(320, 100); } }

    [ValueConnectionKnob("", Direction.In, "BackgroundType", NodeSide.Top)]
    public ValueConnectionKnob bgKnob;

    public string textDesc = "";
    public string chName = "";

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        bgKnob.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        //#if UNITY_EDITOR
        /*#else
		GUILayout.Label (new GUIContent ("Calculation Type: " + type.ToString (), 
			"The type of calculation performed on Input 1 and Input 2"));
#endif*/

        RTEditorGUI.PrefixLabel(new Rect(3, 10, 100, 50), new GUIContent("Insert " + chName + "'s Background Here"), new GUIStyle());
        GUIStyle style = GUI.skin.box;
        textDesc = EditorGUI.TextArea(new Rect(3, 25, size.x - 6, style.CalcHeight(new GUIContent(textDesc), size.x - 3)), textDesc);

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        chName = bgKnob.GetValue<string>();
        return true;
    }
}
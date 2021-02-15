using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using System;
using System.IO;
using UnityEditor;

[Node(false, "GHOST/Characters/5. Second Turning Point")]
public class SecondTurningPoint : Node
{
    public const string ID = "ghost_secondTurningPoint";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Second Turning Point"; } }
    public override Vector2 DefaultSize { get { return new Vector2(320, 200); } }

    [ValueConnectionKnob("", Direction.In, "MidPointType", NodeSide.Left, 20)]
    public ValueConnectionKnob knownInputKnob;
    [ValueConnectionKnob("Renewal ", Direction.Out, "SecondTurningPointType")]
    public ValueConnectionKnob renewalOutputKnob;

    public enum StoryPoint
    {
        PreEvents, SecondLevelSetup, FirstLevelConfrontation, FirstLevelResolution,
        SecondLevelResolution, None
    }
    public StoryPoint point = StoryPoint.None;
    
    public string textDesc = "";

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        renewalOutputKnob.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        //#if UNITY_EDITOR

        point = (StoryPoint)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("2nd Turning Point Node", ""), point);

        /*#else
		GUILayout.Label (new GUIContent ("Calculation Type: " + type.ToString (), 
			"The type of calculation performed on Input 1 and Input 2"));
#endif*/

        RTEditorGUI.Seperator();
        RTEditorGUI.PrefixLabel(new Rect(3, 45, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());
        GUIStyle style = GUI.skin.box;
        textDesc = EditorGUI.TextArea(new Rect(3, 60, size.x - 6, style.CalcHeight(new GUIContent(textDesc), size.x - 3)), textDesc);

        if (GUI.Button(new Rect(10, 150, size.x - 20, 25), "Generate"))
            generate();

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        renewalOutputKnob.SetValue<int>((int)point);
        return true;
    }

    public void generate()
    {
        StoryPoint tmp = (StoryPoint)UnityEngine.Random.Range(0, 5);
        point = tmp;
    }
}
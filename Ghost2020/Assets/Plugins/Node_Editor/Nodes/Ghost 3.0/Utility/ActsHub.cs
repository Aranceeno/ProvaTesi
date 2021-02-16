using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;


[Node(false, "GHOST/Utility/ActsHub")]

public class ActsHub : Node
{
    public const string ID = "ghost_acts_hub";
    public override string GetID { get { return ID; } }
    GUIStyle guiStyle = new GUIStyle();
    public override string Title { get { return "Acts Hub"; } }

    public override Vector2 DefaultSize { get { return new Vector2(250, 220); } }

    public string text = "";
    public string condOne = "";
    public string condTwo = "";
    public string condThree = "";
    public string condFour = "";
    

    [ValueConnectionKnob("Act", Direction.In, "ActsType", NodeSide.Left, 20)]
    public ValueConnectionKnob structureConnection;
    [ValueConnectionKnob("Character", Direction.Out, "ActsType", NodeSide.Right, 60)]
    public ValueConnectionKnob firstAct;
    [ValueConnectionKnob("Character", Direction.Out, "ActsType", NodeSide.Right, 100)]
    public ValueConnectionKnob secondAct;
    [ValueConnectionKnob("Character", Direction.Out, "ActsType", NodeSide.Right, 140)]
    public ValueConnectionKnob thirdAct;
    [ValueConnectionKnob("Character", Direction.Out, "ActsType", NodeSide.Right, 185)]
    public ValueConnectionKnob fourthAct;

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        structureConnection.DisplayLayout();
        RTEditorGUI.PrefixLabel(new Rect(3, 20, 100, 50), new GUIContent("Insert a condition to trigger this act"), new GUIStyle());
        condOne = EditorGUI.TextArea(new Rect(3, 35, size.x - 6, 20), text);
        RTEditorGUI.PrefixLabel(new Rect(3, 60, 100, 50), new GUIContent("Insert a condition to trigger this act"), new GUIStyle());
        condTwo = EditorGUI.TextArea(new Rect(3, 75, size.x - 6, 20), text);
        RTEditorGUI.PrefixLabel(new Rect(3, 95, 100, 50), new GUIContent("Insert a condition to trigger this act"), new GUIStyle());
        condTwo = EditorGUI.TextArea(new Rect(3, 110, size.x - 6, 20), text);
        RTEditorGUI.PrefixLabel(new Rect(3, 130, 100, 50), new GUIContent("Insert a condition to trigger this act"), new GUIStyle());
        condTwo = EditorGUI.TextArea(new Rect(3, 155, size.x - 6, 20), text);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
}

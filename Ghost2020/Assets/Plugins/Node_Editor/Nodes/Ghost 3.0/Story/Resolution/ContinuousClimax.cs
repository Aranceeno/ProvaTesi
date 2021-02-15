using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Story/Resolution/2. Continuous Climax")]
public class ContinuousClimax : Node
{
    public const string ID = "ghost_continuousClimax";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Continuous Climax"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 250); } }

    [ValueConnectionKnob("", Direction.In, "FinalType", NodeSide.Left, 40)]
    public ValueConnectionKnob finalInputKnob;

    [ValueConnectionKnob("Final ", Direction.Out, "FinalType", NodeSide.Right, 20)]
    public ValueConnectionKnob finalOutputKnob;

    public string text = "";
    //public GUIText text;

    public override void NodeGUI()
    {
        //GUILayout.BeginHorizontal();
        //GUILayout.BeginVertical();

        finalOutputKnob.DisplayLayout();

        //GUILayout.EndVertical();
        //GUILayout.BeginVertical();


        //GUILayout.EndVertical();
        //GUILayout.EndHorizontal();

#if UNITY_EDITOR

#else
#endif
        RTEditorGUI.PrefixLabel(new Rect(3, 35, 100, 50), new GUIContent("Describe the Denouement"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 50, size.x - 6, style.CalcHeight(new GUIContent(text), size.x - 3)), text);

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        finalOutputKnob.SetValue<string>(text);
        return true;
    }
}



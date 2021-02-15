using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Story/Resolution/3. Climax Event")]
public class ClimaxEvent : Node
{
    public const string ID = "ghost_climaxEvent";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Climax Event"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 200); } }

    [ValueConnectionKnob("", Direction.In, "ClimaxType", NodeSide.Left, 20)]
    public ValueConnectionKnob climaxInputKnob;

    [ValueConnectionKnob("Final ", Direction.Out, "FinalType", NodeSide.Right, 40)]
    public ValueConnectionKnob finalOutputKnob;

    public string text = "";
    
    public override void NodeGUI()
    {
        //GUILayout.BeginHorizontal();
        //GUILayout.BeginVertical();
        
        //GUILayout.EndVertical();
        //GUILayout.BeginVertical();
        
        //GUILayout.EndVertical();
        //GUILayout.EndHorizontal();

#if UNITY_EDITOR

#else
#endif
        RTEditorGUI.PrefixLabel(new Rect(3, 35, 100, 50), new GUIContent("Describe Big Damn Heroes"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 50, size.x - 6, style.CalcHeight(new GUIContent(text), size.x - 3)), text);

        finalOutputKnob.DisplayLayout();

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        finalOutputKnob.SetValue<string>(text);
        return true;
    }
}
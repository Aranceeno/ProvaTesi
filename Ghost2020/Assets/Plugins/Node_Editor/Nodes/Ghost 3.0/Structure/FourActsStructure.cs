using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Structure/Four Act Structure")]
public class FourActsStructure : Node
{
    public const string ID = "ghost_fouractstructure";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Four Act Structure"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 200); } }

    public enum Level { Setup, Confrontation, Resolution, Midpoint, None }
    public Level lev = Level.None;

    [ValueConnectionKnob("Act", Direction.Out, "ActsType")]
    public ValueConnectionKnob firstLevelOutputKnob;
    [ValueConnectionKnob("", Direction.In, "LoreType", MaxConnectionCount = ConnectionCount.Multi, NodeSide = NodeSide.Left)]
    public ValueConnectionKnob loreInput;

    public string text = "";


    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Lore");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        loreInput.DisplayLayout();

        firstLevelOutputKnob.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        lev = (Level)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), lev);

        RTEditorGUI.Seperator(new Rect(3, 55, size.x - 3, 1));
        if (getValue().CompareTo("Midpoint") != 0)
        {
            RTEditorGUI.PrefixLabel(new Rect(3, 58, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());
        }
        else
        {
            RTEditorGUI.PrefixLabel(new Rect(3, 60, 100, 50), new GUIContent("Insert Description of Midpoint Here"), new GUIStyle());
        }
        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 75, size.x - 6, style.CalcHeight(new GUIContent(text), size.x - 3)), text);


        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }



    public override bool Calculate()
    {
        switch (lev)
        {
            case Level.Setup:
                firstLevelOutputKnob.SetValue<string>("Setup");
                break;
            case Level.Confrontation:
                firstLevelOutputKnob.SetValue<string>("Confrontation");
                break;
            case Level.Resolution:
                firstLevelOutputKnob.SetValue<string>("Resolution");
                break;
            case Level.Midpoint:
                firstLevelOutputKnob.SetValue<string>("Midpoint");
                break;
            case Level.None:
                firstLevelOutputKnob.SetValue<string>("None");
                break;

        }

        return true;

    }

    public string getValue()
    {
        string ris = "";
        switch (this.lev)
        {
            case Level.Setup:
                ris = "Setup";
                break;
            case Level.Confrontation:
                ris = "Confrontation";
                break;
            case Level.Resolution:
                ris = "Resolution";
                break;
            case Level.None:
                ris = "None";
                break;
            case Level.Midpoint:
                ris = "Midpoint";
                break;

        }
        return ris;
    }

    public void generate()
    {
        Level tmp = (Level)Random.Range(0, 4);
        lev = tmp;
    }
}


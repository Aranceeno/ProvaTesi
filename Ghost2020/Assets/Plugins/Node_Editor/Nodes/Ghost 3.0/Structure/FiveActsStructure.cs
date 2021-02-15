using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Structure/Five Act Structure")]
public class FiveActsStructure : Node
{
    public const string ID = "ghost_fiveactsstructure";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Five Act Structure"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 200); } }

    public enum Level { Pre_Existing_Conflict, Turn_Worsens_Main_Conflict, Twist, Spiral, Climax_Resolution, None }
    public Level lev = Level.None;

    [ValueConnectionKnob("Act", Direction.Out, "ActsType")]
    public ValueConnectionKnob firstLevelOutputKnob;

    public string text = "";
    [ValueConnectionKnob("", Direction.In, "LoreType", MaxConnectionCount = ConnectionCount.Multi, NodeSide = NodeSide.Left)]
    public ValueConnectionKnob loreInput;

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

        RTEditorGUI.PrefixLabel(new Rect(3, 60, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 75, size.x - 6, style.CalcHeight(new GUIContent(text), size.x - 3)), text);

       
        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        switch (lev)
        {
            case Level.Pre_Existing_Conflict:
                firstLevelOutputKnob.SetValue<string>("Introduction and Estabilishing a Pre-Exisisting Conflict");
                break;
            case Level.Turn_Worsens_Main_Conflict:
                firstLevelOutputKnob.SetValue<string>("A turn or reversal which deeply worsens the main conflict");
                break;
            case Level.Twist:
                firstLevelOutputKnob.SetValue<string>("A major turning point");
                break;
            case Level.Spiral:
                firstLevelOutputKnob.SetValue<string>("The spiral");
                break;
            case Level.Climax_Resolution:
                firstLevelOutputKnob.SetValue<string>("Climax or Resolution");
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
            case Level.Pre_Existing_Conflict:
                ris = "Pre_Existing_Conflict";
                break;
            case Level.Turn_Worsens_Main_Conflict:
                ris = "Turn_Worsens_Main_Conflict";
                break;
            case Level.Twist:
                ris = "Twist";
                break;
            case Level.Spiral:
                ris = "Spiral";
                break;
            case Level.Climax_Resolution:
                ris = "Climax_Resolution";
                break;
            case Level.None:
                ris = "None";
                break;

        }
        return ris;
    }

    public void generate()
    {
        Level tmp = (Level)Random.Range(0, 5);
        lev = tmp;
    }
}

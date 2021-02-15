using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Structure/Eight Act Structure")]
public class EightActsStructure : Node
{
    public const string ID = "ghost_eightactsstructure";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Eight Act Structure"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 250); } }

    public enum Level { Acto_One_SequenceA_Opening, Act_One_SequenceB_Setup, Act_TwoA_SequenceC_NewWorld, Act_TwoA_SequenceD_Midpoint, Act_TwoB_SequenceE_Development, Act_TwoB_SequenceF_Crisis, Act_Three_SequenceG_Battle, Act_Three_SequenceH_Resolution, None }
    public Level lev = Level.None;


    [ValueConnectionKnob("Act", Direction.Out, "ActsType")]
    public ValueConnectionKnob firstLevelOutputKnob;

    public string text = "";


    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Eight acts Structure");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        switch (getValue())
        {
            case "Opening":
                RTEditorGUI.PrefixLabel(new Rect(3, 115, 100, 50), new GUIContent("Example of Opening:"), new GUIStyle());
                break;
            case "Setup":
                GUILayout.Label("Setup acts Structure");
                break;
        }

        firstLevelOutputKnob.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        lev = (Level)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), lev);

        RTEditorGUI.Seperator(new Rect(3, 48, size.x - 3, 1));

        RTEditorGUI.PrefixLabel(new Rect(3, 55, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 70, size.x - 6, style.CalcHeight(new GUIContent(text), size.x - 3)), text);

 


        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        switch (lev)
        {
            case Level.Acto_One_SequenceA_Opening:
                firstLevelOutputKnob.SetValue<string>("Opening");
                break;
            case Level.Act_One_SequenceB_Setup:
                firstLevelOutputKnob.SetValue<string>("Setup");
                break;
            case Level.Act_TwoA_SequenceC_NewWorld:
                firstLevelOutputKnob.SetValue<string>("New World");
                break;
            case Level.Act_TwoA_SequenceD_Midpoint:
                firstLevelOutputKnob.SetValue<string>("Midpoint");
                break;
            case Level.Act_TwoB_SequenceE_Development:
                firstLevelOutputKnob.SetValue<string>("Development");
                break;
            case Level.Act_TwoB_SequenceF_Crisis:
                firstLevelOutputKnob.SetValue<string>("Crisis");
                break;
            case Level.Act_Three_SequenceG_Battle:
                firstLevelOutputKnob.SetValue<string>("Battle");
                break;
            case Level.Act_Three_SequenceH_Resolution:
                firstLevelOutputKnob.SetValue<string>("Resolution");
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
            case Level.Acto_One_SequenceA_Opening:
                ris = "Opening";
                break;
            case Level.Act_One_SequenceB_Setup:
                ris = "Setup";
                break;
            case Level.Act_TwoA_SequenceC_NewWorld:
                ris = "Twist";
                break;
            case Level.Act_TwoA_SequenceD_Midpoint:
                ris = "Spiral";
                break;
            case Level.Act_TwoB_SequenceE_Development:
                ris = "Development";
                break;
            case Level.Act_TwoB_SequenceF_Crisis:
                ris = "Crisis";
                break;
            case Level.Act_Three_SequenceG_Battle:
                ris = "Battle";
                break;
            case Level.Act_Three_SequenceH_Resolution:
                ris = "Resolution";
                break;
            case Level.None:
                ris = "None";
                break;

        }
        return ris;
    }

    public void generate()
    {
        Level tmp = (Level)Random.Range(0, 8);
        lev = tmp;
    }
}

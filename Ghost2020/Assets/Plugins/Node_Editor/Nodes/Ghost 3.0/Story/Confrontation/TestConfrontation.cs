using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Story/Confrontation/Test Confrontation")]
public class TestConfrontation : Node
{
    public const string ID = "ghost_TestConfrontation";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Test Confrontation"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 250); } }

    public enum Level { A, B, C, D, E }
    public Level lev = Level.E;

    [ValueConnectionKnob("Output", Direction.Out, "Float")]
    public ValueConnectionKnob testLevelOutputKnob;

    public string text = "";


    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Choose the first level for the confrontation story");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        testLevelOutputKnob.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        lev = (Level)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), lev);

        RTEditorGUI.Seperator(new Rect(3, 48, size.x - 3, 1));

        RTEditorGUI.PrefixLabel(new Rect(3, 55, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 70, size.x - 6, style.CalcHeight(new GUIContent(text), size.x - 3)), text);

        if (GUI.Button(new Rect(10, 200, size.x - 20, 25), "Generate"))
            generate();


        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {


        testLevelOutputKnob.SetValue<float>(0f);



        return true;

    }

    public string getValue()
    {
        string ris = "";
        switch (this.lev)
        {
            case Level.A:
                ris = "A";
                break;
            case Level.B:
                ris = "B";
                break;
            case Level.C:
                ris = "C";
                break;
            case Level.D:
                ris = "D";
                break;
            case Level.E:
                ris = "E";
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

using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Story/Confrontation/First Level Confrontation")]
public class FirstLevelConfrontation : Node
{
    public const string ID = "ghost_firstLevelConfrontation";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "First Level Confrontation"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 250); } }

    public enum Level { Conflict, MacGuffin, ChekhovsGun, LoveTriangle, None }
    public Level lev = Level.None;

    [ValueConnectionKnob("First Level ", Direction.Out, "SecondType")]
    public ValueConnectionKnob firstLevelOutputKnob;

    public string text = "";


    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Choose the first level for the confrontation story");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        firstLevelOutputKnob.DisplayLayout();

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
        switch (lev)
        {
            case Level.Conflict:
                firstLevelOutputKnob.SetValue<string>("Conflict");
                break;
            case Level.MacGuffin:
                firstLevelOutputKnob.SetValue<string>("MacGuffin");
                break;
            case Level.ChekhovsGun:
                firstLevelOutputKnob.SetValue<string>("Chekhov's Gun");
                break;
            case Level.LoveTriangle:
                firstLevelOutputKnob.SetValue<string>("Love Triangle");
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
            case Level.Conflict:
                ris = "Conflict";
                break;
            case Level.MacGuffin:
                ris = "MacGuffin";
                break;
            case Level.ChekhovsGun:
                ris = "Chekhov's Gun";
                break;
            case Level.LoveTriangle:
                ris = "Love Triangle";
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



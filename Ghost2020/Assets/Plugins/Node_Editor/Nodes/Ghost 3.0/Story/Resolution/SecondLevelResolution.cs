using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Story/Resolution/4. Second Level Resolution")]
public class SecondLevelResolution : Node
{
    public const string ID = "ghost_secondLevelResolution";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Second Level Resolution"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 300); } }

    [ValueConnectionKnob("", Direction.In, "FinalType", NodeSide.Left, 40)]
    public ValueConnectionKnob firstLevelOutputKnob;

    [ValueConnectionKnob("", Direction.Out, "CardResolutionType", NodeSide.Bottom, 20)]
    public ValueConnectionKnob placeOutputKnob;

    public enum End { End, Aesop, None }
    public End fin = End.None;

    public string text = "";
    public bool place = false;
    
    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Describe the Final of yout story");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        place = GUI.Toggle(new Rect(10, 260, 100, 30), place, "Place Card");
        fin = (End)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), fin);

        RTEditorGUI.Seperator(new Rect(3, 40, size.x - 3, 1));

        RTEditorGUI.PrefixLabel(new Rect(3, 46, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 61, size.x - 6, style.CalcHeight(new GUIContent(text), size.x - 3)), text);

        if (GUI.Button(new Rect(10, 230, size.x - 20, 25), "Generate"))
            generate();

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {

        switch (fin)
        {
            case End.End:
                placeOutputKnob.SetValue<string>("The End");
                break;
            case End.Aesop:
                placeOutputKnob.SetValue<string>("Aesop");
                break;
            case End.None:
                placeOutputKnob.SetValue<string>("None");
                break;
        }

        if (place)
        {
            placeOutputKnob.DisplayLayout();
        }

        return true;
    }

    public string getValue()
    {
        string ris = "";
        switch (this.fin)
        {
            case End.End:
                ris = "The End";
                break;
            case End.Aesop:
                ris = "Aesop";
                break;
            case End.None:
                ris = "None";
                break;
        }
        return ris;
    }

    public void generate()
    {
        End tmp = (End)Random.Range(0, 3);
        fin = tmp;
    }
}
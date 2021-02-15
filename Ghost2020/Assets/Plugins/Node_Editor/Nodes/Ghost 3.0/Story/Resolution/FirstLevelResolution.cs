using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[Node(false, "GHOST/Story/Resolution/1. First Level Resolution")]
public class FirstLevelResolution : Node
{
    public const string ID = "ghost_firstLevelResolution";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "First Level Resolution"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 250); } }

    [ValueConnectionKnob("Final ", Direction.Out, "FinalType", NodeSide.Right, 20)]
    public ValueConnectionKnob finalOutputKnob;

    [ValueConnectionKnob("Climax ", Direction.Out, "ClimaxType", NodeSide.Right, 40)]
    public ValueConnectionKnob climaxOutputKnob;

    [ValueConnectionKnob("Place", Direction.Out, "CardResolutionType", NodeSide.Bottom, 20)]
    public ValueConnectionKnob placeOutputKnob;

    public enum Level { Climax, TheReveal, None }
    public Level lev = Level.None;

    public bool ev = false;
    public string text = "";
    public bool place = false;
    

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Choose the first level for the resolution story");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        //Outputs[0].DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

#if UNITY_EDITOR
        lev = (Level)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), lev);
#else
#endif

        if (string.Equals(lev.ToString(), "Climax"))
        {
            ev = GUI.Toggle(new Rect(10, 50, 160, 50), ev, "Big Damn Heroes");
        }
        else
        {
            if (string.Equals(lev.ToString(), "TheReveal"))
            {
                RTEditorGUI.PrefixLabel(new Rect(10, 50, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());
                GUIStyle style = GUI.skin.box;
                text = EditorGUI.TextArea(new Rect(3, 70, size.x - 6, style.CalcHeight(new GUIContent(text), size.x - 3)), text);
            }
        }

        place = GUI.Toggle(new Rect(10, 210, 100, 30), place, "Place Card");
        
        if (GUI.Button(new Rect(10, 230, size.x - 20, 25), "Generate"))
            generate();


        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        //if (string.Equals(lev.ToString(), "Climax"))
        //{
        //    finalOutputKnob.DisplayLayout();
        //}
        //else
        //{
        //    if (string.Equals(lev.ToString(), "TheReveal"))
        //    {
        //        finalOutputKnob.DisplayLayout();
        //    }
        //}

        //if (place)
        //{
        //    placeOutputKnob.DisplayLayout();
        //}

        //if (ev)
        //{
        //    climaxOutputKnob.DisplayLayout();
        //}

        switch (lev)
        {
            case Level.Climax:
                finalOutputKnob.SetValue<string>("Climax");
                break;
            case Level.TheReveal:
                finalOutputKnob.SetValue<string>("The Reveal");
                break;
        }
        
        return true;
    }

    public string getValue()
    {
        string ris = "";

        switch (this.lev)
        {
            case Level.Climax:
                ris = "Climax";
                break;
            case Level.TheReveal:
                ris = "The Reveal";
                break;
        }
        return ris;
    }

    public void generate()
    {
        Level tmp = (Level)Random.Range(0, 3);
        lev = tmp;
    }
}



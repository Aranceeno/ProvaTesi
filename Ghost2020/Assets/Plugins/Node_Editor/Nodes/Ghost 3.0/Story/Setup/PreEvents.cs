using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Story/Setup/1. Pre Events")]
public class PreEvents : Node
{
    public const string ID = "ghost_preEvents";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Pre Events"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 300); } }

    [ValueConnectionKnob("Prequel ", Direction.Out, "PrequelType")]
    public ValueConnectionKnob prequelOutputKnob;

    [ValueConnectionKnob("BackStory ", Direction.Out, "BackStoryType")]
    public ValueConnectionKnob backStoryOutputKnob;

    [ValueConnectionKnob("Place", Direction.Out, "CardPreEventsType", NodeSide.Bottom, 20)]
    public ValueConnectionKnob placePreEventsCardOutputKnob;

    [ValueConnectionKnob("Event", Direction.Out, "CardPreEventsType", NodeSide.Bottom, 160)]
    public ValueConnectionKnob eventPreEventsCardOutputKnob;

    [ValueConnectionKnob("Mob", Direction.Out, "CardPreEventsType", NodeSide.Bottom, 310)]
    public ValueConnectionKnob mobPreEventsCardOutputKnob;

    public bool pre = false;
    public bool back = false;
    public string text = "";
    public bool place = false;
    public bool ev = false;
    public bool mob = false;
    //

    public int index = 2;
    public int rnd;

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        prequelOutputKnob.DisplayLayout();
        backStoryOutputKnob.DisplayLayout();
        
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        RTEditorGUI.Seperator(new Rect(3, 48, size.x - 6, 1));

        RTEditorGUI.PrefixLabel(new Rect(3, 55, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 70, size.x - 6, style.CalcHeight(new GUIContent(text), size.x-3)), text);
            
        pre = GUI.Toggle(new Rect(10, 5, 100, 30), pre, "Prequel");
        back = GUI.Toggle(new Rect(10, 25, 100, 30), back, "Backstory");

        place = GUI.Toggle(new Rect(10, 260, 100, 30), place, "Place Card");
        ev = GUI.Toggle(new Rect(150, 260, 100, 30), ev, "Event Card");
        mob = GUI.Toggle(new Rect(300, 260, 100, 30), mob, "Mob Card");

        if (GUI.Button(new Rect(10, 230, size.x - 20, 25), "Generate"))
            generate();
        
        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        if (pre)
        {
            prequelOutputKnob.SetValue<bool>(true);
        }
        else
        {
            prequelOutputKnob.SetValue<bool>(false);
        }

        if (back)
        {
            backStoryOutputKnob.SetValue<bool>(true);
        }
        else
        {
            backStoryOutputKnob.SetValue<bool>(false);
        }

        if (place)
        {
            placePreEventsCardOutputKnob.DisplayLayout();
        }

        if (ev)
        {
            eventPreEventsCardOutputKnob.DisplayLayout();
        }

        if (mob)
        {
            mobPreEventsCardOutputKnob.DisplayLayout();
        }
        
        return true;

    }

    public bool getPre()
    {
        return this.pre;
    }

    public bool getBack()
    {
        return this.back;
    }

    public void generate()
    {
        rnd = Random.Range(0, 2);
        if (rnd == 0)
        {
            pre = true;
            back = false;
        }
        else
        {
            back = true;
            pre = false;
        }
    }
}

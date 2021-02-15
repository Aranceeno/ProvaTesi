using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Story/Storylines/Storyline Setup")]
public class StorylineSetup : Node
{
    public const string ID = "ghost_storylineSetup";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Storyline Setup"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 300); } }

    [ValueConnectionKnob("", Direction.In, "SecondType", NodeSide.Left, 0)]
    public ValueConnectionKnob secondLevelInputKnob;

    [ValueConnectionKnob("PlaceStorylineCard", Direction.Out, "CardStorylineType", NodeSide.Bottom, 20)]
    public ValueConnectionKnob placeStorylineCardOutputKnob;

    [ValueConnectionKnob("ItemStorylineCard", Direction.Out, "CardStorylineType", NodeSide.Bottom, 160)]
    public ValueConnectionKnob itemStorylineCardOutputKnob;

    public enum Lines { SeriousBusiness, Masquerade, XMeetsY, Wangst, MoralEventHorizon,
                        SealedEvilInACan, AppliedPhlebotinum, None }
    public Lines line = Lines.None;

    public string text = "";
    public bool place = false;
    public bool item = false;
    

    public int index = 0;
    
    public override void NodeGUI()
    {
        GUILayout.Label("Choose the storyline for your setup");

        GUILayout.Label(secondLevelInputKnob.IsValueNull? "None" : secondLevelInputKnob.GetValue<string>());
        secondLevelInputKnob.DisplayLayout();

        line = (Lines)UnityEditor.EditorGUILayout.EnumPopup("", line);

        place = GUI.Toggle(new Rect(10, 260, 100, 30), place, "Place Card");
        item = GUI.Toggle(new Rect(150, 260, 100, 30), item, "Item Card");

        RTEditorGUI.Seperator(new Rect(3, 75, size.x - 6, 1));

        RTEditorGUI.PrefixLabel(new Rect(3, 80, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 95, size.x - 3, style.CalcHeight(new GUIContent(text), size.x - 6)), text);

        if (GUI.Button(new Rect(10, 230, size.x - 20, 25), "Generate"))
            generate();

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        if (place)
        {
            placeStorylineCardOutputKnob.DisplayLayout();
        }

        if (item)
        {
            itemStorylineCardOutputKnob.DisplayLayout();
        }

        return true;

    }

    public string getValue()
    {
        string ris = "";

        switch (line)
        {
            case Lines.SeriousBusiness:
                ris = "Serious Business";
                break;
            case Lines.Masquerade:
                ris = "Masquerade";
                break;
            case Lines.XMeetsY:
                ris = "X Meets Y";
                break;
            case Lines.Wangst:
                ris = "Wangst";
                break;
            case Lines.MoralEventHorizon:
                ris = "Moral Event Horizon";
                break;
            case Lines.SealedEvilInACan:
                ris = "Sealed Evil In A Can";
                break;
            case Lines.AppliedPhlebotinum:
                ris = "Applied Phlebotinum";
                break;
            case Lines.None:
                ris = "None";
                break;
        }
        return ris;
    }

    public void generate()
    {
        Lines tmp = (Lines)Random.Range(0, 8);
        line = tmp;
    }
}
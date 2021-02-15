using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[Node(false, "GHOST/Sidequest/Quest")]
public class Quest : Node
{
    public const string ID = "ghost_quest";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Side Quest"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 160); } }

    [ValueConnectionKnob("Place", Direction.Out, "CardQuestType", NodeSide.Right, 20)]
    public ValueConnectionKnob placeQuestOutputKnob;
    [ValueConnectionKnob("Event", Direction.Out, "CardQuestType", NodeSide.Right, 40)]
    public ValueConnectionKnob eventQuestOutputKnob;
    [ValueConnectionKnob("Item", Direction.Out, "CardQuestType", NodeSide.Right, 60)]
    public ValueConnectionKnob itemQuestOutputKnob;
    [ValueConnectionKnob("Mob", Direction.Out, "CardQuestType", NodeSide.Right, 80)]
    public ValueConnectionKnob mobQuestOutputKnob;
    [ValueConnectionKnob("Plot", Direction.Out, "PlotType", NodeSide.Right, 80)]
    public ValueConnectionKnob plot;
    [ValueConnectionKnob("Character Hub", Direction.In, "StructureType", NodeSide.Left, 50)]
    public ValueConnectionKnob charactersHub;



    public string characterName;

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();

        characterName = RTEditorGUI.TextField(new GUIContent("Insert Sidequest Name"), characterName);
        charactersHub.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        placeQuestOutputKnob.DisplayLayout();
        eventQuestOutputKnob.DisplayLayout();
        itemQuestOutputKnob.DisplayLayout();
        mobQuestOutputKnob.DisplayLayout();
        plot.DisplayLayout();

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        return true;
    }

    public string getName()
    {
        return this.characterName;
    }
}




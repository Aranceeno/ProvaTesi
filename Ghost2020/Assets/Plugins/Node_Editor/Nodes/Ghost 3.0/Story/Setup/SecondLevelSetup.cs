using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Story/Setup/2. SecondLevelSetup")]
public class SecondLevelSetup : Node
{
    public const string ID = "ghost_secondLevelSetup";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Second Level Setup"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 300); } }

    [ValueConnectionKnob("", Direction.In, "PrequelType", NodeSide.Left, 30)]
    public ValueConnectionKnob prequelInputKnob;

    [ValueConnectionKnob("", Direction.In, "BackStoryType", NodeSide.Left, 50)]
    public ValueConnectionKnob backStoryInputKnob;

    [ValueConnectionKnob("Second Level ", Direction.Out, "SecondType")]
    public ValueConnectionKnob secondLevelOutputKnob;

    public enum Level { CallToAdventure, HeroJourney, RedemptionQuest, SavingTheWorld,
                        FightTheCrime, StatusQuo, RetCon, None }
    public Level lev = Level.None;

    public string text = "";
    public int rnd;

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Choose the second level for the setup story");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();

        secondLevelOutputKnob.DisplayLayout();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        

#if UNITY_EDITOR
        lev = (Level)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), lev);
#else
#endif
        RTEditorGUI.Seperator(new Rect(3, 48, size.x - 3, 1));

        RTEditorGUI.PrefixLabel(new Rect(3, 55, 100, 50), new GUIContent("Insert Description Here"), new GUIStyle());

        GUIStyle style = GUI.skin.box;
        text = EditorGUI.TextArea(new Rect(3, 70, size.x - 6, style.CalcHeight(new GUIContent(text), size.x - 3)), text);

        if (GUI.Button(new Rect(10, 230, size.x - 20, 25), "Generate"))
            generate();
        
        

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        switch (lev)
        {
            case Level.CallToAdventure:
                secondLevelOutputKnob.SetValue<string>("Call to Adventure");
                break;
            case Level.HeroJourney:
                secondLevelOutputKnob.SetValue<string>("The Hero Journey");
                break;
            case Level.RedemptionQuest:
                secondLevelOutputKnob.SetValue<string>("The Redemption Quest");
                break;
            case Level.SavingTheWorld:
                secondLevelOutputKnob.SetValue<string>("Saving The World");
                break;
            case Level.FightTheCrime:
                secondLevelOutputKnob.SetValue<string>("They Fight the Crime");
                break;
            case Level.StatusQuo:
                secondLevelOutputKnob.SetValue<string>("Status Quo is God");
                break;
            case Level.RetCon:
                secondLevelOutputKnob.SetValue<string>("RetCon");
                break;
            case Level.None:
                secondLevelOutputKnob.SetValue<string>("None");
                break;
        }

        return true;

    }

    public string getValue()
    {
        string ris = "";
        switch (lev)
        {
            case Level.CallToAdventure:
                ris = "Call to Adventure";
                break;
            case Level.HeroJourney:
                ris = "The Hero Journey";
                break;
            case Level.RedemptionQuest:
                ris = "The Redemption Quest";
                break;
            case Level.SavingTheWorld:
                ris = "Saving The World";
                break;
            case Level.FightTheCrime:
                ris = "They Fight the Crime";
                break;
            case Level.StatusQuo:
                ris = "Status Quo is God";
                break;
            case Level.RetCon:
                ris = "RetCon";
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



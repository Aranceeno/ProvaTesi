using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Acts/Act")]
public class Act : Node
{
    public const string ID = "ghost_act";
    public override string GetID { get { return ID; } }
    GUIStyle guiStyle = new GUIStyle();


    public enum Level { One, Two, Three, Four, Five, Six, Seven, Eight, None }
    public Level lev = Level.None;

    public override string Title { get { return "Act"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 250); } }


    [ValueConnectionKnob("Structure/Character Hub", Direction.In, "StructureType", ConnectionCount.Multi)]
    public ValueConnectionKnob structureConnection;

    [ValueConnectionKnob("Next act", Direction.Out, "ActsType")]
    public ValueConnectionKnob actOutConnection;
    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        structureConnection.DisplayLayout();
        actOutConnection.DisplayLayout();
        RTEditorGUI.Seperator(new Rect(3, 48, size.x - 3, 1));
        EditorGUI.HelpBox(new Rect(3, 55, 350, 248), getHelpBox(), MessageType.Info);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        lev = (Level)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), lev);
    }

    public override bool Calculate()
    {
        switch (lev)
        {
            case Level.One:
                actOutConnection.SetValue<string>("One");
                break;
            case Level.Two:
                actOutConnection.SetValue<string>("Two");
                break;
            case Level.Three:
                actOutConnection.SetValue<string>("Three");
                break;
            case Level.Four:
                actOutConnection.SetValue<string>("Four");
                break;
            case Level.Five:
                actOutConnection.SetValue<string>("Five");
                break;
            case Level.Six:
                actOutConnection.SetValue<string>("Six");
                break;
            case Level.Seven:
                actOutConnection.SetValue<string>("Seven");
                break;
            case Level.Eight:
                actOutConnection.SetValue<string>("Eight");
                break;
            case Level.None:
                actOutConnection.SetValue<string>("None");
                break;

        }

        return true;
    }

    public string getValue()
    {
        string ris = "";
        switch (this.lev)
        {

            case Level.One:
                ris = "One";
                break;
            case Level.Two:
                ris = "Two";
                break;
            case Level.Three:
                ris = "Three";
                break;
            case Level.Four:
                ris = "Four";
                break;
            case Level.Five:
                ris = "Five";
                break;
            case Level.Six:
                ris = "Six";
                break;
            case Level.Seven:
                ris = "Seven";
                break;
            case Level.Eight:
                ris = "Eight";
                break;
            case Level.None:
                ris = "One";
                break;

        }
        return ris;
    }
    public string getHelpBox()
    {
        string helpBox = "";
        switch (this.lev)
        {

            case Level.One:
                helpBox = "The first act is usually used for exposition, to establish the main characters, their relationships, and the world they live in. Later in the first act, a dynamic, on-screen incident occurs, known as the inciting incident, or catalyst, that confronts the main character(the protagonist), and whose attempts to deal with this incident lead to a second and more dramatic situation, known as the first plot point, which (a) signals the end of the first act, (b) ensures life will never be the same again for the protagonist and (c) raises a dramatic question that will be answered in the climax of the film. The dramatic question should be framed in terms of the protagonist's call to action, (Will X recover the diamond? Will Y get the girl? Will Z capture the killer?).";
                break;
            case Level.Two:
                helpBox = "Typically depicts the protagonist's attempt to resolve the problem initiated by the first turning point, only to find themselves in ever worsening situations. Part of the reason protagonists seem unable to resolve their problems is because they do not yet have the skills to deal with the forces of antagonism that confront them. They must not only learn new skills but arrive at a higher sense of awareness of who they are and what they are capable of, in order to deal with their predicament, which in turn changes who they are. This is referred to as character development or a character arc. This cannot be achieved alone and they are usually aided and abetted by mentors and co-protagonists.";
                break;
            case Level.Three:
                helpBox = "The third act features the resolution of the story and its subplots. The climax is the scene or sequence in which the main tensions of the story are brought to their most intense point and the dramatic question answered, leaving the protagonist and other characters with a new sense of who they really are." +
                    "";
                break;
            case Level.Four:
                helpBox = "In a Four acts structure is the climax is its point of highest tension and drama, or it is the time when the action starts during which the solution is given.The climax of a story is a literary element." +
                    " In a Five acts structure is the falling action.It is that part of the story in which the main part (the climax) has finished and you're heading to the conclusion. This is the calm after the tension of the climax. " +
                    "In a Eight acts structure is the midpoint what keeps your second act from dragging. It’s what caps the reactions in the first half of the book and sets up the chain of actions that will lead the characters into the climax. In many ways, the midpoint is like a second inciting event.";
                break;
            case Level.Five:
                helpBox = "In a Five act structure is the ending (In a movie like Die Hard it's when John McClane kills Gruber and saves his wife). In an eight acts structure the five is for subplot and to rising action, we still want rising action, but we’re not ready for the main culmination yet.";
                break;
            case Level.Six:
                helpBox = "It is the main culmination. The highest obstacle, the last alternative, the highest or lowest moment and the end of our main tension come at this point. But we get the first inklings of the new tension that will carry us through the last two acts.";
                break;
            case Level.Seven:
                helpBox = "It is for a new tension and a new twist. You must introduce any new exposition or information the audience needs to know. Additionally, the twist or big reveal often falls here, another good reason for a goal shift.";
                break;
            case Level.Eight:
                helpBox = "It is for the resolution. In this sequence, you'll answer whether the main conflict was resolved and if so how.";
                break;
            case Level.None:
                break;

        }
        return helpBox;
    }

}

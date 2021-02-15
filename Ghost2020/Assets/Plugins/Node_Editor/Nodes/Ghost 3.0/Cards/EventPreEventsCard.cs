using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[Node(false, "GHOST/Cards/Event - Pre Events Card")]
public class EventPreEventsCard : Node
{
    public const string ID = "ghost_eventPreEventsCard";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Pre Events Card"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 150); } }

    [ValueConnectionKnob("", Direction.In, "CardPreEventsType", NodeSide.Left, 30)]
    public ValueConnectionKnob inputKnob;

    public enum Event { HardTimes, Contest, Storm, Dream, Escape,
            Fight, Meet, Hurt, Chase, FallInLove, Death, ObjectBreak,
            Trasformation, Rescue, Fire, Prophecy, Pursuit, Imprison }
    public Event ev = Event.HardTimes;

    public enum Aspect { Cursed, Disguised, Evil, Hidden, Insane, Invisible,
            Lost, Poisoned, Stolen, CanFly, CanTalk, Beautiful, Secret, FarAway,
            Ugly, Dying, Empty, Haunted, Diseased, None }
    public Aspect asp = Aspect.None;

    public string text = "";
    

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Choose the Event Card");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();


        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

#if UNITY_EDITOR
      
#else
#endif
        ev = (Event)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), ev);

        GUILayout.Label("Choose the Aspect");
        asp = (Aspect)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), asp);

        if (GUI.Button(new Rect(10, 100, size.x - 20, 25), "Generate"))
            generate();

        if (GUI.changed)
            NodeEditor.curNodeCanvas.OnNodeChange(this);
    }

    public override bool Calculate()
    {
        return true;
    }

    public string getEvent()
    {
        string ris = "";
        switch (this.ev)
        {
            case Event.HardTimes:
                ris = "Hard Times";
                break;
            case Event.Contest:
                ris = "Contest";
                break;
            case Event.Storm:
                ris = "Storm";
                break;
            case Event.Dream:
                ris = "Dream";
                break;
            case Event.Escape:
                ris = "Escape";
                break;
            case Event.Fight:
                ris = "Fight";
                break;
            case Event.Meet:
                ris = "Meet";
                break;
            case Event.Hurt:
                ris = "Hurt";
                break;
            case Event.Chase:
                ris = "Chase";
                break;
            case Event.FallInLove:
                ris = "Fall in Love";
                break;
            case Event.Death:
                ris = "Death";
                break;
            case Event.ObjectBreak:
                ris = "Object Break";
                break;
            case Event.Trasformation:
                ris = "Trasformation";
                break;
            case Event.Rescue:
                ris = "Rescue";
                break;
            case Event.Fire:
                ris = "Fire";
                break;
            case Event.Prophecy:
                ris = "Prophecy";
                break;
            case Event.Pursuit:
                ris = "Pursuit";
                break;
            case Event.Imprison:
                ris = "Imprison";
                break;
        }

        return ris;
    }

    public string getAspect()
    {
        string ris = "";
        switch (asp)
        {
            case Aspect.Cursed:
                ris = "Cursed";
                break;
            case Aspect.Disguised:
                ris = "Disguised";
                break;
            case Aspect.Evil:
                ris = "Evil";
                break;
            case Aspect.Hidden:
                ris = "Hidden";
                break;
            case Aspect.Insane:
                ris = "Insane";
                break;
            case Aspect.Invisible:
                ris = "Invisible";
                break;
            case Aspect.Lost:
                ris = "Lost";
                break;
            case Aspect.None:
                ris = "None";
                break;
            case Aspect.Poisoned:
                ris = "Poisoned";
                break;
            case Aspect.Stolen:
                ris = "Stolen";
                break;
            case Aspect.CanFly:
                ris = "Can Fly";
                break;
            case Aspect.CanTalk:
                ris = "Can Talk";
                break;
            case Aspect.Beautiful:
                ris = "Beautiful";
                break;
            case Aspect.Secret:
                ris = "Secret";
                break;
            case Aspect.FarAway:
                ris = "Far Away";
                break;
            case Aspect.Ugly:
                ris = "Ugly";
                break;
            case Aspect.Dying:
                ris = "Dying";
                break;
            case Aspect.Empty:
                ris = "Empty";
                break;
            case Aspect.Haunted:
                ris = "Imprison";
                break;
            case Aspect.Diseased:
                ris = "Diseased";
                break;
        }
        return ris;
    }

    public void generate()
    {
        Event tmp = (Event)Random.Range(0, 18);
        ev = tmp;

        Aspect tmp2 = (Aspect)Random.Range(0, 20);
        asp = tmp2;
    }
}
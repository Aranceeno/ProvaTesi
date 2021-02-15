using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[Node(false, "GHOST/Cards/Mob - Quest Card")]
public class MobQuestCard : Node
{
    public const string ID = "ghost_mobQuestCard";
    public override string GetID { get { return ID; } }

    public override string Title { get { return "Mob - Pre Events Card"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 150); } }

    [ValueConnectionKnob("", Direction.In, "CardQuestType", NodeSide.Left, 30)]
    public ValueConnectionKnob inputKnob;

    public enum Mob { Ghost, Guard, Outcast, Murderer, Sage, Dragon, Giant, King, Knight, Priest, Thief, Witch, Wizard, Monster, Enemy }
    public Mob mon = Mob.Ghost;

    public enum Aspect { Cursed, Disguised, Evil, Hidden, Insane, Invisible, Lost, Poisoned, Stolen, CanFly, CanTalk, Beautiful, Secret, FarAway, Ugly, Dying, Empty, Haunted, Diseased, None }
    public Aspect asp = Aspect.None;

    public string text = "";
    

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Choose the Mob Card");

        GUILayout.EndVertical();
        GUILayout.BeginVertical();


        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

#if UNITY_EDITOR

#else
#endif
        mon = (Mob)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), mon);

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

    public string getMob()
    {
        string ris = "";
        switch (this.mon)
        {
            case Mob.Ghost:
                ris = "Ghost";
                break;
            case Mob.Guard:
                ris = "Guard";
                break;
            case Mob.Outcast:
                ris = "Outcast";
                break;
            case Mob.Murderer:
                ris = "Murderer";
                break;
            case Mob.Sage:
                ris = "Sage";
                break;
            case Mob.Dragon:
                ris = "Dragon";
                break;
            case Mob.Giant:
                ris = "Giant";
                break;
            case Mob.King:
                ris = "King";
                break;
            case Mob.Knight:
                ris = "Knight";
                break;
            case Mob.Priest:
                ris = "Priest";
                break;
            case Mob.Thief:
                ris = "Thief";
                break;
            case Mob.Witch:
                ris = "Witch";
                break;
            case Mob.Wizard:
                ris = "Wizard";
                break;
            case Mob.Monster:
                ris = "Monster";
                break;
            case Mob.Enemy:
                ris = "Enemy";
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
        Mob tmp = (Mob)Random.Range(0, 15);
        mon = tmp;

        Aspect tmp2 = (Aspect)Random.Range(0, 20);
        asp = tmp2;
    }
}
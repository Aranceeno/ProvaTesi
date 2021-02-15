using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;

[Node(false, "GHOST/Story/SideQuest/Plot")]
public class Plot : Node
{
    public const string ID = "ghost_plot";
    public override string GetID { get { return ID; } }
    GUIStyle guiStyle = new GUIStyle();


    public enum PossiblePlot
    {
        LoveAndCourtship, MisfortunEnterprise, Revenge, Transgression, Mistery, None
    }
    public PossiblePlot lev = PossiblePlot.None;

    public enum LoveAndCourtship
    {
        APoorIsInLoveWithWealthyAndAristocraticB, AIsAJudgeAndBIsaFugitive, AADetectiveFallsInLoveWithB,
        AInLoveWithBDiscoversThatBIsInLoveWithB2, AXAGayYoungBlade, None
    }
    public LoveAndCourtship love = LoveAndCourtship.None;
    public enum Enterprise { AAProfessionalManIsCapturedInHisOffice, AWasInTheWorldWar, AAfterAMysteriousAbsenceOfManyYears, AABurglarSeeksToAidB, AAfugitiveFromJustice, None }
    public Enterprise misfortune = Enterprise.None;
    public enum Revenge
    {
        SeeksRevenge, BrideRevenge, MaleAgainstFemaleRival, Consiparacy, PoorYoungRevenge, None
    }
    public Revenge revenge = Revenge.None;
    public enum Transgression
    {
        FightTemptation, ForeignFugitive, SellHeirloom,HoundDog,Murder, None
    }
    public Transgression transgression = Transgression.None;
    public enum Mistery { 
        None
    }
    public Mistery mistery = Mistery.None;

    public override string Title { get { return "Possible Plot"; } }
    public override Vector2 DefaultSize { get { return new Vector2(400, 250); } }


    [ValueConnectionKnob("Sidequest", Direction.In, "StructureType", ConnectionCount.Multi)]
    public ValueConnectionKnob structureConnection;

    public override void NodeGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        structureConnection.DisplayLayout();
        lev = (PossiblePlot)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), lev);
        switch (lev)
        {
            case PossiblePlot.LoveAndCourtship:
                love = (LoveAndCourtship)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), love);
                EditorGUI.HelpBox(new Rect(3, 60, 390, 150), getLoveText(), MessageType.Info);
                break;
            case PossiblePlot.MisfortunEnterprise:
                misfortune = (Enterprise)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), misfortune);
                EditorGUI.HelpBox(new Rect(3, 60, 390, 150), getMisfortuneText(), MessageType.Info);
                break;
            case PossiblePlot.Revenge:
                revenge = (Revenge)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), revenge);
                EditorGUI.HelpBox(new Rect(3, 60, 390, 150), getRevengeText(), MessageType.Info);
                break;
            case PossiblePlot.Transgression:
                transgression = (Transgression)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), transgression);
                EditorGUI.HelpBox(new Rect(3, 60, 390, 150), getRevengeText(), MessageType.Info);
                break;
            case PossiblePlot.Mistery:
                mistery = (Mistery)UnityEditor.EditorGUILayout.EnumPopup(new GUIContent("", ""), mistery);
                EditorGUI.HelpBox(new Rect(3, 60, 390, 150), misteryText(), MessageType.Info);
                break;
        }

    }
    public string getLoveText()
    {
        string helpBox = "";
        switch (this.love)
        {
            case LoveAndCourtship.APoorIsInLoveWithWealthyAndAristocraticB:
                helpBox = "Male Protagonist, poor, is in love with wealthy and aristocratic female protagonist * A, pretends to be a man of wealth";
                break;
            case LoveAndCourtship.AIsAJudgeAndBIsaFugitive:
                helpBox = "Male protagonist is a judge, and Female Protagonist is a fugitive from justice posing as a woman of wealth andfashion";
                break;
            case LoveAndCourtship.AADetectiveFallsInLoveWithB:
                helpBox = "Male protagonist, a detective, falls in love with female protagonist, the criminal he has arrested and is returningto the scene of her crime for trial and punishment";
                break;
            case LoveAndCourtship.AInLoveWithBDiscoversThatBIsInLoveWithB2:
                helpBox = "Male Protagonist, in love with Female Protagonist. Discovers that female protagonist is in love with a her female friend";
                break;
            case LoveAndCourtship.AXAGayYoungBlade:
                helpBox = "A misterious male person, a gay young blade traveling through the country, takes refuge from a storm " +
                    "in a rural church.To his astonishment, he is hailed at once as a bridegroom, and " +
                    "is hurried to the altar where a pretty girl, in an exhausted condition, " +
                    "seems waiting for him. In a spirit of recklessness, he allows himself " +
                    "to be married to her; and when she, after the ceremony, seems to realize that " +
                    "he is not the man she thought he was, he hurriedly makes his escape";
                break;
            case LoveAndCourtship.None:
                break;
        }
        return helpBox;
    }
    public string getMisfortuneText()
    {
        string helpBox = "";
        switch (this.misfortune)
        {
            case Enterprise.AAProfessionalManIsCapturedInHisOffice:
                helpBox = "Male protagonist, a professional man, is captured in his oflfice at night by three mysterious strangers, " +
                    "blindfolded and taken to a secret place. The male protagonist spirited away by this three strangers, is compelled to perfom a professional service";
                break;
            case Enterprise.AWasInTheWorldWar:
                helpBox = "Male protagonist was in the World War Before the World Wtr, was a successful business man; after the war, a physical wreck, and a bankrupt";
                break;
            case Enterprise.AAfterAMysteriousAbsenceOfManyYears:
                helpBox = "Male, after a mysterious absence of many years, returns to his old home town." +
                    "Returning as an Unknown to his native place, discovers that no one recognizes him";
                break;
            case Enterprise.AABurglarSeeksToAidB:
                helpBox = "Male protagonist, a burglar, seeks to aid female protagonist, who was his friend before he 'went to the bad' male protagonist," +
                    "friend of female protagonist, breaks into a building for the purpose of committing a robbery, and" +
                    "finds a trusted employee, male  criminal, female protagonist's husband, dead at his desk, a defaulter and a" +
                    "suicide. Male criminal has left a note explaining his guilt, in order" +
                    "to save his friend female protagonist from disgrace, destroys a letter that would have proved her" +
                    "husband,male criminal, a defaulter and a suicide, 'blows' a safe and pretends to have committed a robber";
                break;
            case Enterprise.AAfugitiveFromJustice:
                helpBox = "Male protagonist, a fugitive from justice, disguises himself and, as an Unknown, risks discovery and arrest to carry out a romantic enterprise";
                break;
            case Enterprise.None:
                break;
        }
        return helpBox;
    }
    public string getRevengeText()
    {
        string helpBox = "";
        switch (this.revenge)
        {
            case Revenge.SeeksRevenge:
                helpBox = "Female protagonist seeks revenge as a lofty conception of duty—and comes to her death while seeking it";
                break;
            case Revenge.BrideRevenge:
                helpBox = "Female protagonist's husband, male protagonist, is killed by male criminal." +
                    "Male criminal through the law's delay and technicalities, escapes with only a light sentence female protagonist invokes" +
                    "the Mosaic law in seeking revenge upon male criminal for the murder of her husband.";
                break;
            case Revenge.MaleAgainstFemaleRival:
                helpBox = "Male protagonist, seeking revenge against female rival for a wrong committed by her husband, male rival, who " +
                    "is dead, finds that female rival treasures male rival's memory most sacredly, unaware of his evil" +
                    " character. Male protagonist could destroy the beautiful love and devotion of female rival, for her dead" +
                    " husband, male rival, by telling her the sort of man male rival was male protagonist , in a spiritual victory, " +
                    "decides to forego a cherished enterprise and spare an innocent woman her happy" +
                    "but mistaken ideals";
                break;
            case Revenge.Consiparacy:
                helpBox = "Male protagonist, high born, falls under the ban of death as a political conspirator in his native country";
                break;
            case Revenge.PoorYoungRevenge:
                helpBox = "Male protagonist, a poor young man, inspired by anger and a desire for revenge, seeks to ruin " +
                    "wealthy male utility symbol, a powerful captain of industry 1317 A commits an act of reprisal against male utility sym with more serious results than he had" +
                    "intended";
                break;
            case Revenge.None:
                break;


        }
        return helpBox;
    }
    public string getTransgressionText() {
        string helpBox = "";
        switch (this.transgression) {
            case Transgression.FightTemptation:
                helpBox = "Male protagonist is a soldier, eager to fight but who is commanded to retreat before a superior force of the enemy";
                break;
            case Transgression.ForeignFugitive:
                helpBox = "Male protagonist flees to a foreign country to escape the consequences of a transgression";
                break;
            case Transgression.SellHeirloom:
                helpBox = "Female protagonist, in order to carry out a certain enterprise, sells a valuable heirloom, object, confided to her for safe - keeping by male protagonist";
                break;
            case Transgression.HoundDog:
                helpBox = "Male protagonist, of an inferior race, rescues female protagonist, of a superior race, from accident.";
                break;
            case Transgression.Murder:
                helpBox= "Female protagonist's friend, male friend, mysteriously disappears while in female protagonist's company so she gets arrested on suspicion of having murdered male friend";
                break;
            case Transgression.None:
                break;
        }
        return helpBox;
    }
    public string misteryText() {
        string helpbox = "";
        switch (this.mistery) { }
        return helpbox;
    }

}

using NodeEditorFramework.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using NodeEditorFramework;

public class HTMLExport : StructuredImportExportFormat
{
    private string reset;
    private string content;
    private List<Node> workList;

    public override string FormatIdentifier { get { return "HTML"; } }
    public override string FormatExtension { get { return "html"; } }

    public override void ExportData(CanvasData data, params object[] args)
    {
        if (args == null || args.Length != 1 || args[0].GetType() != typeof(string))
            throw new ArgumentException("Location Arguments");
        string path = (string)args[0];

        reset = File.ReadAllText(Application.dataPath + "/Plugins/Node_Editor/Default/IO Formats/HTML/Story.html");
        File.WriteAllText(path, reset);
        content = File.ReadAllText(path);

        workList = new List<Node>();
        foreach (Node node in data.canvas.nodes)
        {
            workList.Add(node);
        }

        foreach (Node node in workList)
        {
            if (string.Equals(node.GetID, "ghost_preEvents"))
            {
                PreEvents tmp = (PreEvents)node;
                if (tmp.getPre())
                    content = content.Replace("Pre Events", "Pre Events: Prequel");
                else
                    content = content.Replace("Pre Events", "Pre Events: Backstory");
            }
            else
            {
                if (string.Equals(node.GetID, "ghost_eventPreEventsCard"))
                {
                    EventPreEventsCard tmp = (EventPreEventsCard)node;

                    content = content.Replace("Event Card", "Event Card: " + tmp.getEvent() + ", Aspect: " + tmp.getAspect());
                }
                else
                {
                    if (string.Equals(node.GetID, "ghost_mobPreEventsCard"))
                    {
                        MobPreEventsCard tmp = (MobPreEventsCard)node;

                        content = content.Replace("Mob Card", "Mob Card: " + tmp.getMob() + ", Aspect: " + tmp.getAspect());
                    }
                    else
                    {
                        if (string.Equals(node.GetID, "ghost_placePreEventsCard"))
                        {
                            PlacePreEventsCard tmp = (PlacePreEventsCard)node;

                            content = content.Replace("Place Card", "Place Card: " + tmp.getPlace() + ", Aspect: " + tmp.getAspect());
                        }
                        else
                        {
                            if (string.Equals(node.GetID, "ghost_secondLevelSetup"))
                            {
                                SecondLevelSetup tmp = (SecondLevelSetup)node;

                                content = content.Replace("SecondLevelSetup", "Second Level Setup: " + tmp.getValue());
                            }
                            else
                            {
                                if (string.Equals(node.GetID, "ghost_storylineSetup"))
                                {
                                    StorylineSetup tmp = (StorylineSetup)node;

                                    content = content.Replace("StorylineSetup", "Storyline Setup: " + tmp.getValue());
                                }
                                else
                                {
                                    if (string.Equals(node.GetID, "ghost_placeStorylineSetupCard"))
                                    {
                                        PlaceStorylineSetupCard tmp = (PlaceStorylineSetupCard)node;

                                        content = content.Replace("Place Storyline Setup Card", "Place Storyline Card: " + tmp.getPlace() + ", Aspect: " + tmp.getAspect());
                                    }
                                    else
                                    {
                                        if (string.Equals(node.GetID, "ghost_itemStorylineSetupCard"))
                                        {
                                            ItemStorylineSetupCard tmp = (ItemStorylineSetupCard)node;

                                            content = content.Replace("Item Storyline Setup Card", "Item Storyline Card: " + tmp.getItem() + ", Aspect: " + tmp.getAspect());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (string.Equals(node.GetID, "ghost_firstLevelConfrontation"))
            {
                FirstLevelConfrontation tmp = (FirstLevelConfrontation)node;

                content = content.Replace("First Level Confrontation", "First Level Confrontation: " + tmp.getValue());
            }

            else if (string.Equals(node.GetID, "ghost_testLevelConfrontation"))
            {
                TestConfrontation tmp = (TestConfrontation)node;

                content = content.Replace("Test Confrontation", "Test Confrontation: " + tmp.getValue());
            }
            else
            {
                if (string.Equals(node.GetID, "ghost_storylineConfrontation"))
                {
                    StorylineConfrontation tmp = (StorylineConfrontation)node;

                    content = content.Replace("StorylineConfrontation", "Storyline Confrontation: " + tmp.getValue());
                }
                else
                {
                    if (string.Equals(node.GetID, "ghost_placeStorylineConfrontationCard"))
                    {
                        PlaceStorylineConfrontationCard tmp = (PlaceStorylineConfrontationCard)node;

                        content = content.Replace("Place Storyline Confrontation Card", "Place Storyline Card: " + tmp.getPlace() + ", Aspect: " + tmp.getAspect());
                    }
                    else
                    {
                        if (string.Equals(node.GetID, "ghost_itemStorylineConfrontationCard"))
                        {
                            ItemStorylineConfrontationCard tmp = (ItemStorylineConfrontationCard)node;

                            content = content.Replace("Item Storyline Confrontation Card", "Item Storyline Card: " + tmp.getItem() + ", Aspect: " + tmp.getAspect());
                        }
                    }
                }
            }
            if (string.Equals(node.GetID, "ghost_firstLevelResolution"))
            {
                FirstLevelResolution tmp = (FirstLevelResolution)node;

                content = content.Replace("First Level Resolution", "First Level Resolution: " + tmp.getValue());
            }
            else
            {
                if (string.Equals(node.GetID, "ghost_placeResolutionCard"))
                {
                    PlaceResolutionCard tmp = (PlaceResolutionCard)node;

                    content = content.Replace("Place Resolution Card", "Place Resolution Card: " + tmp.getPlace() + ", Aspect: " + tmp.getAspect());
                }
                else
                {
                    if (string.Equals(node.GetID, "ghost_climaxEvent"))
                    {
                        content = content.Replace("Climax Event", "Climax Event: " + "Big Damn Heroes");
                    }
                    else
                    {
                        if (string.Equals(node.GetID, "ghost_continuousClimax"))
                        {
                            content = content.Replace("Continuous Climax", "Continuous Climax: " + "Denouement");
                        }
                        else
                        {
                            if (string.Equals(node.GetID, "ghost_secondLevelResolution"))
                            {
                                SecondLevelResolution tmp = (SecondLevelResolution)node;

                                content = content.Replace("Second Level Resolution", "Second Level Resolution: " + tmp.getValue());
                            }
                            else
                            {
                                if (string.Equals(node.GetID, "ghost_placeFinalCard"))
                                {
                                    PlaceFinalCard tmp = (PlaceFinalCard)node;

                                    content = content.Replace("Place Final Card", "Place FInal Card: " + tmp.getPlace() + ", Aspect: " + tmp.getAspect());
                                }

                            }
                        }
                    }
                }
            }

            if (string.Equals(node.GetID, "ghost_characterDescriptor"))
            {
                CharacterDescriptor tmp = (CharacterDescriptor)node;

                content = content.Replace("Character's Name", "Character Name: " + tmp.textName);
                content = content.Replace("Character's Age", "Character Age: " + tmp.textAge);
                content = content.Replace("Character's Gender", "Character Gender: " + tmp.textGender);
                content = content.Replace("Character's Race", "Character Race: " + tmp.textRace);
                content = content.Replace("Character's Role", "Character Role: " + tmp.role.ToString());

                if (tmp.role.ToString().Equals("The Hero"))
                    content = content.Replace("Character's Type", "Character Type: " + tmp.good.ToString());
                else
                    if (tmp.role.ToString().Equals("Shadow Archetype"))
                    content = content.Replace("Character's Type", "Character Type: " + tmp.evil.ToString());
                else
                    content = content.Replace("<li>Character's Type</li>", "");
            }
            else
            {
                if (string.Equals(node.GetID, "ghost_transformationalArcStart"))
                {
                    TransformationalArcStart tmp = (TransformationalArcStart)node;

                    content = content.Replace("Character's Theme", "Character Theme: " + tmp.theme.ToString());
                    content = content.Replace("Character's Fatal Flaw", "Character Fatal Flaw: " + tmp.flaw.ToString());
                }
                else
                {
                    if (string.Equals(node.GetID, "ghost_characterResolution"))
                    {
                        Resolution tmp = (Resolution)node;

                        content = content.Replace("Fatal Flaw Overcame", "Fatal Flaw Overcame: " + tmp.overcame.ToString());
                    }
                }
            }

            if (string.Equals(node.GetID, "ghost_quest"))
            {
                Quest tmp = (Quest)node;

                content = content.Replace("Character Name Quest", "Character Name Quest: " + tmp.getName());
            }
            else
            {
                if (string.Equals(node.GetID, "ghost_placeQuestCard"))
                {
                    PlaceQuestCard tmp = (PlaceQuestCard)node;

                    content = content.Replace("Place Card Quest", "Place Card Quest: " + tmp.getPlace() + ", Aspect: " + tmp.getAspect());
                }
                else
                {
                    if (string.Equals(node.GetID, "ghost_itemQuestCard"))
                    {
                        ItemQuestCard tmp = (ItemQuestCard)node;

                        content = content.Replace("Item Card Quest", "Item Card Quest: " + tmp.getItem() + ", Aspect: " + tmp.getAspect());
                    }
                    else
                    {
                        if (string.Equals(node.GetID, "ghost_mobQuestCard"))
                        {
                            MobQuestCard tmp = (MobQuestCard)node;

                            content = content.Replace("Mob Card Quest", "Mob Card Quest: " + tmp.getMob() + ", Aspect: " + tmp.getAspect());
                        }
                        else
                        {
                            if (string.Equals(node.GetID, "ghost_eventQuestCard"))
                            {
                                EventQuestCard tmp = (EventQuestCard)node;

                                content = content.Replace("Event Card Quest", "Event Card Quest: " + tmp.getEvent() + ", Aspect: " + tmp.getAspect());
                            }
                        }
                    }
                }
            }
            File.WriteAllText(path, content);
        }
    }

    public override CanvasData ImportData(params object[] locationArgs)
    {
        throw new NotImplementedException();
    }
}

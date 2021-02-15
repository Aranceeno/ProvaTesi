using UnityEngine;

internal class CharacterCircumplexPosition
{
    private string name;
    private Vector2 position;

    public CharacterCircumplexPosition(string name, int x, int y)
    {
        if (name == null) this.name = "";
        else this.name = name;

        position = new Vector2(x, y);
    }

    public string getName()
    {
        if (this.name == null) return "";
        return name;
    }

    public void setName(string name)
    {
        if (name == null) this.name = "";
        else this.name = name;
    }

    public Vector2 getPosition()
    {
        return position;
    }

    public void setPosition(int x, int y)
    {
        this.position = new Vector2(x, y);
    }
}
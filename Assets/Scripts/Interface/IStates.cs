namespace Isekai.Interface
{
    public enum Gamestates
    {
        Init,
        Menu,
        Options,
        Play,
        Pause,
        PlayerMenu,
        Magic,
        Assigment,
        NPCSpeaking,
        StoryPlay,
        Quit
    }

    public enum AssigmentType
    {
        collect,
        kill,
        accompaniment,
        dungeon
    }

    public enum ItemType
    {
        Equipment,
        Non_Equipment
    }

    public enum EquipmentType
    {
        Weapon,
        Head,
        Body,
        Foot
    }
}
namespace Forpost.Store.Entities;

public class Pet
{
    public Pet(int id, string nickName)
    {
        Id = id;
        NickName = nickName;
    }

    public int Id { get; set; }
    
    public string NickName { get; set; }
}
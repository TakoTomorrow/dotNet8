namespace MyConsole.Dto;

public class Member
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">姓名</param>
    /// <param name="birthday">生日</param>
    public Member(string name, DateTime birthday)
    {
        Name = name;
        BirthDate = birthday;
    }


    public string Name { get; set; }

    public DateTime BirthDate { get; }
}

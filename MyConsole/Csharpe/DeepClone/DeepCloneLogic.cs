using System.Runtime.InteropServices;
using MyConsole.Dto;

namespace MyConsole.Csharpe.DeepClone;

public class DeepCloneLogic
{
    private readonly Member _prototype;

    public DeepCloneLogic()
    {
        _prototype = new Member("小明", DateTime.Now);
    }

    /// <summary>
    /// 使用 Console 展示結果
    /// </summary>
    public void ShowResult()
    {
        var member1 = _prototype;
        var member2 = member1;
        var member3 = DeepClone.CloneObject(member1);

        Console.WriteLine(member1.Name);
        Console.WriteLine(member2.Name);
        Console.WriteLine(member3.Name);

        member1.Name = "小王";
        member3.Name = "老李";

        Console.WriteLine(member1.Name);
        Console.WriteLine(member2.Name);
        Console.WriteLine(member3.Name);
    }
}

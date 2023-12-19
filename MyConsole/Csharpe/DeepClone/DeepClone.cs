using System.Runtime.InteropServices;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace MyConsole.Csharpe.DeepClone;

public class DeepClone
{
    /// <summary>
    /// 複製物件
    /// </summary>
    /// <param name="obj">物件</param>
    /// <typeparam name="T">物件的型別</typeparam>
    /// <returns>不同記憶體位置一模一樣的物件</returns>
    public static T CloneObject<T>(T obj) where T : notnull => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
}

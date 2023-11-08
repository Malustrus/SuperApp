using System.Reflection;

class Program
{   
    static void Main(string[] args)
    {
        var exeAssembly = Assembly.LoadFrom("SuperAppLogic.dll");
        Type type = exeAssembly.GetType("SuperApp.App");

        //AppDomain exeAppDomain = AppDomain.CreateDomain("Second app domain");
        //exeAppDomain.Load(exeAssembly.FullName);
        var app = Activator.CreateInstance(type);


    }
}
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = cmdArgs[0];
            string[] invokeArgs = cmdArgs.Skip(1).ToArray();


            Assembly assembly = Assembly.GetEntryAssembly();

            Type intendedComdType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");
            if (intendedComdType == null)
            {
                throw new InvalidOperationException("Invalid command type!");
            }

            MethodInfo executeMethodInfo = intendedComdType.GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(m => m.Name == "Execute");
            if (executeMethodInfo == null)
            {
                throw new InvalidOperationException("Command does not implement required pattern! Try implementing ICommand interface instead!");
            }

            object cmdInstance = Activator.CreateInstance(intendedComdType);
            string result = (string)executeMethodInfo.Invoke(cmdInstance, new object[] { invokeArgs });

            return result;
        }
    }
}

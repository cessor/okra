using System;
using System.Windows.Markup;

namespace Seedling.Commands
{
    public class CommandsExtension : MarkupExtension
    {
        public CommandsExtension()
        {
        }

        public CommandsExtension(string commandName)
        {
            Name = commandName;
        }

        [ConstructorArgument("commandName")]
        public string Name { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return CommandNamed(Name);
        }

        public static object CommandNamed(string name)
        {
            //try
            //{
            //    //return FindWeasel(name).Command;
            //    throw new NotImplementedException();
            //}
            //catch (FriendNotInvitedComplaint complaint)
            //{
            //    Debug.WriteLine(complaint.Message);
            //    return new ViewCommand(null);
            //}
            return null;
        }
    }
}
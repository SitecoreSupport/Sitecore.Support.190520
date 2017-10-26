using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Shell.Framework.Commands.WebDAV;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Data.Items;

namespace Sitecore.Support.Shell.Framework.Commands.WebDAV
{
    public class CompositeEdit : Sitecore.Shell.Framework.Commands.WebDAV.CompositeEdit
    {
        public override void Execute(CommandContext context)
        {
            if (context.Items.Length != 1)
            {
                return;
            }

            Sitecore.Configuration.State.Client.UsesBrowserWindows = true;

            Item item = context.Items[0];
            Command editingCommand = this.GetEditingCommand(item);
            if (editingCommand == null)
            {
                return;
            }
            editingCommand.Execute(context);
        }
    }
}

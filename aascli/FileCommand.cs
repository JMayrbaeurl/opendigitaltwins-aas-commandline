using System;
using System.Collections.Generic;
using System.Text;

namespace AAS.CLI
{
    internal interface FileCommand
    {
        public int RunCommand(FileOptions options);
    }
}

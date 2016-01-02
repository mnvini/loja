using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinicius.VirtualStore.Domain.Entities
{
    public class ConfigEmails
    {
        public bool UseSsl = false;
        public string ServerSmtp = "smtp.live.com";
        public int ServerPort = 25;
        public string User = "viniciusrcr@hotmail.com";
        public bool WriteFile = false;
        public string FolderFiles = @"c:\envioEmail";
        public string From = "viniciusrcr@hotmail.com";
        public string To = "viniciusrcr@hotmail.com";
    }
}

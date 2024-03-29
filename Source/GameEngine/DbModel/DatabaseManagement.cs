﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.DbModel
{
    public static class DatabaseManagement
    {
        public static string ConnectionString { get; private set; }
        public static void ReadConnectionString(string filepath) => ConnectionString = File.ReadAllText(filepath);
    }
}

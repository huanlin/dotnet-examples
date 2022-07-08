using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using LiteDB;

namespace KeyedCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            var repo = new LiteRepository("Filename=database.db;Connection=Shared");
            var repo2 = new LiteRepository("Filename=database.db;Connection=Shared");
        }
    }
}

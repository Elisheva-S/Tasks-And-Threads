using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Lesson4.exeInClass.cl
{
    public class GeneratesFilesAndInitThem
    {
        Random Random = new Random();
        string[] s = new string[30000000];
        Task<string> generate;
        Task thread5Times;
        Task createNRemove10Files;
        Task deleteTheBigFile;
        List<string> files = new List<string>();
        public Task<string> Generate(int count)
        {
            int name;
            string nameOfFile = "";
            Init(10000000);
            for (int i = 0; i < count; i++)
            {
                generate = Task.Factory.StartNew(() =>
                {
                    name = Random.Next(1, 100);
                    nameOfFile = name + ".txt";
                    files.Add(nameOfFile.ToString());
                    File.WriteAllLines(nameOfFile, s);
                    Thread.Sleep(10000);
                    return nameOfFile;
                });
            }
            return generate;
        }
        public void Init(int x)
        {
            for (int i = 0; i < x; i++)
            {
                s[i] = "*";
            }
        }
        public void Create5Threads()
        {
            thread5Times = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Generate(10);
                }
            });
        }
        public void CreateNRemove10Files()
        {
            string nameOfFile = "";
            createNRemove10Files = Task.Factory.StartNew(async () =>
              {
                  Init(30000000);
                  nameOfFile = await generate;
                  Improve(nameOfFile);
              });
        }
        public void Improve(string name)
        {
            deleteTheBigFile = Task.Factory.StartNew(() =>
              {
                  foreach (var file in files)
                  {
                      if (file == name)
                      {
                          File.Delete(file);
                      }
                  }
              });
        }
    }
}

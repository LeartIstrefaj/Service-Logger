using Microsoft.VisualBasic.FileIO;
using Quartz.Impl.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Logging
{
    public class FajllManipuluesi:IFajllManipuluesi
        
    {
        private readonly string _filePath;
        public void Fshijfajllat()
        {
            foreach(var item in Directory.EnumerateFiles(_filePath))
            {
                File.Delete(item);
            }
        }

        public IEnumerable<string> LexoPermbajtjen()
        {
            foreach (var item in Directory.EnumerateFiles(_filePath))
            {
                //yield -> perdoret per me shume se nje return: kur perdorim vetem IEnumerable si return value
                //(nese kthehet si liste, apo ndonje varg nuk lejohet perdorimi i tij).

                yield return File.ReadAllText(item);
            }
            
        }

        //method 2:

        //public IEnumerable<string> LexoPermbajtjen()
        //{
        //    var lista = new List<string>(); 
        //    foreach (var item in Directory.EnumerateFiles(_filePath))
        //    {
        //        lista.Add(File.ReadAllText(item));
        //    }
        //    return lista;

        //}
    }
}

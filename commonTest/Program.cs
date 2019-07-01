using common;
using common.Office;
using System.Collections;
using System.IO;

namespace commonTest
{
    class Program
    {

        static void Main()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("obj1", new InsertedObject()
            {
                FromFile = new FileInfo("X:\\ДУ-К-У\\1-й Иртышский проезд.pdf"),
                Height = 50,
                Wight = 150
            });
            hashtable.Add("obj2", new InsertedObject()
            {
                FromFile = new FileInfo("X:\\ДУ-К-Д\\105.pdf"),
                Height = 50,
                Wight = 150
            });
            hashtable.Add("UNIU", "45455554545");
            hashtable.Add("Okrug", "sfsddsfs");
            hashtable.Add("District", "dfsfsfsd");
            hashtable.Add("Address", "ssssssssssssssssssssssssssss");
            var w = new Word_Operator();
            w.CreateBookmarkedDocument(new FileInfo("X:\\eeeee.docx"),
                new FileInfo("C:\\Users\\Bushmakin\\Documents\\Настраиваемые шаблоны Office\\Приложение5_Технический_паспорт1.dotx"), hashtable);
        }
    }

}

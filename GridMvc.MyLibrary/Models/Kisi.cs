using GridMvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridMvc.MyLibrary.Models
{
    public class Kisi
    {
        [GridHiddenColumn()]
        public int Id { get; set; }

        [GridColumn(Title ="Ad-Soyad",FilterEnabled =true,SortEnabled =true)]
        public string FullName { get; set; }

        [GridColumn(Title ="Yaş",SortEnabled =true)]
        public int Age { get; set; }

        [GridColumn(Title ="D.Tarihi",FilterEnabled =true,SortEnabled =true,Format ="{0:dd:MM.yyyy}")]
        public DateTime BirthDate { get; set; }

        [NotMappedColumn()] //hiç görünmeyecek, eklenmeyecek
        public bool IsActive { get; set; }

        public static List<Kisi> GetSampleKisiler(int count = 10)
        {
            Random rnd = new Random();
            List<Kisi> kisiler = new List<Kisi>();

            for (int i = 0; i < count; i++)
            {
                kisiler.Add(new Kisi()
                {
                    Id = i,
                    FullName = FakeData.NameData.GetFullName(),
                    Age = rnd.Next(10, 99),
                    BirthDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-60), DateTime.Now.AddYears(-10)),
                    IsActive = FakeData.BooleanData.GetBoolean()
                });
            }
            return kisiler;
        }
    }
}
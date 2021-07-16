using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLySach.Controllers
{
    public class SachController : ApiController
    {
        Sach[] sachs = new Sach[]
        {
            new Sach {Id = 1,Title ="Tôi thấy hoa vàng trên cỏ xanh",AuthorName = "Nguyễn Nhật Ánh",
            Price = 1, Content = "Truyện kể về tuổi thơ..."},

            new Sach {Id = 2,Title ="Pro ASP.Net MVC5",AuthorName = "Adam FreeMan",
            Price = 3.75M, Content = "The ASP.Net MVC 5 Framework is the latest evolution of Microsoft's ASP.NET web platform."},
        };

        [HttpGet]
        public List<Sach> GetSachLists()
        {
            DBSachDataContext db = new DBSachDataContext();
            return sachs.ToList();
        }

        [HttpGet]
        public Sach GetSach(int id)
        {
            DBSachDataContext db = new DBSachDataContext();
            return sachs.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public bool InsertNewSach(int Id, string Title, string Content, string AuthorName, decimal Price)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                Sach sach = new Sach();
                sach.Id = Id;
                sach.AuthorName = AuthorName;
                sach.Title = Title;
                sach.Content = Content;
                sach.Price = Price;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpPut]
        public bool UpdateSach(int Id, string Title, string Content, string AuthorName, decimal Price)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                Sach sach = db.Saches.FirstOrDefault(x => x.Id == Id);
                if (sach == null) return false;
                sach.Id = Id;
                sach.AuthorName = AuthorName;
                sach.Title = Title;
                sach.Content = Content;
                sach.Price = Price;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteSach(int id)
        {
            DBSachDataContext db = new DBSachDataContext();
            Sach sach = db.Saches.FirstOrDefault(x => x.Id == id);
            if (sach == null) return false;
            db.SubmitChanges();
            return true;
        }
    }
}

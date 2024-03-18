using Nhom05_BaiTapTuan3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom05_BaiTapTuan3.Controllers
{
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        MyDataDataContext data = new MyDataDataContext();
        //-------------Index-Theloai------------
        public ActionResult ListTheLoai()
        {
            var all_theloai = from tt in data.TheLoais select tt;
            return View(all_theloai);
        }
        //-------------Detail-------------------
        public ActionResult Detail(int id)
        {
            var D_theloai = data.TheLoais.Where(m => m.maloai == id).First();
            return View(D_theloai);
        }
        //-------------Create-------------------
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, TheLoai tl)
        {
            var ten = collection["tenloai"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.tenloai = ten;
                data.TheLoais.InsertOnSubmit(tl);
                data.SubmitChanges();
                return RedirectToAction("ListTheLoai");
            }
            return this.Create();
        }
        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = data.TheLoais.First(m => m.maloai == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
        
var theloai = data.TheLoais.First(m => m.maloai == id);
            var E_tenloai = collection["tenloai"];
            theloai.maloai = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.tenloai = E_tenloai;
                UpdateModel(theloai);
                data.SubmitChanges();
                return RedirectToAction("ListTheLoai");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_theloai = data.TheLoais.First(m => m.maloai == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_theloai = data.TheLoais.Where(m => m.maloai == id).First();
            data.TheLoais.DeleteOnSubmit(D_theloai);
            data.SubmitChanges();
            return RedirectToAction("ListTheLoai");
        }

        //--------------Search-----------------------------
        // Action để xử lý tìm kiếm theo tên thể loại
        public ActionResult Search(string keyword)
        {
            // Kiểm tra xem từ khóa tìm kiếm có tồn tại không
            if (!string.IsNullOrEmpty(keyword))
            {
                // Tìm kiếm thể loại theo từ khóa
                var searchedTheLoais = data.TheLoais.Where(tl => tl.tenloai.Contains(keyword));
                if (searchedTheLoais.Count() == 0)
                {
                    ViewBag.Message = "Khong tim thay the loai";
                }

                // Trả về view hiển thị kết quả tìm kiếm
                return View("ListTheLoai", searchedTheLoais);
            }
            else 
            {
                // Nếu từ khóa rỗng, trả về trang danh sách thể loại ban đầu
                return RedirectToAction("ListTheLoai");
            }
        }

        // Loại bỏ bối cảnh dữ liệu để tránh rò rỉ tài nguyên
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                data.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SearchAutocomplete(string term)
        {
            var suggestedBooks = data.TheLoais
                                     .Where(s => s.tenloai.ToLower().Contains(term.ToLower()))
                                     .Select(s => s.tenloai)
                                     .ToList();
            return Json(suggestedBooks, JsonRequestBehavior.AllowGet);
        }
    }
}
    

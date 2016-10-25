using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5_HW1016.Models;

namespace MVC5_HW1016.Controllers
{
    public class DataController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: Data
        public ActionResult Index(string search)
        {
            //var data = db.客戶資料;  // sql關聯需要包含鍵值欄位在關聯過去的table  a.id => b.custid 這樣才可以讓binclude a
            //if (!string.IsNullOrEmpty(search))
            //{
            //    data.Where(p => p.客戶名稱.Contains(search));  //你有使用變數去接你改變後的值嗎?
            //}
            //data.OrderByDescending(p => p.Id).Take(20);
            //return View(data);
            //var data = db.客戶資料.OrderByDescending(p => p.Id).Take(20);
            if (!string.IsNullOrEmpty(search))
            {
                return View(db.客戶資料.Where
                    (p => p.客戶名稱.Contains(search) 
                    || p.統一編號.Contains(search)
                    || p.電話.Contains(search)
                    || p.傳真.Contains(search)
                    || p.地址.Contains(search)
                    || p.Email.Contains(search))
                    .OrderBy(p => p.Id));
            }
            return View(db.客戶資料.OrderBy(p => p.Id).Take(20));

        }

        //public ActionResult Action(string search)
        //{
        //    //var data = db.客戶資料.OrderByDescending(p => p.Id).Take(20);
        //    if (!string.IsNullOrEmpty(search))
        //    {
        //        return RedirectToAction("Index", db.客戶資料.Where(p => p.客戶名稱.Contains(search)).OrderByDescending(p => p.Id).Take(20));
        //    }
        //    return RedirectToAction("Index", db.客戶資料.OrderByDescending(p => p.Id).Take(20));
        //}

        // GET: Data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: Data/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Data/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.客戶資料.Add(客戶資料);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: Data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: Data/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: Data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料);
            
            客戶資料.是否已刪除 = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

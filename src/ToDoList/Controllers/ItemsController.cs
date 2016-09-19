using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private IItemRepository itemRepo;

        public ItemsController(IItemRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                itemRepo = new EFItemRepository();
            }
            else
            {
                itemRepo = thisRepo;
            }
        }

        public ViewResult Index()
        {
            return View(itemRepo.Items.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisItem = itemRepo.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            itemRepo.Save(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisItem = itemRepo.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            itemRepo.Edit(item);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisItem = itemRepo.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = itemRepo.Items.FirstOrDefault(items => items.ItemId == id);
            itemRepo.Remove(thisItem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkDone(int id)
        {
            var item = itemRepo.Items.FirstOrDefault(items => items.ItemId == id);
            item.Done = (!item.Done);
            itemRepo.Edit(item);
            return RedirectToAction("Index");
        }

    }
}

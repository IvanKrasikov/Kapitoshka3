using System.Diagnostics;
using Kapitoshka3.Models;
using Kapitoshka3.Models.Node.Domain.Entity;
using Kapitoshka3.Models.Node.Persistence;
using Kapitoshka3.Models.StringListTree.Domain.Entity;
using Kapitoshka3.Models.Tree.Domain.Entity;
using Kapitoshka3.Models.Tree.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Kapitoshka3.Controllers
{
    public class HomeController : Controller
    {
        private NodeDb nodeDb = new();
        public IActionResult Index()
        {
            List<Node> nodes = (List<Node>)nodeDb.GetList();
            nodes.Sort((node1, node2) => node1.Id.CompareTo(node2.Id));
            BuildTree tree = new();
            Tree root = tree.Build(nodes);
            List<StringListTree> strings = tree.TreeToListString(root);
            return View(strings);
        }

        public async Task<IActionResult> Add(int id)
        {
            nodeDb.Update(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

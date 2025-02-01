using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ExpensesDB _context;

        public HomeController(ILogger<HomeController> logger, ExpensesDB context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); 
        }
        public IActionResult Expenses()
        {
            var allExpenses = _context.ExpenseTable.ToList();


            return View(allExpenses);
        }
         public IActionResult CreateEditExpenseForm(Expenses model)
        {
            if(model.Id == 0)
            {
                //create
                _context.ExpenseTable.Add(model);
            }else
            {
                //editing
                _context.ExpenseTable.Update(model);
            }
           
            _context.SaveChanges(); 
            return RedirectToAction("Expenses");
        }

        public IActionResult Delete(int id)
        {
            var expenseInDb = _context.ExpenseTable.SingleOrDefault(expen => expen.Id == id);
            _context.ExpenseTable.Remove(expenseInDb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult CreateEditExpense(int? id)
        {
            if (id != null)
            {
                //editing: loading expense by ID
                var expenseInDb = _context.ExpenseTable.SingleOrDefault(expen => expen.Id == id);
                return View(expenseInDb);
            }
           
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

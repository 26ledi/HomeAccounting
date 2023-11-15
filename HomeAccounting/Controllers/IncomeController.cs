using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;
        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        public async Task<IActionResult> Index()
        {
            var incomes = await _incomeService.GetIncomeAsync();

            return View(incomes);
        }
        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IncomeDto incomeDto)
        {
            if (!ModelState.IsValid) 
            {
               await _incomeService.AddAsync(incomeDto);
               return RedirectToAction("Index", "Income");
            }
            return View(incomeDto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var income = await _incomeService.GetIncomeDtoByIdAsync(id);
            return View(income);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IncomeDto incomeDto)
        {
            if (!ModelState.IsValid)
            {
                await _incomeService.UpdateAsync(incomeDto);
                return RedirectToAction("Index", "Income");
            }
            return View(incomeDto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var income = await _incomeService.GetIncomeDtoByIdAsync(id);
            return View(income);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(IncomeDto incomeDto)
        {
            if (!ModelState.IsValid)
            {
                await _incomeService.DeleteAsync(incomeDto.Id);
                return RedirectToAction("Index", "Income");
            }
            return View(incomeDto);
        }


    }
}

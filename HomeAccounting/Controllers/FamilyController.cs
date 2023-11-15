using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FamilyController : Controller
    {
        private readonly IFamilyService _familyService;

        public FamilyController(IFamilyService familyService)
        {
            _familyService = familyService;
        }
        public async Task<IActionResult> Index()
        {
            var families = await _familyService.GetAllFamilyAsync();
            return View(families);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FamilyDto familyDto)
        {
            if (ModelState.IsValid)
            {
                await _familyService.AddAsync(familyDto);

                return RedirectToAction("Index", "Family");
            }

            return View(familyDto);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var family = await _familyService.GetAllFamilyByIdAsync(id);
            return View(family);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FamilyDto familyDto)
        {
            if (ModelState.IsValid)
            {
                await _familyService.UpdateAsync(familyDto);
                return RedirectToAction("Index", "Family");
            }

            return View(familyDto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var family = await _familyService.GetAllFamilyByIdAsync(id);
            return View(family);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(FamilyDto familyDto)
        {
            if (ModelState.IsValid)
            {
                await _familyService.DeleteAsync(familyDto.Id.Value);
                return RedirectToAction("Index", "Family");
            }

            return View(familyDto);
        }
        [HttpGet]
        public async Task<IActionResult> Balance()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Balance(FamilyDto familyDto)
        {
            if (ModelState.IsValid)
            {
                double balanceGivingTime = await _familyService.CalculateIncomeGivingTimeAsync(familyDto.Id.Value, familyDto.StartTime.Value, familyDto.EndTime.Value);
                familyDto.BalanceTime = balanceGivingTime;

                DateTime firstDayOfMonth = new DateTime(familyDto.StartTime.Value.Year, familyDto.StartTime.Value.Month, 1);
                double balanceMonth = await _familyService.CalculateIncomeForMonthAsync(familyDto.Id.Value, firstDayOfMonth.Year, firstDayOfMonth.Month);
                familyDto.BalanceIncomeMonth = balanceMonth;

                DateTime firstDayOfYear = new DateTime(familyDto.StartTime.Value.Year, 1, 1);
                double balanceYear = await _familyService.CalculateIncomeForYearAsync(familyDto.Id.Value, firstDayOfYear.Year);
                familyDto.BalanceIncomeYear = balanceYear;

                double highestIncomeGivingTime = await _familyService.GetHighestIncomeGivingTimeAsync(familyDto.Id.Value, familyDto.StartTime.Value, familyDto.EndTime.Value);
                familyDto.HighestIncomeTime = highestIncomeGivingTime;

                DateTime DayOfMonth = new DateTime(familyDto.StartTime.Value.Year, familyDto.StartTime.Value.Month, 1);
                double highestIncomeMonth = await _familyService.GetHighestIncomeMonthAsync(familyDto.Id.Value, DayOfMonth.Year, DayOfMonth.Month);
                familyDto.HighestIncomeMonth = highestIncomeMonth;


                DateTime DayOfYear = new DateTime(familyDto.StartTime.Value.Year, 1, 1);
                double highestIncomeYear = await _familyService.GetHighestIncomeYearAsync(familyDto.Id.Value, DayOfYear.Year);
                familyDto.HighestIncomeYear = highestIncomeYear;
            }

            return View(familyDto);
        }


    }
}

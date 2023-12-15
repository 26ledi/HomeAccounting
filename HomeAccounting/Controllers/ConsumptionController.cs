using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.Controllers
{
    [Authorize]
    public class ConsumptionController : Controller
    {
        private readonly IConsumptionService _consumptionService;
        public ConsumptionController(IConsumptionService consumptionService)
        {
            _consumptionService = consumptionService;
        }
        public async Task<IActionResult> Index()
        {
            var consumptions = await _consumptionService.GetAsync();

            return View(consumptions);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ConsumptionDto consumption)
        {
            if (!ModelState.IsValid)
            {
                await _consumptionService.AddAsync(consumption);

                return RedirectToAction("Index", "Consumption");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var consumption = await _consumptionService.GetByIdAsync(id);

            return View(consumption);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ConsumptionDto consumptionDto)
        {

            if (!ModelState.IsValid)
            {
                await _consumptionService.UpdateAsync(consumptionDto);

                return RedirectToAction("Index", "Consumption");
            }

            return View(consumptionDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var consumption = await _consumptionService.GetByIdAsync(id);

            return View(consumption);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ConsumptionDto consumptionDto)
        {

            if (!ModelState.IsValid)
            {
                await _consumptionService.DeleteAsync(consumptionDto.Id);

                return RedirectToAction("Index", "Consumption");
            }

            return View(consumptionDto);
        }

        [HttpGet]
        public IActionResult Balance()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BalanceForType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BalanceForType(ConsumptionDto consumptionDto)
        {
            if (!ModelState.IsValid)
            {

                consumptionDto.List = await _consumptionService.GetFrequentConsumptionTypeByTimeAsync(consumptionDto.StartDate.Value, consumptionDto.EndDate.Value);
                consumptionDto.FrequentByMonthList = await _consumptionService.GetFrequentConsumptionTypeByMonthAsync(consumptionDto.StartDate.Value.Month, consumptionDto.StartDate.Value.Year);
                consumptionDto.FrequentByYearList = await _consumptionService.GetFrequentConsumptionTypeByYearAsync(consumptionDto.StartDate.Value.Year);
            }

            return View(consumptionDto);
        }


        [HttpGet]
        public IActionResult BalanceForMember()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BalanceForMember(ConsumptionDto consumptionDto)
        {
            if (!ModelState.IsValid)
            {
                consumptionDto.FrequentMembersByTime = await _consumptionService.GetMemberFrequentConsumptionByTimeAsync(consumptionDto.StartDate.Value, consumptionDto.EndDate.Value);
                consumptionDto.FrequentMembersByMonth = await _consumptionService.GetMemberFrequentConsumptionByMonthAsync(consumptionDto.StartDate.Value.Month, consumptionDto.StartDate.Value.Year);
                consumptionDto.FrequentMembersByYear = await _consumptionService.GetMemberFrequentConsumptionByYearAsync(consumptionDto.StartDate.Value.Year);
            }

            return View(consumptionDto);
        }


        [HttpGet]
        public IActionResult BalanceDaysMax()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BalanceDaysMax(ConsumptionDto consumptionDto)
        {
            if (ModelState.IsValid)
            {
                consumptionDto.MaxDayofWeeks = await _consumptionService.GetDaysWithMaxConsumptionAsync();
            }

            return View(consumptionDto);
        }

        [HttpGet]
        public IActionResult MaxConsumptionByTime()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MaxConsumptionByTime(ConsumptionDto consumptionDto)
        {
            if (!ModelState.IsValid)
            {
                consumptionDto.MaxConsumptionByTime = await _consumptionService.GetMaxConsumptionNameByTime(consumptionDto.StartDate.Value, consumptionDto.EndDate.Value);
                consumptionDto.MaxConsumptionByMonth = await _consumptionService.GetMaxConsumptionNameByMonth(consumptionDto.StartDate.Value.Month, consumptionDto.StartDate.Value.Year);
                consumptionDto.MaxConsumptionByYear = await _consumptionService.GetMaxConsumptionNameByYear(consumptionDto.StartDate.Value.Year);
            }

            return View(consumptionDto);
        }
    }
}

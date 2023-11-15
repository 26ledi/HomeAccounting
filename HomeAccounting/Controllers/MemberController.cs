using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IFamilyService _familyService;
        public MemberController(IMemberService memberService, IFamilyService familyService)
        {
            _memberService = memberService;
            _familyService = familyService;
        }

        //GET:Members
        public async Task<IActionResult> Index()
        {
            var members = await _memberService.GetMemberDtoAsync();
            return View(members);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var families = await _familyService.GetAllFamilyAsync();
            ViewBag.Families = families;

            return View();
        }
        //POST:Members
        [HttpPost]
        public async Task<IActionResult> Create(MemberDto memberDto)
        {
            if (ModelState.IsValid)
            {
                await _memberService.AddAsync(memberDto);

                return RedirectToAction("Index", "Member");
            }
            var families = await _familyService.GetAllFamilyAsync();
            ViewBag.Families = families;

            return View(memberDto);
        }
        //PUT:Members
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            var members = await _memberService.GetMemberDtoAsync();
            ViewBag.Members = members;
            var families = await _familyService.GetAllFamilyAsync();
            ViewBag.Families = families;

            return View(member);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MemberDto memberDto)
        {
            if (ModelState.IsValid)
            {
                await _memberService.UpdateAsync(memberDto);
                return RedirectToAction("Index", "Member");
            }
            var members = await _memberService.GetMemberDtoAsync();
            ViewBag.Members = members;
            var families = await _familyService.GetAllFamilyAsync();
            ViewBag.Families = families;

            return View(memberDto);
        }
        //DELETE:Members
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            var members = await _memberService.GetMemberDtoAsync();
            ViewBag.Members = members;

            return View(member);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(MemberDto memberDto)
        {
            await _memberService.DeleteAsync(memberDto);

            var members = await _memberService.GetMemberDtoAsync();
            ViewBag.Members = members;

            return RedirectToAction("Index", "Member");
        }

        //Calculate Income by month(given month):Members
        [HttpGet]
        public IActionResult Balance()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Balance(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
            {
                double balanceGivingTime = await _memberService.CalculateIncomeGivingTimeAsync(memberDto.MemberId, memberDto.StartTime, memberDto.EndTime);
                memberDto.Balance = balanceGivingTime;

                DateTime firstDayOfMonth = new DateTime(memberDto.StartTime.Year, memberDto.StartTime.Month, 1);
                double balanceMonth = await _memberService.CalculateIncomeForMonthAsync(memberDto.MemberId, firstDayOfMonth.Year, firstDayOfMonth.Month);
                memberDto.BalanceIncomeMonth = balanceMonth;

                DateTime firstDayOfYear = new DateTime(memberDto.StartTime.Year,1, 1);
                double balanceYear = await _memberService.CalculateIncomeMemberForYearAsync(memberDto.MemberId, firstDayOfYear.Year);
                memberDto.BalanceIncomeYear = balanceYear;

                double highestIncomeGivingTime = await _memberService.GetHighestIncomeGivingTimeAsync(memberDto.MemberId, memberDto.StartTime, memberDto.EndTime);
                memberDto.HighestIncomeTime = highestIncomeGivingTime;

                DateTime DayOfMonth = new DateTime(memberDto.StartTime.Year, memberDto.StartTime.Month, 1);
                double highestIncomeMonth = await _memberService.GetHighestIncomeMonthAsync(memberDto.MemberId,DayOfMonth.Year,DayOfMonth.Month);
                memberDto.HighestIncomeMonth = highestIncomeMonth;

                DateTime DayOfYear = new DateTime(memberDto.StartTime.Year,1, 1);
                double highestIncomeYear = await _memberService.GetHighestIncomeYearAsync(memberDto.MemberId, DayOfYear.Year);
                memberDto.HighestIncomeYear = highestIncomeYear;
            }

            return View(memberDto);
        }

    }
}

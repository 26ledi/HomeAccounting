using AutoMapper.Configuration.Conventions;
using HomeAccounting.BusinessLogic.Dtos;
using HomeAccounting.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace HomeAccounting.Controllers
{
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
        public async Task<IActionResult>Index()
        {
            var members = await _memberService.GetMemberDtoAsync();
            return View(members);  
        }
        [HttpGet]
        public  async Task<IActionResult>Create() 
        {
            var families = await _familyService.GetAllFamilyAsync(); 
            ViewBag.Families = families; 

            return View();
        }
        //POST:Members
        [HttpPost]
        public async Task<IActionResult>Create(MemberDto member) 
        {
            if (ModelState.IsValid) 
            {
                await _memberService.AddAsync(member);

                return RedirectToAction("Index", "Member");
            }
            var families = await _familyService.GetAllFamilyAsync();
            ViewBag.Families = families;

            return View(member);
        }
        //PUT:Members
        [HttpGet]
        public async Task<IActionResult>Edit(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            var members = await _memberService.GetMemberDtoAsync();
            ViewBag.Members = members;
            var families = await _familyService.GetAllFamilyAsync();
            ViewBag.Families = families;

            return View(member);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(MemberDto member) 
        {
            if (ModelState.IsValid) 
            {
                await _memberService.UpdateAsync(member);
                return RedirectToAction("Index", "Member");
            }
            var members = await _memberService.GetMemberDtoAsync();
            ViewBag.Members = members;
            var families = await _familyService.GetAllFamilyAsync();
            ViewBag.Families = families;

            return View(member);
        }
        //DELETE:Members
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            var members = await _memberService.GetMemberDtoAsync();
            ViewBag.Members = members;

            return View(member);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(MemberDto member)
        {
            await _memberService.DeleteAsync(member);

            var members = await _memberService.GetMemberDtoAsync();
            ViewBag.Members = members;

            return RedirectToAction("Index", "Member");
        }

    }
}

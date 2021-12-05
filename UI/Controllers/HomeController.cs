using Business.Interface;
using Dtos.WorkDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {
            var workList = await _workService.GetAll();
            return View(workList);
        }
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _workService.Create(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _workService.GetById(id);
            return View(new WorkUpdateDto() //worklistdto to workupdatedto
            {
                Id = dto.Id,
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted
            });
        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _workService.Update(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }
    }
}

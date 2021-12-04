﻿using Business.Interface;
using DataAccess.UnitOfWork;
using Dtos.WorkDtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WorkManager : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _unitOfWork.GetRepository<Work>().CreateAsync(new()
            {
                IsCompleted = dto.IsCompleted,
                Definition = dto.Definition
            });
            await _unitOfWork.SaveChanges();
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _unitOfWork.GetRepository<Work>().GetAllAsync();
            var workList = new List<WorkListDto>();
            if (list != null & list.Count > 0)
            {
                foreach (var work in list)
                {
                    workList.Add(new()
                    {
                        Definition = work.Definition,
                        IsCompleted = work.IsCompleted,
                        Id = work.Id
                    });
                }
            }
            return workList;
        }

        public async Task<WorkListDto> GetById(object id)
        {
            var work = await _unitOfWork.GetRepository<Work>().GetByIdAsync(id);
            return new()
            {
                Definition = work.Definition,
                IsCompleted = work.IsCompleted
            };
        }
    }
}

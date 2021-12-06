﻿using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        //khanhPc1 
        Task<ICollection<SubScription>> GetSubcriptionByInstructorId(int instructorId);
    }
}
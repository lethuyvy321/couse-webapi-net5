using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrLeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository :IGenericRepository<LeaveAllocation>
    {

    }
}

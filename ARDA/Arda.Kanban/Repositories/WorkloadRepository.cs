﻿using Arda.Common.ViewModels.Main;
using Arda.Common.Interfaces.Kanban;
using Arda.Common.Models.Kanban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arda.Kanban.Repositories
{
    public class WorkloadRepository : IWorkloadRepository
    {
        KanbanContext _context;

        public WorkloadRepository(KanbanContext context)
        {
            _context = context;
        }

        public List<WorkloadsByUserViewModel> GetWorkloadsByUser(string uniqueName)
        {
            try
            {
                var response = (from wb in _context.WorkloadBacklogs
                                join wbu in _context.WorkloadBacklogUsers on wb.WBUsers.SingleOrDefault().WBUserID equals wbu.WBUserID
                                join uk in _context.UsersKanban on wbu.KanbanUser.UniqueName equals uk.UniqueName
                                where uk.UniqueName.Equals(uniqueName)
                                orderby wb.WBTitle
                                select new WorkloadsByUserViewModel
                                {
                                    _WorkloadID = wb.WBID,
                                    _WorkloadTitle = wb.WBTitle,
                                    _WorkloadStartDate = wb.WBStartDate,
                                    _WorkloadEndDate = wb.WBEndDate
                                }).ToList();

                if (response != null)
                {
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

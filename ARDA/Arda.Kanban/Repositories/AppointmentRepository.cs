﻿using Arda.Common.Interfaces.Kanban;
using Arda.Common.Models.Kanban;
using Arda.Common.ViewModels.Kanban;
using Arda.Common.ViewModels.Main;
using Arda.Kanban.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arda.Kanban.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        KanbanContext _context;

        public AppointmentRepository(KanbanContext context)
        {
            _context = context;
        }

        public bool AddNewAppointment(AppointmentViewModel appointment)
        {
            try
            {
                var userKanban = new UserKanbanViewModel();
                var workload = new WorkloadBacklog();

                // Creating UserKanban object to save.
                userKanban.UniqueName = appointment._AppointmentUserUniqueName;

                // Creating Workload object to save.
                workload.WBID = appointment._AppointmentWorkloadWBID;

                var appointmentToBeSaved = new Appointment()
                {
                    AppointmentID = appointment._AppointmentID,
                    AppointmentUser = userKanban,
                    AppointmentWorkload = workload,
                    AppointmentDate = appointment._AppointmentDate,
                    AppointmentHoursDispensed = appointment._AppointmentHoursDispensed,
                    AppointmentTE = appointment._AppointmentTE,
                    AppointmentComment = appointment._AppointmentComment
                };

                _context.Appointments.Add(appointmentToBeSaved);
                var response = _context.SaveChanges();

                if (response > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.StackTrace);
            }
        }
    }
}

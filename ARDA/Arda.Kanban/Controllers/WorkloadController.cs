﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Arda.Common.ViewModels.Main;
using Arda.Common.Interfaces.Kanban;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;

namespace Arda.Kanban.Controllers
{
    [Route("api/[controller]")]
    public class WorkloadController : Controller
    {
        IWorkloadRepository _repository;

        public WorkloadController(IWorkloadRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add()
        {
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(HttpContext.Request.Body);
                string requestFromPost = reader.ReadToEnd();
                var workload = JsonConvert.DeserializeObject<WorkloadViewModel>(requestFromPost);

                // Calling add
                var response = _repository.AddNewWorkload(workload);

                if (response)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("listworkloadbyuser")]
        public IEnumerable<WorkloadsByUserViewModel> ListWorkloadByUser()
        {
            try
            {
                var uniqueName = HttpContext.Request.Headers["unique_name"].ToString();
                var workloads = _repository.GetWorkloadsByUser(uniqueName);

                if (workloads != null)
                {
                    return workloads;
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

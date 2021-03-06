﻿// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.WeiXin.Controllers.CompletedTasksController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
    public class CompletedTasksController : Controller
    {
        public ActionResult Index()
        {
            return Index(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection coll)
        {
            List<RoadFlow.Data.Model.WorkFlowTask> list = new List<RoadFlow.Data.Model.WorkFlowTask>();
            string empty = string.Empty;
            RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Platform.WeiXin.Organize.CheckLogin();
            Guid currentUserID = RoadFlow.Platform.WeiXin.Organize.CurrentUserID;
            empty = base.Request.QueryString["searchkey"];
            if (coll != null)
            {
                empty = base.Request.Form["SearchTitle"];
            }

            ref long count;
            list = workFlowTask.GetTasks(currentUserID, out count, 15, 1, empty, "", "", "", "", 1);
            base.ViewBag.Count = count;
            base.ViewBag.SearchTitle = empty;
            return View(list);
        }

        public string GetTasks()
        {
            string text = base.Request.QueryString["pagenumber"];
            string text2 = base.Request.QueryString["pagesize"];
            string title = base.Request.QueryString["SearchTitle"];
            Guid currentUserID = RoadFlow.Platform.WeiXin.Organize.CurrentUserID;
            long count;
            List<RoadFlow.Data.Model.WorkFlowTask> tasks = new RoadFlow.Platform.WorkFlowTask().GetTasks(currentUserID, out count, MyExtensions.ToInt(text2, 15), MyExtensions.ToInt(text, 2), title, "", "", "", "", 1);
            JsonData jsonData = new JsonData();
            if (tasks.Count == 0)
            {
                return "[]";
            }
            foreach (RoadFlow.Data.Model.WorkFlowTask item in tasks)
            {
                JsonData jsonData2 = new JsonData();
                jsonData2["id"] = item.ID.ToString();
                jsonData2["title"] = item.Title;
                jsonData2["time"] = (item.CompletedTime1.HasValue ? MyExtensions.ToDateTimeString(item.CompletedTime1.Value) : "");
                jsonData2["sender"] = item.SenderName;
                jsonData2["flowid"] = item.FlowID.ToString();
                jsonData2["stepid"] = item.StepID.ToString();
                jsonData2["instanceid"] = item.InstanceID;
                jsonData2["groupid"] = item.GroupID.ToString();
                jsonData.Add(jsonData2);
            }
            return jsonData.ToJson();
        }
    }
}

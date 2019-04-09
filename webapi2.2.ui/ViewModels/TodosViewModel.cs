using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Controls;
using DotVVM.BusinessPack;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.Framework.ViewModel.Validation;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Binding;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;

using webapi22.example.dtos.DtoClasses;
using webapi22.example.dtos.DtoClasses.UserTodoListsTypes;
using static webapi22.example.data_access.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using webapi2._2.ui;
using AppContext = webapi2._2.ui.AppContext;

namespace webapi2_2.ui.ViewModels
{
    public class TodosViewModel : DotvvmViewModelBase
    {
        public UserTodoLists _userTodoList { get; set; }
        public GridViewDataSet<TodoList> TodoListGridView { get; set; }

        public bool isTaskModalDisplayed { get; set; }
    
        public override Task Init()
        {
            if (Context.Parameters.ContainsKey("displayTodo")) isTaskModalDisplayed = true;
            return base.Init();
        }

        public override Task Load()
        {
            if (!Context.IsPostBack && Context.Parameters.ContainsKey("todoListId"))
            {
                _userTodoList = AbstractGetListsForUser(new Guid(AppContext.Current.Session.GetString("UserId")));

                var list = _userTodoList.TodoLists.Where(l =>
                    l.TodoListId == new Guid(Context.Parameters["todoListId"].ToString())).ToList();
            }
            if (!Context.IsPostBack)
            {
                _userTodoList = AbstractGetListsForUser(new Guid(AppContext.Current.Session.GetString("UserId")));
                if (TodoListGridView == null)
                    TodoListGridView = new GridViewDataSet<TodoList>();
            }

            return base.Load();
        }

        public override Task PreRender()
        {
            if (TodoListGridView.IsRefreshRequired) TodoListGridView.LoadFromQueryable(_userTodoList.TodoLists.AsQueryable());

            return base.PreRender();
        }

        public void GoToList(Guid listId)
        {
            var data = new { test1 = "val", test2 = "val2" };
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("todoListId", listId);
            p.Add("displayTodo", true);
            Context.RedirectToRoute("TodosWithList", new { todoListId = listId, displayTodo = true });
        }

    }
}


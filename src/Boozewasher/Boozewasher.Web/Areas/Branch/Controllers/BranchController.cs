using Boozewasher.Application.Features.Branches.Commands.Create;
using Boozewasher.Application.Features.Branches.Queries.GetAllCached;
using Boozewasher.Application.Features.Branches.Queries.GetById;
using Boozewasher.Web.Abstractions;
using Boozewasher.Web.Areas.Branch.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boozewasher.Web.Areas.Branch.Controllers
{
    [Area("Branch")]
    public class BranchController : BaseController<BranchController>
    {
        public IActionResult Index()
        {
            var model = new BranchViewModel();
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllBranchesCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<BranchViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            var branchesResponse = await _mediator.Send(new GetAllBranchesCachedQuery());

            if (id == 0)
            {
                var branchViewModel = new BranchViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", branchViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetBranchByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var branchViewModel = _mapper.Map<BranchViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", branchViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, BranchViewModel branch)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createBranchCommand = _mapper.Map<CreateBranchCommand>(branch);
                    var result = await _mediator.Send(createBranchCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Branch with ID {result.Data} Created.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    //var updateBranchCommand = _mapper.Map<UpdateBranchCommand>(branch);
                    //var result = await _mediator.Send(updateBranchCommand);
                    //if (result.Succeeded) _notify.Information($"Branch with ID {result.Data} Updated.");
                }
                var response = await _mediator.Send(new GetAllBranchesCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<BranchViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", branch);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        //[HttpPost]
        //public async Task<JsonResult> OnPostDelete(int id)
        //{
        //    var deleteCommand = await _mediator.Send(new DeleteBranchCommand { Id = id });
        //    if (deleteCommand.Succeeded)
        //    {
        //        _notify.Information($"Branch with Id {id} Deleted.");
        //        var response = await _mediator.Send(new GetAllBranchsCachedQuery());
        //        if (response.Succeeded)
        //        {
        //            var viewModel = _mapper.Map<List<BranchViewModel>>(response.Data);
        //            var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
        //            return new JsonResult(new { isValid = true, html = html });
        //        }
        //        else
        //        {
        //            _notify.Error(response.Message);
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        _notify.Error(deleteCommand.Message);
        //        return null;
        //    }
        //}
    }
}

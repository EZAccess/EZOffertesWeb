using EZOffertes.Models;
using EZOffertes.Server.Services;
using EZOffertes.Server.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Components
{
    public class RelationEditFormBase : ComponentBase
    {

        [Parameter] public int Id { get; set; }

        [Inject] public IRelationService RelationService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }

        protected ErrorInfo Err { get; set; } = new ErrorInfo();
        protected EditContext editContext;
        protected Relation Relation { get; set; } = new Relation();

        protected async override Task OnInitializedAsync()
        {
            if (Id != 0)
            {
                Relation = await RelationService.GetRelation(Id, Err);
            }
            else
            {
                Relation = new Relation();
            }
            editContext = new (Relation);
        }

        protected async Task HandleSubmit()
        {
            if (editContext.Validate())
            {
                Relation result = null;
                if (Relation.RelationId != 0)
                {
                    result = await RelationService.UpdateRelation(Relation, Err);
                    editContext.MarkAsUnmodified();
                }
                else
                {
                    result = await RelationService.CreateRelation(Relation, Err);
                    NavigationManager.NavigateTo($"/customers/orderspercustomer/{result.RelationId}");
                }
            }

        }
    }
}

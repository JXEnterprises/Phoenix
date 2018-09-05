using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Phoenix.Models.DealViewModels
{
    public class CreateAppraisal
    {
        
        public int DealId { get; set; }

        public Unit Unit { get; set; }

        public string AppraisedBy { get; set; }

    }
}
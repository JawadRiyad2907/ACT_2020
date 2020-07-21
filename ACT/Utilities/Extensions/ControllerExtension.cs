using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACT.Utilities.Extensions
{
    public static class ControllerExtension
    {
        public static string[] GetModelErrors(this ModelStateDictionary ModelState)
        {
            var errors = new List<string>();
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return errors.ToArray();
        }
        public static string[] GetDistinctModelErrors(this ModelStateDictionary ModelState, string distinctByKey = "")
        {
            var errors = new List<string>();
            List<string> distinctErrors = new List<string>();
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    if (state.Key.Contains(distinctByKey))
                        distinctErrors.Add(error.ErrorMessage);
                    errors.Add(error.ErrorMessage);
                }
            }
            var result = errors.Where(e => !distinctErrors.Contains(e)).ToList();
            if (distinctErrors.Count > 0)
                result.AddRange(errors.Where(e => distinctErrors.Contains(e)).Distinct());
            return result.ToArray();
        }
    }
}